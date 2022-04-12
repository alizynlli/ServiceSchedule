using NBA.ServiceSchedule.Core.Models.Options;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.Services
{
    public interface IClientServicePaymentService
    {
        Task<ActionResult> LoadClientServiceFirstDateCountsAsync();
        Task<ActionResult> LoadServicesAsync();
        Task<ActionResult> LoadClientServiceLastDateCountsAsync();
        Task<ActionResult> LoadClientServiceDocumentsAsync();
        int GetClientServiceFirstCount(string clientCode, string serviceCode);
        int GetClientServiceLastCount(string clientCode, string serviceCode);
        ActionResult<decimal> CalculateClientServicePayment(ClientServicePaymentCalculationOptions calculationOptions);
    }
}
