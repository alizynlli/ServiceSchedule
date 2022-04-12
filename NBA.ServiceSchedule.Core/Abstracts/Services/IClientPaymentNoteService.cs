using NBA.ServiceSchedule.Core.Models.Entities;
using System;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Services
{
    public interface IClientPaymentNoteService : IServiceBase<ClientPaymentNoteEntity>
    {
        Task<ActionResult<ClientPaymentNoteEntity>> GetMonthlyClientPaymentNote(string clientCode, DateTime firstDate, DateTime lastDate);
    }
}
