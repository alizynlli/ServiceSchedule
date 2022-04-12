using NBA.ServiceSchedule.Core.Models.Entities;
using NBA.ServiceSchedule.Core.Models.Report;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Services
{
    public interface IServiceOperationDocumentService : IServiceBase<ServiceOperationDocumentEntity>
    {
        Task<ActionResult<int>> GetNewNumberBySeries(string series);
        Task<ActionResult<ServiceOperationDocumentEntity>> GetPreviousDocumentBySeries(string series, int number);
        Task<ActionResult<ServiceOperationDocumentEntity>> GetNextDocumentBySeries(string series, int number);
        Task<ActionResult<ServiceOperationDocumentEntity>> GetBySeriesAndNumber(string series, int number);
        Task<ActionResult> DeleteAsync(IList<int> idList, bool permanently = false);
        Task<ActionResult<int>> GetClientActiveServiceCount(string serviceCode, string clientCode, DateTime date);
        Task<ActionResult<IEnumerable<ClientServiceCubeReportModel>>> GetCubeReport(DateTime firstDate, DateTime lastDate, bool withPaymentAmount, List<string> clientCodeList = null, List<string> serviceCodeList = null);
        Task<ActionResult<IEnumerable<ClientServiceDocumentReportModel>>> GetDocumentReport(DateTime firstDate, DateTime lastDate, List<string> clientCodeList = null, List<string> serviceCodeList = null);
    }
}
