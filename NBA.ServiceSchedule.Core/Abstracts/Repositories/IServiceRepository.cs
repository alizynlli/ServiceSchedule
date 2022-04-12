using NBA.ServiceSchedule.Core.Models.DAOs;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Repositories
{
    public interface IServiceRepository : IRepositoryBase<ServiceDao>
    {
        Task<ActionResult> InsertManyAsync(params ServiceDao[] daoArray);
        Task<ActionResult<ServiceDao>> GetByCode(string code);
    }
}
