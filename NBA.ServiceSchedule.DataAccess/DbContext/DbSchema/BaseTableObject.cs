using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.DbContext;
using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System.Threading.Tasks;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.ServiceScheduleSchema;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema
{
    public abstract class BaseTableObject : ITableObject
    {
        public abstract string Name { get; }

        public const string Id = nameof(BaseDao.Id);
        public const string CreatorUserId = nameof(BaseDao.CreatorUserId);
        public const string CreateDate = nameof(BaseDao.CreateDate);
        public const string IsDeleted = nameof(BaseDao.IsDeleted);

        public string GetCreateQuery()
        {
            var query = $"USE [{GlobalParameters.DatabaseName}];\n" + CreateTableQuery;
            //Add constraints query here

            return query;
        }

        public string DropQuery => $"DROP TABLE IF EXISTS [{SchemaName}].[{Name}]";

        protected virtual string GetColumnsQuery()
        {
            return $"[{Id}] INT IDENTITY(1,1) NOT NULL,\n" +
                   $"[{CreatorUserId}] [BIGINT],\n" +
                   $"[{CreateDate}] [DATETIME] NOT NULL DEFAULT(GETDATE()),\n" +
                   $"[{IsDeleted}] [BIT] NOT NULL DEFAULT(0),\n";
        }

        private string CreateTableQuery =>
            $"\nCREATE TABLE [{SchemaName}].[{Name}]" +
            $"\n({GetColumnsQuery()}\n)";

        public abstract Task<ActionResult> InsertDefaultValues();
    }
}
