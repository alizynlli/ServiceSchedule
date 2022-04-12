using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Global;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess
{
    public static class SqlHelper
    {
        public static IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(GlobalParameters.ConnectionString);
            connection.Open();
            return connection;
        }

        public static Task<ActionResult<bool>> TestConnection(string connectionString, string database)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        const string query = @"use master; declare @mikro_db_exists BIT=0; SELECT @mikro_db_exists=1 FROM master.dbo.sysdatabases where name=@Database select @mikro_db_exists;";
                        var parameters = new { Database = database };
                        var result = con.Query<int>(query, parameters).FirstOrDefault();

                        return ActionResult<bool>.Succeed(result != 0);
                    }
                }
                catch (Exception e)
                {
                    return ActionResult<bool>.Failed(e);
                }
            });
        }

        public static Task<ActionResult> ExecuteInTransaction(params SqlQueryModel[] queryModels)
        {
            return Task.Run(() =>
            {
                using (var con = CreateConnection())
                using (var transaction = con.BeginTransaction())
                    try
                    {
                        foreach (var model in queryModels)
                        {
                            if (model != null && !model.Query.IsNullOrEmpty())
                                con.Execute(model.Query, model.Parameters, transaction);
                        }

                        transaction.Commit();
                        return ActionResult.Succeed();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return ActionResult.Failed(e);
                    }
            });
        }
    }

    public class SqlQueryModel
    {
        public SqlQueryModel(string query, object parameters = null)
        {
            Query = query;
            Parameters = parameters;
        }

        public string Query { get; set; }
        public object Parameters { get; set; }
    }
}
