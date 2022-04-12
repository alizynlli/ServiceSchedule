using NBA.ServiceSchedule.Core.Models.Entities;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Services
{
    public interface IUserService : IServiceBase<UserEntity>
    {
        Task<ActionResult> MarkAsAdministrator(string userName);
        Task<ActionResult<UserEntity>> FindUserByUserNameAndPassword(string userName, string password);
    }
}
