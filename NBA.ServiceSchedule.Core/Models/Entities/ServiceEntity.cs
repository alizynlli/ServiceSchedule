using NBA.ServiceSchedule.Core.Models.DAOs;

namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public string Code { get; set; }
        public string ServiceName { get; set; }
        public decimal MonthlyPaymentAmount { get; set; }
        public decimal DailyPaymentAmount { get; set; }

        public override BaseDao ToDao()
        {
            return new ServiceDao
            {
                Code = Code,
                ServiceName = ServiceName,
                MonthlyPaymentAmount = MonthlyPaymentAmount,
                DailyPaymentAmount = DailyPaymentAmount
            }.SetBase(this);
        }
    }
}
