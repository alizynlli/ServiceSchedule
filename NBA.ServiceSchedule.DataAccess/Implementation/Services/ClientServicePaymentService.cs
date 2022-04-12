using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Entities;
using NBA.ServiceSchedule.Core.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Services
{
    public class ClientServicePaymentService : IClientServicePaymentService
    {
        private readonly ClientServicePaymentOptions _options;
        private readonly List<ServiceEntity> _services;
        private readonly List<ServiceOperationDocumentDao> _documents;
        private readonly List<ClientServiceCountEntity> _clientServiceFirstDateCountEntities;
        private readonly List<ClientServiceCountEntity> _clientServiceLastDateCountEntities;

        public ClientServicePaymentService(ClientServicePaymentOptions options)
        {
            _options = options ?? throw new NullReferenceException("Servisə hesablama parametrləri göndərilməyib.");
            _services = new List<ServiceEntity>();
            _documents = new List<ServiceOperationDocumentDao>();
            _clientServiceFirstDateCountEntities = new List<ClientServiceCountEntity>();
            _clientServiceLastDateCountEntities = new List<ClientServiceCountEntity>();
        }

        public async Task<ActionResult> LoadClientServiceFirstDateCountsAsync()
        {
            var servicesCountResult = await RepositoryContainer.ServiceOperationDocumentRepository.GetAllClientServicesCount(_options.FirstDate.AddDays(-1),
                _options.FilteredClientCodeList, _options.FilteredServiceCodeList);

            if (servicesCountResult.IsFailed)
                return ActionResult.Failed(servicesCountResult.Exception);

            _clientServiceFirstDateCountEntities.AddRange(servicesCountResult.Data.Select(dao => new ClientServiceCountEntity { ClientCode = dao.ClientCode, ServiceCode = dao.ServiceCode, ServiceCount = dao.Count }));

            return ActionResult.Succeed();
        }

        public async Task<ActionResult> LoadServicesAsync()
        {
            var servicesResult = await ServiceContainer.ServiceCardService.GetAllAsync();

            if (servicesResult.IsFailed)
                return ActionResult.Failed(servicesResult.Exception);

            _services.AddRange(servicesResult.Data);

            return ActionResult.Succeed();
        }

        public async Task<ActionResult> LoadClientServiceLastDateCountsAsync()
        {
            var servicesCountResult = await RepositoryContainer.ServiceOperationDocumentRepository.GetAllClientServicesCount(_options.LastDate,
                _options.FilteredClientCodeList, _options.FilteredServiceCodeList);

            if (servicesCountResult.IsFailed)
                return ActionResult.Failed(servicesCountResult.Exception);

            _clientServiceLastDateCountEntities.AddRange(servicesCountResult.Data.Select(dao => new ClientServiceCountEntity { ClientCode = dao.ClientCode, ServiceCode = dao.ServiceCode, ServiceCount = dao.Count }));

            return ActionResult.Succeed();
        }

        public async Task<ActionResult> LoadClientServiceDocumentsAsync()
        {
            var documentsResult = await RepositoryContainer.ServiceOperationDocumentRepository.GetAllDocuments(_options.FirstDate, _options.LastDate);

            if (documentsResult.IsFailed)
                return ActionResult.Failed(documentsResult.Exception);

            _documents.AddRange(documentsResult.Data);

            return ActionResult.Succeed();
        }

        public int GetClientServiceFirstCount(string clientCode, string serviceCode)
        {
            return _clientServiceFirstDateCountEntities.FirstOrDefault(e => e.ClientCode == clientCode && e.ServiceCode == serviceCode)?.ServiceCount ?? 0;
        }

        public int GetClientServiceLastCount(string clientCode, string serviceCode)
        {
            return _clientServiceLastDateCountEntities.FirstOrDefault(e => e.ClientCode == clientCode && e.ServiceCode == serviceCode)?.ServiceCount ?? 0;
        }

        public ActionResult<decimal> CalculateClientServicePayment(ClientServicePaymentCalculationOptions calculationOptions)
        {
            var service = _services.First(s => s.Code == calculationOptions.ServiceCode);

            var daysInMonth = DateTime.DaysInMonth(_options.LastDate.Year, _options.LastDate.Month);

            var documents = _documents.Where(d => d.ClientCode == calculationOptions.ClientCode && d.ServiceCode == calculationOptions.ServiceCode
                                                //Ayın sonundan 2 günü nəzərə almırıq.
                                                && d.Date.Day < daysInMonth - 1).ToList();
            var serviceTotalPayment = 0M;

            var oldDocumentsCount = _clientServiceFirstDateCountEntities.FirstOrDefault(e => e.ClientCode == calculationOptions.ClientCode && e.ServiceCode == calculationOptions.ServiceCode)?.ServiceCount ?? 0;

            var currentMonthMonthlyInstallationCount = documents
                .Where(d => d.ServiceOperationType == ServiceOperationType.Installation && d.Date.Day <= 2).Sum(d => d.Count);

            var currentMonthDailyInstallationCount = documents
                .Where(d => d.ServiceOperationType == ServiceOperationType.Installation && d.Date.Day > 2).Sum(d => d.Count);

            var currentMonthMonthlyCancellationCount = documents
                .Where(d => d.ServiceOperationType == ServiceOperationType.Cancellation && d.Date.Day <= 2).Sum(d => d.Count);

            var remainedCurrentMonthMonthlyInstallationCount = currentMonthMonthlyInstallationCount - currentMonthMonthlyCancellationCount;

            oldDocumentsCount += remainedCurrentMonthMonthlyInstallationCount;

            var currentMonthDailyCancellationCount = documents
                .Where(d => d.ServiceOperationType == ServiceOperationType.Cancellation && d.Date.Day > 2).Sum(d => d.Count);

            var different = currentMonthDailyCancellationCount - currentMonthDailyInstallationCount;
            if (different > 0)
            {
                oldDocumentsCount -= different;
                serviceTotalPayment += different * _options.LastDate.Day * service.DailyPaymentAmount;
            }

            var currentMonthDailyInstalledServicesTotalPayment = documents
                .Where(d => d.ServiceOperationType == ServiceOperationType.Installation && d.Date.Day > 2)
                .Sum(d => d.Count * (_options.LastDate.Day - d.Date.Day + 1) * service.DailyPaymentAmount);

            var currentMonthDailyCancelledServicesTotalPayment = documents
                .Where(d => d.ServiceOperationType == ServiceOperationType.Cancellation && d.Date.Day > 2)
                .Sum(d => d.Count * (_options.LastDate.Day - d.Date.Day + 1) * service.DailyPaymentAmount);

            serviceTotalPayment += oldDocumentsCount * (daysInMonth == _options.LastDate.Day ? service.MonthlyPaymentAmount : service.DailyPaymentAmount * _options.LastDate.Day) + currentMonthDailyInstalledServicesTotalPayment - currentMonthDailyCancelledServicesTotalPayment;

            return ActionResult<decimal>.Succeed(serviceTotalPayment);
        }
    }
}
