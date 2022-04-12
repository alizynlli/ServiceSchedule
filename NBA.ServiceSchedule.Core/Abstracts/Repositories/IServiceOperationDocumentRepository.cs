using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Report;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Repositories
{
    public interface IServiceOperationDocumentRepository : IRepositoryBase<ServiceOperationDocumentDao>
    {
        Task<ActionResult<IEnumerable<ClientServiceCubeReportModel>>> GetCubeReport(DateTime? firstDate = null, DateTime? lastDate = null, List<string> clientCodeList = null, List<string> serviceCodeList = null);
        Task<ActionResult<IEnumerable<ClientServiceDocumentReportModel>>> GetDocumentReport(DateTime? firstDate = null, DateTime? lastDate = null, List<string> clientCodeList = null, List<string> serviceCodeList = null);
        Task<ActionResult> SaveDocumentsAsync(List<ServiceOperationDocumentDao> daoList);
        Task<ActionResult> DeleteAsync(IList<int> idList);
        Task<ActionResult<int>> GetNewNumberBySeries(string series);
        Task<ActionResult<int>> GetPreviousNumberBySeries(string series, int number);
        Task<ActionResult<int>> GetNextNumberBySeries(string series, int number);
        Task<ActionResult<int>> GetClientServiceCount(string clientCode, string serviceCode, DateTime lastDate);
        Task<ActionResult<IEnumerable<ClientServiceCountDao>>> GetAllClientServicesCount(DateTime lastDate, List<string> clientCodeList = null, List<string> serviceCodeList = null);
        Task<ActionResult<List<ServiceOperationDocumentDao>>> GetBySeriesAndNumber(string series, int number);
        Task<ActionResult<int>> GetActiveServiceCount(string serviceCode, string clientCode, DateTime date);
        Task<ActionResult<List<ServiceOperationDocumentDao>>> GetClientDocuments(string clientCode, DateTime firstDate, DateTime lastDate);
        Task<ActionResult<List<ServiceOperationDocumentDao>>> GetAllDocuments(DateTime firstDate, DateTime lastDate, List<string> clientCodeList = null, List<string> serviceCodeList = null);
    }
}
