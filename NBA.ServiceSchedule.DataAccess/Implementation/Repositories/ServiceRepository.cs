using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.BaseTableObject;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.ServiceScheduleSchema;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables.ServiceTableObject;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        public async Task<ActionResult<IEnumerable<ServiceDao>>> GetAllAsync()
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT [{Id}], [{Code}], [{ServiceName}], [{MonthlyPaymentAmount}], [{DailyPaymentAmount}] FROM [{SchemaName}].[{TableName}]";
                    var services = (await connection.QueryAsync<ServiceDao>(query));

                    return ActionResult<IEnumerable<ServiceDao>>.Succeed(services);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<ServiceDao>>.Failed(exception);
            }
        }

        public async Task<ActionResult> InsertAsync(ServiceDao dao)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"INSERT INTO [{SchemaName}].[{TableName}] ([{CreatorUserId}], [{CreateDate}], [{IsDeleted}], [{Code}], [{ServiceName}], [{MonthlyPaymentAmount}], [{DailyPaymentAmount}])" +
                                $"\nVALUES(@{CreatorUserId}, GETDATE(), 0, @{Code}, @{ServiceName}, @{MonthlyPaymentAmount}, @{DailyPaymentAmount})";
                    await connection.ExecuteAsync(query, new { dao.CreatorUserId, dao.Code, dao.ServiceName, dao.MonthlyPaymentAmount, dao.DailyPaymentAmount });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult> UpdateAsync(ServiceDao dao)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"UPDATE [{SchemaName}].[{TableName}] SET [{Code}] = @{Code}, [{ServiceName}] = @{ServiceName}, [{MonthlyPaymentAmount}] = @{MonthlyPaymentAmount}, [{DailyPaymentAmount}] = @{DailyPaymentAmount} WHERE [{Id}] = @{Id}";
                    await connection.ExecuteAsync(query, new { dao.Id, dao.Code, dao.ServiceName, dao.MonthlyPaymentAmount, dao.DailyPaymentAmount });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"DELETE FROM [{SchemaName}].[{TableName}] WHERE [{Id}] = {id};";
                    await connection.ExecuteAsync(query);

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult> InsertManyAsync(params ServiceDao[] daoArray)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"INSERT INTO [{SchemaName}].[{TableName}] ([{CreatorUserId}], [{CreateDate}], [{IsDeleted}], [{Code}], [{ServiceName}], [{MonthlyPaymentAmount}], [{DailyPaymentAmount}])" +
                                $"\nVALUES(@{CreatorUserId}, GETDATE(), 0, @{Code}, @{ServiceName}, @{MonthlyPaymentAmount}, @{DailyPaymentAmount})";
                    await connection.ExecuteAsync(query, daoArray.Select(dao => new { dao.CreatorUserId, dao.Code, dao.ServiceName, dao.MonthlyPaymentAmount, dao.DailyPaymentAmount }));

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult<ServiceDao>> GetByCode(string code)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT [{Id}], [{Code}], [{ServiceName}], [{MonthlyPaymentAmount}], [{DailyPaymentAmount}] FROM [{SchemaName}].[{TableName}] WHERE [{Code}] = @{Code}";
                    var service = (await connection.QueryAsync<ServiceDao>(query, new { Code = code })).FirstOrDefault();

                    return ActionResult<ServiceDao>.Succeed(service);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<ServiceDao>.Failed(exception);
            }
        }
    }
}
