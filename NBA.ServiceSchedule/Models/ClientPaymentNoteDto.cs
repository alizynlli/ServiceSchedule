using NBA.ServiceSchedule.Core.Models.Entities;
using System;

namespace NBA.ServiceSchedule.Models
{
    public class ClientPaymentNoteDto
    {
        public ClientPaymentNoteDto()
        {
            var today = DateTime.Today;
            FirstDate = new DateTime(today.Year, today.Month, 1);
            LastDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
        }

        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }

        public ClientPaymentNoteEntity ToEntity()
        {
            return new ClientPaymentNoteEntity
            {
                Id = Id,
                ClientCode = ClientCode,
                FirstDate = FirstDate,
                LastDate = LastDate
            };
        }

        public static ClientPaymentNoteDto FromEntity(ClientPaymentNoteEntity entity)
        {
            return new ClientPaymentNoteDto
            {
                Id = entity.Id,
                ClientCode = entity.ClientCode,
                ClientName = entity.ClientName,
                FirstDate = entity.FirstDate,
                LastDate = entity.LastDate
            };
        }
    }
}
