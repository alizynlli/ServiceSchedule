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
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables.ClientPaymentNoteTableObject;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class ClientPaymentNoteRepository : IClientPaymentNoteRepository
    {
        public async Task<ActionResult<IEnumerable<ClientPaymentNoteDao>>> GetAllAsync()
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT CPN.*, C.cari_unvan1 as ClientName FROM [{SchemaName}].[{TableName}] as CPN\n" +
                                $"INNER JOIN CARI_HESAPLAR C ON cari_kod = CPN.[{ClientCode}]" +
                                $"WHERE [{IsDeleted}] = 0";
                    var services = await connection.QueryAsync<ClientPaymentNoteDao>(query);

                    return ActionResult<IEnumerable<ClientPaymentNoteDao>>.Succeed(services);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<ClientPaymentNoteDao>>.Failed(exception);
            }
        }

        public async Task<ActionResult> InsertAsync(ClientPaymentNoteDao dao)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"INSERT INTO [{SchemaName}].[{TableName}] ([{CreatorUserId}], [{ClientCode}], [{FirstDate}], [{LastDate}])" +
                                $"\nVALUES(@{CreatorUserId}, @{ClientCode}, @{FirstDate}, @{LastDate})";
                    await connection.ExecuteAsync(query, new { dao.CreatorUserId, dao.ClientCode, dao.FirstDate, dao.LastDate });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult> UpdateAsync(ClientPaymentNoteDao dao)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"UPDATE [{SchemaName}].[{TableName}] SET [{ClientCode}] = @{ClientCode}, [{FirstDate}] = @{FirstDate}, [{LastDate}] = @{LastDate} WHERE [{Id}] = @{Id}";
                    await connection.ExecuteAsync(query, new { dao.Id, dao.ClientCode, dao.FirstDate, dao.LastDate });

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

        public async Task<ActionResult<ClientPaymentNoteDao>> GetMonthlyClientPaymentNote(string clientCode, DateTime firstDate, DateTime lastDate)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT Top 1 * FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 AND [{ClientCode}] =@{ClientCode} AND [{FirstDate}] <= @FirstDate AND [{LastDate}] >= @LastDate";
                    var note = (await connection.QueryAsync<ClientPaymentNoteDao>(query, new { ClientCode = clientCode, FirstDate = firstDate, LastDate = lastDate })).FirstOrDefault();

                    return ActionResult<ClientPaymentNoteDao>.Succeed(note ?? new ClientPaymentNoteDao());
                }
            }
            catch (Exception exception)
            {
                return ActionResult<ClientPaymentNoteDao>.Failed(exception);
            }
        }
    }
}
