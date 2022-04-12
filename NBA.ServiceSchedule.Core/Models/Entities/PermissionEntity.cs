using NBA.ServiceSchedule.Core.Models.DAOs;

namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public class PermissionEntity : BaseEntity
    {
        public string PermissionKey { get; set; }
        public int UserId { get; set; }

        public override BaseDao ToDao()
        {
            return new PermissionDao
            {
                PermissionKey = PermissionKey,
                UserId = UserId
            }.SetBase(this);
        }
    }
}
