using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables
{
    public class ClientPaymentNoteTableObject : BaseTableObject
    {
        public override string Name { get; } = TableName;
        public const string TableName = "ClientPaymentNotes";

        public const string ClientCode = nameof(ClientPaymentNoteDao.ClientCode);
        public const string FirstDate = nameof(ClientPaymentNoteDao.FirstDate);
        public const string LastDate = nameof(ClientPaymentNoteDao.LastDate);

        protected override string GetColumnsQuery()
        {
            return base.GetColumnsQuery() +
                   $"[{ClientCode}] nvarchar(25) not null,\n" +
                   $"[{FirstDate}] datetime not null,\n" +
                   $"[{LastDate}] datetime not null";
        }

        public override Task<ActionResult> InsertDefaultValues()
        {
            return Task.FromResult(ActionResult.Succeed());
        }
    }
}
