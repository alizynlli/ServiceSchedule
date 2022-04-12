using NBA.ServiceSchedule.Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Services
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<ActionResult> SaveAsync(TEntity entity);
        Task<ActionResult> DeleteAsync(int id, bool permanently = false);
    }
}
