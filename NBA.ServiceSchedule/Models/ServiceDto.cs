using NBA.ServiceSchedule.Core.Models.Entities;

namespace NBA.ServiceSchedule.Models
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ServiceName { get; set; }
        public decimal MonthlyPaymentAmount { get; set; }
        public decimal DailyPaymentAmount { get; set; }

        public ServiceEntity ToEntity()
        {
            return new ServiceEntity
            {
                Id = Id,
                Code = Code,
                ServiceName = ServiceName,
                MonthlyPaymentAmount = MonthlyPaymentAmount,
                DailyPaymentAmount = DailyPaymentAmount
            };
        }

        public static ServiceDto FromEntity(ServiceEntity entity)
        {
            return new ServiceDto
            {
                Id = entity.Id,
                Code = entity.Code,
                ServiceName = entity.ServiceName,
                MonthlyPaymentAmount = entity.MonthlyPaymentAmount,
                DailyPaymentAmount = entity.DailyPaymentAmount
            };
        }
    }
}
