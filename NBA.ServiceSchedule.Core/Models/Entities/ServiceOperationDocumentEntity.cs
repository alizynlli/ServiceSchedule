using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using NBA.ServiceSchedule.Core.Global;

namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public class ServiceOperationDocumentEntity : BaseEntity
    {
        public ServiceOperationDocumentEntity()
        {
            Lines = new List<ServiceOperationDocumentLineEntity>();
        }

        public string Series { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public List<ServiceOperationDocumentLineEntity> Lines { get; set; }

        [Obsolete("Don't use it")]
        public override BaseDao ToDao()
        {
            return new ServiceOperationDocumentDao();
        }

        public List<ServiceOperationDocumentDao> ToDaoList()
        {
            var list = Lines.Select(line =>
                new ServiceOperationDocumentDao
                {
                    Id = line.Id,
                    CreatorUserId = Session.CurrentUser.Id,
                    Series = Series,
                    Number = Number,
                    Date = Date,
                    DocumentNumber = DocumentNumber,
                    DocumentDate = DocumentDate,
                    ClientCode = ClientCode,
                    ServiceCode = line.ServiceCode,
                    Count = line.Count,
                    ServiceOperationType = line.ServiceOperationType
                }).ToList();

            return list;
        }
    }

    public class ServiceOperationDocumentLineEntity
    {
        public int Id { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int Count { get; set; }
        public ServiceOperationType ServiceOperationType { get; set; }
    }
}
