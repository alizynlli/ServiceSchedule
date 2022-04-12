using NBA.ServiceSchedule.Core.Models.Entities;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public class ServiceDao : BaseDao
    {
        public string Code { get; set; }
        public string ServiceName { get; set; }
        public decimal MonthlyPaymentAmount { get; set; }
        public decimal DailyPaymentAmount { get; set; }

        public override BaseEntity ToEntity()
        {
            var entity = new ServiceEntity
            {
                Code = Code,
                ServiceName = ServiceName,
                MonthlyPaymentAmount = MonthlyPaymentAmount,
                DailyPaymentAmount = DailyPaymentAmount
            };

            entity.SetBase(this);

            return entity;
        }
    }
}
