using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.DataAccess.Implementation;
using System;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.DbContext.DbSchema.Tables
{
    public class ServiceTableObject : BaseTableObject
    {
        public const string TableName = "Services";
        public override string Name => TableName;

        public const string Code = nameof(ServiceDao.Code);
        public const string ServiceName = nameof(ServiceDao.ServiceName);
        public const string MonthlyPaymentAmount = nameof(ServiceDao.MonthlyPaymentAmount);
        public const string DailyPaymentAmount = nameof(ServiceDao.DailyPaymentAmount);

        protected override string GetColumnsQuery()
        {
            return base.GetColumnsQuery() +
                   $"[{Code}] nvarchar(25) not null unique,\n" +
                   $"[{ServiceName}] nvarchar(50) not null,\n" +
                   $"[{MonthlyPaymentAmount}] decimal(18,2) not null,\n" +
                   $"[{DailyPaymentAmount}] decimal(18,2) not null\n";
        }

        public override async Task<ActionResult> InsertDefaultValues()
        {
            try
            {
                var bank = new ServiceDao { Code = "0001", ServiceName = "Bank", MonthlyPaymentAmount = 8M, DailyPaymentAmount = 0.27M };
                var paxDistrict = new ServiceDao { Code = "0002", ServiceName = "Pax Rayon", MonthlyPaymentAmount = 10M, DailyPaymentAmount = 0.33M };
                var paxCity = new ServiceDao { Code = "0003", ServiceName = "Pax şəhər", MonthlyPaymentAmount = 12M, DailyPaymentAmount = 0.40M };
                var fiscalPaxCity = new ServiceDao { Code = "0004", ServiceName = "Fiscal pax şəhər", MonthlyPaymentAmount = 14M, DailyPaymentAmount = 0.47M };
                var fiscalSumqait = new ServiceDao { Code = "0005", ServiceName = "Fiscal Sumqayıt", MonthlyPaymentAmount = 15M, DailyPaymentAmount = 0.50M };
                var fiscal = new ServiceDao { Code = "0006", ServiceName = "Fiscal", MonthlyPaymentAmount = 20M, DailyPaymentAmount = 0.67M };
                var others = new ServiceDao { Code = "0007", ServiceName = "Digər", MonthlyPaymentAmount = 50M, DailyPaymentAmount = 1.67M };

                var result = await RepositoryContainer.ServiceRepository.InsertManyAsync(bank, paxDistrict, paxCity, fiscalPaxCity, fiscalSumqait, fiscal, others);

                return result;
            }
            catch (Exception exception)
            {
                return ActionResult.Failed(exception);
            }
        }
    }
}
