using NBA.ServiceSchedule.Core.Models.Entities;
using System;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public class ClientPaymentNoteDao : BaseDao
    {
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }

        public override BaseEntity ToEntity()
        {
            return new ClientPaymentNoteEntity
            {
                ClientCode = ClientCode,
                ClientName = ClientName,
                FirstDate = FirstDate,
                LastDate = LastDate
            }.SetBase(this);
        }
    }
}
