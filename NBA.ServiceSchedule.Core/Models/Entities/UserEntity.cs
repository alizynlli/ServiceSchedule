using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Models.DAOs;

namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSupervisor { get; set; }

        public override BaseDao ToDao()
        {
            return new UserDao
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password.GetHashValue(),
                IsSupervisor = IsSupervisor
            }.SetBase(this);
        }
    }
}
