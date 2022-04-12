using NBA.ServiceSchedule.Core.Models.Entities;

namespace NBA.ServiceSchedule.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSupervisor { get; set; }

        public UserEntity ToEntity()
        {
            return new UserEntity
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password
            };
        }

        public static UserDto FromEntity(UserEntity entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = string.Empty,
                IsSupervisor = entity.IsSupervisor
            };
        }
    }
}
