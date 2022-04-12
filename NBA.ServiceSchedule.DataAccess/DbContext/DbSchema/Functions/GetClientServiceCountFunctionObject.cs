using NBA.ServiceSchedule.Core.Abstracts.DbContext;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.BaseTableObject;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.ServiceScheduleSchema;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables.ServiceOperationDocumentTableObject;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Functions
{
    public class GetClientServiceCountFunctionObject : IFunctionObject
    {
        public string Name { get; } = FunctionName;
        public const string FunctionName = "fn_GetClientServiceCount";
        public string GetCreateQuery()
        {
            return $@"CREATE FUNCTION [{SchemaName}].[{FunctionName}](@ClientCode nvarchar(25), @ServiceCode nvarchar(25), @LastDate datetime)
                      RETURNS INT
                      AS
                      BEGIN
	                      DECLARE @Count int = 0;
	                      SELECT @Count += (CASE WHEN [{ServiceOperationType}] = 0 THEN [{Count}]
						                         WHEN [{ServiceOperationType}] = 1 THEN (-1) * [{Count}] END)
	                      FROM [{SchemaName}].[{TableName}]
	                      WHERE [{IsDeleted}] = 0 and [{ClientCode}] = @ClientCode and [{ServiceCode}] = @ServiceCode and [{Date}] <= @LastDate

	                      RETURN @Count;
                      END";
        }

        public string DropQuery => $"DROP FUNCTION IF EXISTS [{SchemaName}].[{FunctionName}]";
    }
}
