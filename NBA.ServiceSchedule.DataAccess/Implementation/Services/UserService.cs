using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService()
        {
            _repository = RepositoryContainer.UserRepository;
        }

        public async Task<ActionResult<IEnumerable<UserEntity>>> GetAllAsync()
        {
            var daoListResult = await _repository.GetAllAsync();

            if (daoListResult.IsFailed)
                return ActionResult<IEnumerable<UserEntity>>.Failed(daoListResult.Exception);

            var daoList = daoListResult.Data;

            var entityList = daoList.Select(dao => (UserEntity)dao.ToEntity());
            return ActionResult<IEnumerable<UserEntity>>.Succeed(entityList);
        }

        public Task<ActionResult> SaveAsync(UserEntity entity)
        {
            var dao = (UserDao)entity.ToDao();

            return dao.Id == 0 ? _repository.InsertAsync(dao) : _repository.UpdateAsync(dao);
        }

        public async Task<ActionResult> DeleteAsync(int id, bool permanently = false)
        {
            var userResult = await _repository.GetById(id);

            if (userResult.IsFailed)
                return ActionResult.Failed(userResult.Exception);

            if (userResult.Data == null || userResult.Data.Id == 0)
                return ActionResult.Failed("İstifadəçi tapılmadı.");

            if (userResult.Data.IsSupervisor)
                return ActionResult.Failed("Supervisor sistemdən silinə bilməz.");

            var deleteResult = await RepositoryContainer.PermissionRepository.DeleteUserPermissionsAsync(userResult.Data.Id);
            if (deleteResult.IsFailed)
                return ActionResult.Failed(deleteResult.Exception);

            return await _repository.DeleteAsync(id);
        }

        public Task<ActionResult> MarkAsAdministrator(string userName)
        {
            return _repository.MarkAsAdministrator(userName);
        }

        public async Task<ActionResult<UserEntity>> FindUserByUserNameAndPassword(string userName, string password)
        {
            if (userName.IsNullOrEmpty())
                return ActionResult<UserEntity>.Failed("İstifadəçi adı boş ola bilməz.");

            var userDaoResult = await _repository.FindUserByUserNameAndPassword(userName, password.GetHashValue());
            if (userDaoResult.IsFailed)
            {
                return ActionResult<UserEntity>.Failed(userDaoResult.Exception);
            }

            return ActionResult<UserEntity>.Succeed(userDaoResult.Data?.ToEntity() as UserEntity);
        }
    }
}
