using NBA.ServiceSchedule.Core.Models.DAOs;
using System;

namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public class ClientPaymentNoteEntity : BaseEntity
    {
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }

        public override BaseDao ToDao()
        {
            return new ClientPaymentNoteDao
            {
                ClientCode = ClientCode,
                FirstDate = FirstDate,
                LastDate = LastDate
            }.SetBase(this);
        }
    }
}
