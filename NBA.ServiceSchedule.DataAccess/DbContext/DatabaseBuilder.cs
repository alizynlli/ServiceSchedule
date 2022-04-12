using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.DbContext;
using System;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.DbContext
{
    public class DatabaseBuilder
    {
        private readonly string _database;
        private readonly string _schema;

        public DatabaseBuilder(string database, string schema)
        {
            _database = database;
            _schema = schema;
        }

        public Task<ActionResult> CreateDbObject(IDatabaseObject dbObject)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var conn = SqlHelper.CreateConnection())
                    {
                        var createQuery = dbObject.GetCreateQuery();

                        conn.Execute(createQuery);
                        return ActionResult.Succeed();
                    }
                }
                catch (Exception e)
                {
                    return ActionResult.Failed(e);
                }
            });
        }

        public Task<ActionResult> ExecuteQuery(string query)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var conn = SqlHelper.CreateConnection())
                    {
                        conn.Execute(query);
                        return ActionResult.Succeed();
                    }
                }
                catch (Exception e)
                {
                    return ActionResult.Failed(e);
                }
            });
        }
    }
}
