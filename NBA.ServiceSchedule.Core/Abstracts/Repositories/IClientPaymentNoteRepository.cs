using NBA.ServiceSchedule.Core.Models.DAOs;
using System;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Repositories
{
    public interface IClientPaymentNoteRepository : IRepositoryBase<ClientPaymentNoteDao>
    {
        Task<ActionResult<ClientPaymentNoteDao>> GetMonthlyClientPaymentNote(string clientCode, DateTime firstDate, DateTime lastDate);
    }
}
