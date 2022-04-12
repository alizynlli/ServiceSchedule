using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Services
{
    public class ServiceCardService : IServiceCardService
    {
        private readonly IServiceRepository _repository;

        public ServiceCardService()
        {
            _repository = RepositoryContainer.ServiceRepository;
        }

        public async Task<ActionResult<IEnumerable<ServiceEntity>>> GetAllAsync()
        {
            var res = await _repository.GetAllAsync();
            if (res.IsFailed)
                return ActionResult<IEnumerable<ServiceEntity>>.Failed(res.Exception);

            var entityList = res.Data.Select(dao => (ServiceEntity)dao.ToEntity());

            return ActionResult<IEnumerable<ServiceEntity>>.Succeed(entityList);
        }

        public Task<ActionResult> SaveAsync(ServiceEntity entity)
        {
            var dao = (ServiceDao)entity.ToDao();

            return dao.Id == 0 ? _repository.InsertAsync(dao) : _repository.UpdateAsync(dao);
        }

        public Task<ActionResult> DeleteAsync(int id, bool permanently = false)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<ActionResult<ServiceEntity>> GetByCode(string code)
        {
            var res = await _repository.GetByCode(code);
            if (res.IsFailed)
                return ActionResult<ServiceEntity>.Failed(res.Exception);

            var entity = (ServiceEntity)res.Data?.ToEntity();
            return ActionResult<ServiceEntity>.Succeed(entity);
        }
    }
}
