using NBA.ServiceSchedule.Core.Models.DAOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Repositories
{
    public interface IRepositoryBase<TDao> where TDao:BaseDao
    {
        Task<ActionResult<IEnumerable<TDao>>> GetAllAsync();
        Task<ActionResult> InsertAsync(TDao dao);
        Task<ActionResult> UpdateAsync(TDao dao);
        Task<ActionResult> DeleteAsync(int id);
    }
}
