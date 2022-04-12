using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.BaseTableObject;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.ServiceScheduleSchema;
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables.PermissionTableObject;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class PermissionRepository
    {
        public async Task<ActionResult<IEnumerable<PermissionDao>>> GetByUserAsync(int userId)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT * FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 and [{UserId}] = @UserId";
                    var permissions = await connection.QueryAsync<PermissionDao>(query, new { UserId = userId });

                    return ActionResult<IEnumerable<PermissionDao>>.Succeed(permissions);
                }
            }
            catch (Exception e)
            {
                return ActionResult<IEnumerable<PermissionDao>>.Failed(e);
            }
        }

        public async Task<ActionResult> InsertAllAsync(IEnumerable<PermissionDao> daoList)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"INSERT INTO [{SchemaName}].[{TableName}]([{CreatorUserId}], [{PermissionKey}], [{UserId}])\n" +
                                "VALUES(@CreatorUserId, @PermissionKey, @UserId)";

                    await connection.ExecuteAsync(query, daoList.Select(dao => new { dao.CreatorUserId, dao.PermissionKey, dao.UserId }));
                    return ActionResult.Succeed();
                }
            }
            catch (Exception e)
            {
                return ActionResult.Failed(e);
            }
        }

        public async Task<ActionResult> DeleteUserPermissionsAsync(int userId)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"DELETE FROM [{SchemaName}].[{TableName}] WHERE [{UserId}] = @UserId";
                    await connection.ExecuteAsync(query, new { UserId = userId });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception e)
            {
                return ActionResult.Failed(e);
            }
        }
    }
}
