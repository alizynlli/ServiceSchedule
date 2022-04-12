using NBA.ServiceSchedule.Core;
using System.Threading.Tasks;
using NBA.ServiceSchedule.Core.Models.DAOs;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables
{
    public class ServiceOperationDocumentTableObject : BaseTableObject
    {
        public override string Name => TableName;
        public const string TableName = "ServiceOperationDocuments";

        public const string Series = nameof(ServiceOperationDocumentDao.Series);
        public const string Number = nameof(ServiceOperationDocumentDao.Number);
        public const string Date = nameof(ServiceOperationDocumentDao.Date);
        public const string DocumentNumber = nameof(ServiceOperationDocumentDao.DocumentNumber);
        public const string DocumentDate = nameof(ServiceOperationDocumentDao.DocumentDate);
        public const string ClientCode = nameof(ServiceOperationDocumentDao.ClientCode);
        public const string ServiceCode = nameof(ServiceOperationDocumentDao.ServiceCode);
        public const string Count = nameof(ServiceOperationDocumentDao.Count);
        public const string ServiceOperationType = nameof(ServiceOperationDocumentDao.ServiceOperationType);

        protected override string GetColumnsQuery()
        {
            return base.GetColumnsQuery() +
                   $"[{Series}] nvarchar(5) not null,\n" +
                   $"[{Number}] int not null,\n" +
                   $"[{Date}] datetime not null,\n" +
                   $"[{DocumentNumber}] nvarchar(25) not null,\n" +
                   $"[{DocumentDate}] datetime not null,\n" +
                   $"[{ClientCode}] nvarchar(25) not null,\n" +
                   $"[{ServiceCode}] nvarchar(25) not null,\n" +
                   $"[{Count}] int not null,\n" +
                   $"[{ServiceOperationType}] tinyint not null,\n";
        }

        public override Task<ActionResult> InsertDefaultValues()
        {
            return Task.Run(() => ActionResult.Succeed());
        }
    }
}
