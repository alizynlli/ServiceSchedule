using NBA.ServiceSchedule.Core.Models.Entities;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public class PermissionDao : BaseDao
    {
        public string PermissionKey { get; set; }
        public int UserId { get; set; }

        public override BaseEntity ToEntity()
        {
            return new PermissionEntity
            {
                PermissionKey = PermissionKey,
                UserId = UserId
            }.SetBase(this);
        }
    }
}
