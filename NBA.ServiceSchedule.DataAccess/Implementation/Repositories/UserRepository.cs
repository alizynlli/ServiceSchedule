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
using static NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables.UserTableObject;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<ActionResult<IEnumerable<UserDao>>> GetAllAsync()
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT * FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0";
                    var daoList = await connection.QueryAsync<UserDao>(query);

                    return ActionResult<IEnumerable<UserDao>>.Succeed(daoList);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<IEnumerable<UserDao>>.Failed(exception);
            }
        }

        public async Task<ActionResult> InsertAsync(UserDao dao)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"INSERT INTO [{SchemaName}].[{TableName}]([{CreatorUserId}], [{FirstName}], [{LastName}], [{UserName}], [{Password}])\n" +
                                "VALUES(@CreatorUserId, @FirstName, @LastName, @Username, @Password)";

                    await connection.ExecuteAsync(query, new { dao.CreatorUserId, dao.FirstName, dao.LastName, dao.UserName, dao.Password });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult> UpdateAsync(UserDao dao)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"UPDATE [{SchemaName}].[{TableName}] SET " +
                                $"[{FirstName}] = @FirstName, [{LastName}] = @LastName, " +
                                $"[{UserName}] = @UserName, [{Password}] = @Password " +
                                $"WHERE [{Id}] = @Id";

                    await connection.ExecuteAsync(query, dao);

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
                    var query = $"DELETE FROM [{SchemaName}].[{TableName}] " +
                                $"WHERE [{Id}] = @Id";

                    await connection.ExecuteAsync(query, new { Id = id });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult<UserDao>> GetById(int userId)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT * FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 and [{Id}] = @Id";
                    var dao = (await connection.QueryAsync<UserDao>(query, new { Id = userId })).FirstOrDefault();

                    return ActionResult<UserDao>.Succeed(dao);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<UserDao>.Failed(exception);
            }
        }

        public async Task<ActionResult> MarkAsAdministrator(string userName)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"UPDATE [{SchemaName}].[{TableName}] SET " +
                                $"[{IsSupervisor}] = 1 " +
                                $"WHERE [{UserName}] = @UserName";

                    await connection.ExecuteAsync(query, new { UserName = userName });

                    return ActionResult.Succeed();
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }

        public async Task<ActionResult<UserDao>> FindUserByUserNameAndPassword(string userName, string passwordHash)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT * FROM [{SchemaName}].[{TableName}] WHERE [{IsDeleted}] = 0 and [{UserName}] = @UserName and [{Password}] = @Password";
                    var dao = (await connection.QueryAsync<UserDao>(query, new { UserName = userName, Password = passwordHash })).FirstOrDefault();

                    return ActionResult<UserDao>.Succeed(dao);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<UserDao>.Failed(exception);
            }
        }
    }
}
