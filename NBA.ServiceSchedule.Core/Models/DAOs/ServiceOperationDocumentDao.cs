using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public class ServiceOperationDocumentDao : BaseDao
    {
        public string Series { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int Count { get; set; }
        public ServiceOperationType ServiceOperationType { get; set; }

        [Obsolete("Don't use this method")]
        public override BaseEntity ToEntity()
        {
            return new ServiceOperationDocumentEntity();
        }

        public static ServiceOperationDocumentEntity FromDaoList(List<ServiceOperationDocumentDao> daoList)
        {
            var entity = new ServiceOperationDocumentEntity();

            if (daoList != null && daoList.Any())
            {
                entity.Series = daoList[0].Series;
                entity.Number = daoList[0].Number;
                entity.Date = daoList[0].Date;
                entity.DocumentNumber = daoList[0].DocumentNumber;
                entity.DocumentDate = daoList[0].DocumentDate;
                entity.ClientCode = daoList[0].ClientCode;
                entity.ClientName = daoList[0].ClientName;

                entity.Lines = daoList.Select(dao => new ServiceOperationDocumentLineEntity
                {
                    Id = dao.Id,
                    ServiceCode = dao.ServiceCode,
                    ServiceName = dao.ServiceName,
                    Count = dao.Count,
                    ServiceOperationType = dao.ServiceOperationType
                }).ToList();
            };

            return entity;
        }
    }
}
