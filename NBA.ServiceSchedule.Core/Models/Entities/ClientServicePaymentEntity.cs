namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public class ClientServicePaymentEntity
    {
        public string ClientCode { get; set; }
        public string ServiceCode { get; set; }
        public decimal PaymentAmount { get; set; }
    }

    public class ClientServiceCountEntity
    {
        public string ClientCode { get; set; }
        public string ServiceCode { get; set; }
        public int ServiceCount { get; set; }
    }
}
