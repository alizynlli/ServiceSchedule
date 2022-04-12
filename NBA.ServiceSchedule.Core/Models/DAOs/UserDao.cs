using NBA.ServiceSchedule.Core.Models.Entities;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public class UserDao : BaseDao
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSupervisor { get; set; }

        public override BaseEntity ToEntity()
        {
            return new UserEntity
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password,
                IsSupervisor = IsSupervisor
            }.SetBase(this);
        }
    }
}
