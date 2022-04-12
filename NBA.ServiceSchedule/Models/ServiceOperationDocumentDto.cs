using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBA.ServiceSchedule.Models
{
    public class ServiceOperationDocumentDto
    {
        public ServiceOperationDocumentDto()
        {
            Series = string.Empty;
            DocumentNumber = string.Empty;
            var date = DateTime.Today;
            Date = date;
            DocumentDate = date;

            Lines = new List<ServiceOperationDocumentLineDto> { new ServiceOperationDocumentLineDto(), new ServiceOperationDocumentLineDto() };
        }

        public string Series { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public List<ServiceOperationDocumentLineDto> Lines { get; set; }

        public ServiceOperationDocumentEntity ToEntity()
        {
            var entity = new ServiceOperationDocumentEntity
            {
                Series = Series,
                Number = Number,
                Date = Date,
                DocumentNumber = DocumentNumber,
                DocumentDate = DocumentDate,
                ClientCode = ClientCode
            };

            entity.Lines = Lines?.Select(l => l.ToEntity()).ToList();

            return entity;
        }

        public static ServiceOperationDocumentDto FromEntity(ServiceOperationDocumentEntity entity)
        {
            var dto = new ServiceOperationDocumentDto
            {
                Series = entity.Series,
                Number = entity.Number,
                Date = entity.Date,
                DocumentNumber = entity.DocumentNumber,
                DocumentDate = entity.DocumentDate,
                ClientCode = entity.ClientCode,
                ClientName = entity.ClientName,
                Lines = entity.Lines?.Select(ServiceOperationDocumentLineDto.FromEntity).ToList()
            };

            return dto;
        }
    }

    public class ServiceOperationDocumentLineDto
    {
        public ServiceOperationDocumentLineDto()
        {
            Count = 1;
        }

        public int Id { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int Count { get; set; }
        public ServiceOperationType OperationType { get; set; }

        public ServiceOperationDocumentLineEntity ToEntity()
        {
            return new ServiceOperationDocumentLineEntity
            {
                Id = Id,
                ServiceCode = ServiceCode,
                Count = Count,
                ServiceOperationType = OperationType
            };
        }

        public static ServiceOperationDocumentLineDto FromEntity(ServiceOperationDocumentLineEntity lineEntity)
        {
            return new ServiceOperationDocumentLineDto
            {
                Id = lineEntity.Id,
                ServiceCode = lineEntity.ServiceCode,
                ServiceName = lineEntity.ServiceName,
                Count = lineEntity.Count,
                OperationType = lineEntity.ServiceOperationType
            };
        }
    }
}
