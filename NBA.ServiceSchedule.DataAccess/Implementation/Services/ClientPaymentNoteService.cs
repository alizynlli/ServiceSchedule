using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Services
{
    public class ClientPaymentNoteService : IClientPaymentNoteService
    {
        private readonly IClientPaymentNoteRepository _repository;

        public ClientPaymentNoteService()
        {
            _repository = RepositoryContainer.ClientPaymentNoteRepository;
        }

        public async Task<ActionResult<IEnumerable<ClientPaymentNoteEntity>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            if (result.IsFailed)
                return ActionResult<IEnumerable<ClientPaymentNoteEntity>>.Failed(result.Exception);

            var entityList = result.Data.Select(dao => (ClientPaymentNoteEntity)dao.ToEntity());

            return ActionResult<IEnumerable<ClientPaymentNoteEntity>>.Succeed(entityList);
        }

        public Task<ActionResult> SaveAsync(ClientPaymentNoteEntity entity)
        {
            var dao = (ClientPaymentNoteDao)entity.ToDao();

            return dao.Id == 0 ? _repository.InsertAsync(dao) : _repository.UpdateAsync(dao);
        }

        public Task<ActionResult> DeleteAsync(int id, bool permanently = false)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<ActionResult<ClientPaymentNoteEntity>> GetMonthlyClientPaymentNote(string clientCode, DateTime firstDate, DateTime lastDate)
        {
            var result = await _repository.GetMonthlyClientPaymentNote(clientCode, firstDate, lastDate);
            if (result.IsFailed)
                return ActionResult<ClientPaymentNoteEntity>.Failed(result.Exception);

            var entity = (ClientPaymentNoteEntity)result.Data?.ToEntity();

            return ActionResult<ClientPaymentNoteEntity>.Succeed(entity);
        }
    }
}
