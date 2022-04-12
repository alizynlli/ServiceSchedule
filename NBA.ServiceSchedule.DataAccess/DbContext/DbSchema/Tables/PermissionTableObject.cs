using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables
{
    public class PermissionTableObject : BaseTableObject
    {
        public override string Name { get; } = TableName;
        public const string TableName = "Permissions";

        public const string PermissionKey = nameof(PermissionDao.PermissionKey);
        public const string UserId = nameof(PermissionDao.UserId);

        protected override string GetColumnsQuery()
        {
            return base.GetColumnsQuery() +
                   $"[{PermissionKey}] nvarchar(100) not null,\n" +
                   $"[{UserId}] int not null\n";
        }

        public override Task<ActionResult> InsertDefaultValues()
        {
            return Task.FromResult(ActionResult.Succeed());
        }
    }
}
