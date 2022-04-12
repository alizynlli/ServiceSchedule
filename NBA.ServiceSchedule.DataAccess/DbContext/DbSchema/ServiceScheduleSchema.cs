using NBA.ServiceSchedule.Core.Abstracts.DbContext;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema
{
    public class ServiceScheduleSchema : IDatabaseObject
    {
        public string Name => SchemaName;
        public const string SchemaName = "ss";

        public string GetCreateQuery() =>
            $"CREATE SCHEMA {SchemaName};";

        public string DropQuery => $"DROP SCHEMA IF EXISTS [{SchemaName}]";
    }
}
