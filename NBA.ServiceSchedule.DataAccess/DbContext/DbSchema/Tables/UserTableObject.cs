using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.DataAccess.Implementation;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables
{
    public class UserTableObject : BaseTableObject
    {
        public override string Name { get; } = TableName;
        public const string TableName = "Users";

        public const string FirstName = nameof(UserDao.FirstName);
        public const string LastName = nameof(UserDao.LastName);
        public const string UserName = nameof(UserDao.UserName);
        public const string Password = nameof(UserDao.Password);
        public const string IsSupervisor = nameof(UserDao.IsSupervisor);

        protected override string GetColumnsQuery()
        {
            return base.GetColumnsQuery() +
                   $"[{FirstName}] nvarchar(50) not null,\n" +
                   $"[{LastName}] nvarchar(50) not null,\n" +
                   $"[{UserName}] varchar(50) not null unique,\n" +
                   $"[{Password}] char(64) not null,\n" +
                   $"[{IsSupervisor}] bit not null default(0)\n";
        }

        public override async Task<ActionResult> InsertDefaultValues()
        {
            var dao = new UserDao
            {
                FirstName = "Supervisor",
                LastName = string.Empty,
                UserName = "srv",
                Password = string.Empty.GetHashValue()
            };

            var insertResult = await RepositoryContainer.UserRepository.InsertAsync(dao);
            if (insertResult.IsFailed)
                return insertResult;

            return await RepositoryContainer.UserRepository.MarkAsAdministrator(dao.UserName);
        }
    }
}
