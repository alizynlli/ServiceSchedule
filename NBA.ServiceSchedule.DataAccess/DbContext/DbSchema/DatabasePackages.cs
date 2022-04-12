using NBA.ServiceSchedule.Core.Abstracts.DbContext;
using NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Functions;
using NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Procedures;
using NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables;
using System.Collections.Generic;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema
{
    public static class DatabasePackages
    {
        public static IEnumerable<IDatabaseObject> GetAllObjects()
        {
            var list = new List<IDatabaseObject> { new ServiceScheduleSchema() };
            list.AddRange(GetAllTables());
            list.AddRange(GetAllProcedures());
            list.AddRange(GetAllFunctions());

            return list;
        }

        public static IEnumerable<ITableObject> GetAllTables()
        {
            yield return new ServiceTableObject();
            yield return new ServiceOperationDocumentTableObject();
            yield return new UserTableObject();
            yield return new PermissionTableObject();
            yield return new ClientPaymentNoteTableObject();
        }

        private static IEnumerable<IProcedureObject> GetAllProcedures()
        {
            yield return new InsertClientAccountOperationProcedureObject();
        }

        private static IEnumerable<IFunctionObject> GetAllFunctions()
        {
            yield return new GetClientServiceCountFunctionObject();
        }
    }
}
