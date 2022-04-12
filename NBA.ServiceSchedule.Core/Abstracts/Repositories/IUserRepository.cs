using NBA.ServiceSchedule.Core.Models.DAOs;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<UserDao>
    {
        Task<ActionResult<UserDao>> GetById(int userId);
        Task<ActionResult> MarkAsAdministrator(string userName);
        Task<ActionResult<UserDao>> FindUserByUserNameAndPassword(string userName, string passwordHash);
    }
}
