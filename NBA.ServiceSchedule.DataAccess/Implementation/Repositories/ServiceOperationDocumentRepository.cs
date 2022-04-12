using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Report;
using NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Functions;
using NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.BaseTableObject;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.ServiceScheduleSchema;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables.ServiceOperationDocumentTableObject;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class ServiceOperationDocumentRepository : IServiceOperationDocumentRepository
    {
        [Obsolete("Don't use it")]
        public async Task<ActionResult<IEnumerable<ServiceOperationDocumentDao>>> GetAllAsync()
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"SELECT [{SchemaName}].[{TableName}].*, [{ServiceTableObject.ServiceName}], cari_unvan1 as [ClientName] FROM [{SchemaName}].[{TableName}]
                                INNER JOIN [{SchemaName}].[{ServiceTableObject.TableName}] ON [{ServiceCode}] = [{ServiceTableObject.Code}] 
                                INNER JOIN CARI_HESAPLAR ON [{ClientCode}] = [cari_kod] 
                                WHERE [{SchemaName}].[{TableName}].[{IsDeleted}] = 0
                                ORDER BY [{Date}], [{Series}], [{Number}]";

                    var daoList = await connection.QueryAsync<ServiceOperationDocumentDao>(query);

                    return ActionResult<IEnumerable<ServiceOperationDocumentDao>>.Succeed(daoList);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<ServiceOperationDocumentDao>>.Failed(exception);
            }
        }

        [Obsolete("Don't use it")]
        public Task<ActionResult> InsertAsync(ServiceOperationDocumentDao dao)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Don't use it")]
        public Task<ActionResult> UpdateAsync(ServiceOperationDocumentDao dao)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Don't use it")]
        public Task<ActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        private SqlQueryModel GetUpdateQuery(ServiceOperationDocumentDao[] documents)
        {
            if (!documents.Any()) return null;

            var query = $@"UPDATE [{SchemaName}].[{TableName}] SET
                        [{Date}] = @{Date}, [{DocumentNumber}] = @{DocumentNumber},
                        [{DocumentDate}] = @{DocumentDate}, [{ClientCode}] = @{ClientCode},
                        [{ServiceCode}] = @{ServiceCode}, [{Count}] = @{Count}, [{ServiceOperationType}] = @{ServiceOperationType}
                        WHERE [{Id}] = @{Id}";

            var parameters = documents.Select(dao => new
            {
                dao.Id,
                dao.Date,
                dao.DocumentNumber,
                dao.DocumentDate,
                dao.ClientCode,
                dao.ServiceCode,
                dao.Count,
                dao.ServiceOperationType
            });

            return new SqlQueryModel(query, parameters);
        }

        private SqlQueryModel GetDeleteBySeriesAndNumberQuery(int[] idArray, string series, int number)
        {
            if (!idArray.Any())
            {
                idArray = new[] { 0 };
            }

            var idCondition = string.Join(", ", idArray);
            var query = $"DELETE FROM [{SchemaName}].[{TableName}] WHERE [{Series}] = @{Series} AND [{Number}] = @{Number} AND [{Id}] NOT IN({idCondition})";

            var parameters = new
            {
                Series = series,
                Number = number
            };

            return new SqlQueryModel(query, parameters);
        }

        private SqlQueryModel GetInsertQuery(ServiceOperationDocumentDao[] documents)
        {
            var query = $@"INSERT INTO [{SchemaName}].[{TableName}]
                        ([{CreatorUserId}], [{CreateDate}], [{Series}], [{Number}], [{Date}], [{DocumentNumber}], [{DocumentDate}], [{ClientCode}], [{ServiceCode}], [{Count}], [{ServiceOperationType}])
                        VALUES(@{CreatorUserId}, GETDATE(), @{Series}, @{Number}, @{Date}, @{DocumentNumber}, @{DocumentDate}, @{ClientCode}, @{ServiceCode}, @{Count}, @{ServiceOperationType})";

            var parameters = documents.Select(dao => new
            {
                dao.CreatorUserId,
                dao.Series,
                dao.Number,
                dao.Date,
                dao.DocumentNumber,
                dao.DocumentDate,
                dao.ClientCode,
                dao.ServiceCode,
                dao.Count,
                dao.ServiceOperationType
            });

            return new SqlQueryModel(query, parameters);
        }

        public async Task<ActionResult<IEnumerable<ClientServiceCubeReportModel>>> GetCubeReport(DateTime? firstDate = null, DateTime? lastDate = null, List<string> clientCodeList = null,
            List<string> serviceCodeList = null)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var clientsFilter = string.Empty;

                    if (clientCodeList != null && clientCodeList.Any())
                        clientsFilter = $" and cari_kod in ('{string.Join("', '", clientCodeList)}')";

                    var servicesFilter = string.Empty;

                    if (serviceCodeList != null && serviceCodeList.Any())
                        servicesFilter = $" and S.[Code] in ('{string.Join("', '", serviceCodeList)}')";

                    var query = $@"
                        SELECT 
                        SOD.Series, 
                        SOD.Number,
                        SOD.Date,
                        SOD.DocumentNumber,
                        SOD.DocumentDate,
                        U.FirstName + ' ' + U.LastName as [CreatorUser],
                        cari_kod as [ClientCode],
                        cari_unvan1 as [ClientName],
                        crg_isim as [ClientGroupName],
                        S.Code as [ServiceCode],
                        [ServiceName],
                        CASE WHEN SOD.[ServiceOperationType] = 0 THEN SOD.[Count] ELSE 0 END AS [InstallationCount],
                        CASE WHEN SOD.[ServiceOperationType] = 1 THEN SOD.[Count] ELSE 0 END AS [CancellationCount]
                        FROM CARI_HESAPLAR CH
                        LEFT JOIN CARI_HESAP_GRUPLARI on CH.cari_grup_kodu = crg_kod
                        LEFT JOIN [ss].[Services] S ON 1=1
                        LEFT JOIN [ss].[ServiceOperationDocuments] SOD ON [ClientCode] = CH.[cari_kod] and SOD.[IsDeleted] = 0 and [Date] between @FirstDate and @LastDate and SOD.[ServiceCode] = S.[Code]
                        LEFT JOIN [ss].[Users] U ON SOD.[CreatorUserId] = U.[Id]
                        WHERE 1=1 {clientsFilter} {servicesFilter}
                        ORDER BY [Date], [Series], [Number], [ClientCode], [ServiceCode]";

                    var daoList = await connection.QueryAsync<ClientServiceCubeReportModel>(query, new { FirstDate = firstDate, LastDate = lastDate });

                    return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Succeed(daoList);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(exception);
            }
        }

        public async Task<ActionResult<IEnumerable<ClientServiceDocumentReportModel>>> GetDocumentReport(DateTime? firstDate = null, DateTime? lastDate = null, List<string> clientCodeList = null,
            List<string> serviceCodeList = null)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var clientsFilter = string.Empty;

                    if (clientCodeList != null && clientCodeList.Any())
                        clientsFilter = $" and cari_kod in ('{string.Join("', '", clientCodeList)}')";

                    var servicesFilter = string.Empty;

                    if (serviceCodeList != null && serviceCodeList.Any())
                        servicesFilter = $" and S.[Code] in ('{string.Join("', '", serviceCodeList)}')";

                    var query = $@"
                        SELECT 
                        SOD.Series, 
                        SOD.Number,
                        SOD.Date,
                        SOD.DocumentNumber,
                        SOD.DocumentDate,
                        U.FirstName + ' ' + U.LastName as [CreatorUser],
                        cari_kod as [ClientCode],
                        cari_unvan1 as [ClientName],
                        crg_isim as [ClientGroupName],
                        S.Code as [ServiceCode],
                        [ServiceName],
                        CASE WHEN SOD.[ServiceOperationType] = 0 THEN SOD.[Count] ELSE 0 END AS [InstallationCount],
                        CASE WHEN SOD.[ServiceOperationType] = 1 THEN SOD.[Count] ELSE 0 END AS [CancellationCount]
                        FROM [ss].[ServiceOperationDocuments] as SOD
                        INNER JOIN [ss].[Services] as S ON [ServiceCode] = [Code] 
                        INNER JOIN CARI_HESAPLAR as CH ON [ClientCode] = [cari_kod] 
                        LEFT JOIN CARI_HESAP_GRUPLARI on CH.cari_grup_kodu = crg_kod
                        LEFT JOIN [ss].[Users] U ON SOD.[CreatorUserId] = U.[Id]
                        WHERE [SOD].[IsDeleted] = 0 and [SOD].[Date] between @FirstDate and @LastDate {clientsFilter} {servicesFilter}
                        ORDER BY [SOD].[Date], [SOD].[Series], [SOD].[Number]";

                    var daoList = await connection.QueryAsync<ClientServiceDocumentReportModel>(query, new { FirstDate = firstDate, LastDate = lastDate });

                    return ActionResult<IEnumerable<ClientServiceDocumentReportModel>>.Succeed(daoList);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<ClientServiceDocumentReportModel>>.Failed(exception);
            }
        }

        public Task<ActionResult> SaveDocumentsAsync(List<ServiceOperationDocumentDao> daoList)
        {
            return SqlHelper.ExecuteInTransaction(
                GetUpdateQuery(daoList.Where(c => c.Id != 0).ToArray()),
                GetDeleteBySeriesAndNumberQuery(daoList.Where(c => c.Id != 0).Select(c => c.Id).ToArray(), daoList[0].Series, daoList[0].Number),
                GetInsertQuery(daoList.Where(c => c.Id == 0).ToArray()));
        }

        public async Task<ActionResult> DeleteAsync(IList<int> idList)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"DELETE FROM [{SchemaName}].[{TableName}] WHERE [{Id}] IN ({string.Join(", ", idList)})";
                    await connection.ExecuteAsync(query);
                    return ActionResult.Succeed();
                }
            }
            catch (Exception e)
            {
                return ActionResult.Failed(e);
            }
        }

        public async Task<ActionResult<int>> GetNewNumberBySeries(string series)
        {
            try
            {
                using (var con = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT MAX([{Number}]) FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 AND [{Series}] = @{Series};";
                    var res = await con.ExecuteScalarAsync<int?>(query, new { Series = series }) ?? 0;

                    return ActionResult<int>.Succeed(res + 1);
                }
            }
            catch (Exception e)
            {
                return ActionResult<int>.Failed(e);
            }
        }

        public async Task<ActionResult<int>> GetPreviousNumberBySeries(string series, int number)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"SELECT ISNULL(MAX([{Number}]), 0) FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 AND [{Series}] = @{Series} and [{Number}] < @{Number}";
                    var previousDocumentNumber = await connection.ExecuteScalarAsync<int>(query, new { Series = series, Number = number });

                    return ActionResult<int>.Succeed(previousDocumentNumber);
                }
            }
            catch (Exception e)
            {
                return ActionResult<int>.Failed(e);
            }
        }

        public async Task<ActionResult<int>> GetNextNumberBySeries(string series, int number)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"SELECT ISNULL(MIN([{Number}]), 0) FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 AND [{Series}] = @{Series} and [{Number}] > @{Number}";
                    var nextDocumentNumber = await connection.ExecuteScalarAsync<int>(query, new { Series = series, Number = number });

                    return ActionResult<int>.Succeed(nextDocumentNumber);
                }
            }
            catch (Exception e)
            {
                return ActionResult<int>.Failed(e);
            }
        }

        public async Task<ActionResult<int>> GetClientServiceCount(string clientCode, string serviceCode, DateTime lastDate)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT [{SchemaName}].fn_GetClientServiceCount(@ClientCode, @ServiceCode, @LastDate)";
                    var count = await connection.ExecuteScalarAsync<int>(query,
                        new { ClientCode = clientCode, ServiceCode = serviceCode, LastDate = lastDate });

                    return ActionResult<int>.Succeed(count);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<int>.Failed(exception);
            }
        }

        public async Task<ActionResult<IEnumerable<ClientServiceCountDao>>> GetAllClientServicesCount(DateTime lastDate, List<string> clientCodeList = null, List<string> serviceCodeList = null)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var clientsFilter = string.Empty;

                    if (clientCodeList != null && clientCodeList.Any())
                        clientsFilter = $" and cari_kod in ('{string.Join("', '", clientCodeList)}')";

                    var servicesFilter = string.Empty;

                    if (serviceCodeList != null && serviceCodeList.Any())
                        servicesFilter = $" and [Code] in ('{string.Join("', '", serviceCodeList)}')";

                    var query = $@"select cari_kod as [ClientCode], [Code] as [ServiceCode], 
                                   [{SchemaName}].{GetClientServiceCountFunctionObject.FunctionName}(cari_kod, [{ServiceTableObject.Code}], @LastDate) as [Count]
                                   from CARI_HESAPLAR JOIN [ss].Services on 1=1
                                   where 1=1 {clientsFilter} {servicesFilter}";

                    var daoList = await connection.QueryAsync<ClientServiceCountDao>(query, new { LastDate = lastDate });

                    return ActionResult<IEnumerable<ClientServiceCountDao>>.Succeed(daoList);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<ClientServiceCountDao>>.Failed(exception);
            }
        }

        public async Task<ActionResult<List<ServiceOperationDocumentDao>>> GetBySeriesAndNumber(string series, int number)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"SELECT [{SchemaName}].[{TableName}].*, [{ServiceTableObject.ServiceName}], cari_unvan1 as [ClientName] FROM [{SchemaName}].[{TableName}]
                                INNER JOIN [{SchemaName}].[{ServiceTableObject.TableName}] ON [{ServiceCode}] = [{ServiceTableObject.Code}] 
                                INNER JOIN CARI_HESAPLAR ON [{ClientCode}] = [cari_kod] 
                                WHERE [{SchemaName}].[{TableName}].[{IsDeleted}] = 0 AND [{Series}] = @series AND [{Number}] = @number";

                    var daoList = (await connection.QueryAsync<ServiceOperationDocumentDao>(query, new { Series = series, Number = number })).ToList();

                    return ActionResult<List<ServiceOperationDocumentDao>>.Succeed(daoList);
                }
            }
            catch (Exception e)
            {
                return ActionResult<List<ServiceOperationDocumentDao>>.Failed(e);
            }
        }

        public async Task<ActionResult<int>> GetActiveServiceCount(string serviceCode, string clientCode, DateTime date)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"SELECT ISNULL(SUM(
	                                   CASE WHEN [{ServiceOperationType}] = 0 THEN [{Count}] 
		                                    WHEN [{ServiceOperationType}] = 1 THEN -[{Count}] 
		                                    ELSE 0 END), 0) 
                                   FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 and [{ClientCode}] = @{ClientCode} and [{ServiceCode}] = @{ServiceCode} and [{Date}] < @{Date}";

                    var service = await connection.ExecuteScalarAsync<int>(query, new { ServiceCode = serviceCode, ClientCode = clientCode, Date = date });

                    return ActionResult<int>.Succeed(service);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<int>.Failed(exception);
            }
        }

        public async Task<ActionResult<List<ServiceOperationDocumentDao>>> GetClientDocuments(string clientCode, DateTime firstDate, DateTime lastDate)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"SELECT * FROM [{SchemaName}].[{TableName}]
                                WHERE [{SchemaName}].[{TableName}].[{IsDeleted}] = 0 AND [{ClientCode}] = @{ClientCode} AND [{Date}] BETWEEN @FirstDate and @LastDate";

                    var daoList = (await connection.QueryAsync<ServiceOperationDocumentDao>(query, new { ClientCode = clientCode, FirstDate = firstDate, LastDate = lastDate })).ToList();

                    return ActionResult<List<ServiceOperationDocumentDao>>.Succeed(daoList);
                }
            }
            catch (Exception e)
            {
                return ActionResult<List<ServiceOperationDocumentDao>>.Failed(e);
            }
        }

        public async Task<ActionResult<List<ServiceOperationDocumentDao>>> GetAllDocuments(DateTime firstDate, DateTime lastDate, List<string> clientCodeList = null, List<string> serviceCodeList = null)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var clientsFilter = string.Empty;

                    if (clientCodeList != null && clientCodeList.Any())
                        clientsFilter = $" and [{ClientCode}] in ('{string.Join("', '", clientCodeList)}')";

                    var servicesFilter = string.Empty;

                    if (serviceCodeList != null && serviceCodeList.Any())
                        servicesFilter = $" and [{ServiceCode}] in ('{string.Join("', '", serviceCodeList)}')";

                    var query = $@"SELECT * FROM [{SchemaName}].[{TableName}]
                                WHERE [{SchemaName}].[{TableName}].[{IsDeleted}] = 0 AND [{Date}] BETWEEN @FirstDate and @LastDate {clientsFilter} {servicesFilter}";

                    var daoList = (await connection.QueryAsync<ServiceOperationDocumentDao>(query, new { FirstDate = firstDate, LastDate = lastDate })).ToList();

                    return ActionResult<List<ServiceOperationDocumentDao>>.Succeed(daoList);
                }
            }
            catch (Exception e)
            {
                return ActionResult<List<ServiceOperationDocumentDao>>.Failed(e);
            }
        }
    }
}
