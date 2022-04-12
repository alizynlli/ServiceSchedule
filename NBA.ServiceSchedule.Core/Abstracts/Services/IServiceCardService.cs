using NBA.ServiceSchedule.Core.Models.Entities;
using System;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Services
{
    public interface IServiceCardService : IServiceBase<ServiceEntity>
    {
        Task<ActionResult<ServiceEntity>> GetByCode(string code);
    }
}
