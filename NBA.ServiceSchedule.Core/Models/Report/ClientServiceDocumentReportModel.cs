using System;

namespace NBA.ServiceSchedule.Core.Models.Report
{
    public class ClientServiceDocumentReportModel
    {
        public string Series { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string CreatorUser { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientGroupName { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int PreviousCount { get; set; }
        public int LastCount { get; set; }
        public int InstallationCount { get; set; }
        public int CancellationCount { get; set; }
    }
}
