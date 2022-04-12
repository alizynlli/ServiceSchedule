using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Entities;
using NBA.ServiceSchedule.Core.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBA.ServiceSchedule.Core.Models.Options;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Services
{
    public class ServiceOperationDocumentService : IServiceOperationDocumentService
    {
        private readonly IServiceOperationDocumentRepository _repository;

        public ServiceOperationDocumentService()
        {
            _repository = RepositoryContainer.ServiceOperationDocumentRepository;
        }

        public async Task<ActionResult<IEnumerable<ServiceOperationDocumentEntity>>> GetAllAsync()
        {
            var listResult = await _repository.GetAllAsync();
            if (listResult.IsFailed)
                return ActionResult<IEnumerable<ServiceOperationDocumentEntity>>.Failed(listResult.Exception);
            var daoList = listResult.Data?.ToList() ?? new List<ServiceOperationDocumentDao>();

            var entityList = daoList
                    .GroupBy(dao => new { dao.Series, dao.Number })
                    .Select(d => ServiceOperationDocumentDao.FromDaoList(daoList.Where(dao => dao.Series == d.Key.Series && dao.Number == d.Key.Number).ToList())).ToList();

            return ActionResult<IEnumerable<ServiceOperationDocumentEntity>>.Succeed(entityList);
        }

        public Task<ActionResult> SaveAsync(ServiceOperationDocumentEntity entity)
        {
            var daoList = entity.ToDaoList();
            return _repository.SaveDocumentsAsync(daoList);
        }

        public Task<ActionResult> DeleteAsync(int id, bool permanently = false)
        {
            return Task.FromResult(ActionResult.Succeed());
        }

        public Task<ActionResult<int>> GetNewNumberBySeries(string series)
        {
            return _repository.GetNewNumberBySeries(series);
        }

        public async Task<ActionResult<ServiceOperationDocumentEntity>> GetPreviousDocumentBySeries(string series, int number)
        {
            var previousNumberResult = await _repository.GetPreviousNumberBySeries(series, number);
            if (previousNumberResult.IsFailed) return ActionResult<ServiceOperationDocumentEntity>.Failed(previousNumberResult.Exception);

            if (previousNumberResult.Data == 0)
                return ActionResult<ServiceOperationDocumentEntity>.Succeed(new ServiceOperationDocumentEntity());

            return await GetBySeriesAndNumber(series, previousNumberResult.Data);
        }

        public async Task<ActionResult<ServiceOperationDocumentEntity>> GetNextDocumentBySeries(string series, int number)
        {
            var nextNumberResult = await _repository.GetNextNumberBySeries(series, number);
            if (nextNumberResult.IsFailed) return ActionResult<ServiceOperationDocumentEntity>.Failed(nextNumberResult.Exception);

            if (nextNumberResult.Data == 0)
                return ActionResult<ServiceOperationDocumentEntity>.Succeed(new ServiceOperationDocumentEntity());

            return await GetBySeriesAndNumber(series, nextNumberResult.Data);
        }

        public async Task<ActionResult<ServiceOperationDocumentEntity>> GetBySeriesAndNumber(string series, int number)
        {
            var result = await _repository.GetBySeriesAndNumber(series, number);
            if (result.IsSucceed)
            {
                var daoList = result.Data;
                if (daoList == null || !daoList.Any()) return ActionResult<ServiceOperationDocumentEntity>.Succeed(null);
                var entity = ServiceOperationDocumentDao.FromDaoList(daoList);

                return ActionResult<ServiceOperationDocumentEntity>.Succeed(entity);
            }

            return ActionResult<ServiceOperationDocumentEntity>.Failed(result.ErrorMessages.FirstOrDefault() ?? result.Exception?.Message);
        }

        public Task<ActionResult> DeleteAsync(IList<int> idList, bool permanently = false)
        {
            return _repository.DeleteAsync(idList);
        }

        public Task<ActionResult<int>> GetClientActiveServiceCount(string serviceCode, string clientCode, DateTime date)
        {
            return _repository.GetActiveServiceCount(serviceCode, clientCode, date);
        }

        public async Task<ActionResult<IEnumerable<ClientServiceCubeReportModel>>> GetCubeReport(DateTime firstDate, DateTime lastDate, bool withPaymentAmount, List<string> clientCodeList = null, List<string> serviceCodeList = null)
        {
            var result = await _repository.GetCubeReport(firstDate, lastDate, clientCodeList, serviceCodeList);
            if (result.IsFailed)
                return result;

            var data = result.Data?.ToList();
            if (data == null || !data.Any())
                return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Succeed(new List<ClientServiceCubeReportModel>());

            var groupedReportModels = data.GroupBy(d => new { d.ClientCode, d.ServiceCode });

            //var clientServiceFirstDateCountListResult =
            //    await _repository.GetAllClientServicesCount(firstDate, clientCodeList, serviceCodeList);

            //if (clientServiceFirstDateCountListResult.IsFailed)
            //    return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(clientServiceFirstDateCountListResult.Exception);

            //var clientServiceFirstDateCountList = clientServiceFirstDateCountListResult.Data?.ToList() ?? new List<ClientServiceCountDao>(0);


            //var clientServiceLastDateCountListResult =
            //    await _repository.GetAllClientServicesCount(lastDate, clientCodeList, serviceCodeList);

            //if (clientServiceLastDateCountListResult.IsFailed)
            //    return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(clientServiceLastDateCountListResult.Exception);

            //var clientServiceLastDateCountList = clientServiceLastDateCountListResult.Data?.ToList() ?? new List<ClientServiceCountDao>(0);


            var clientServicePaymentService =
                new ClientServicePaymentService(new ClientServicePaymentOptions
                {
                    FilteredClientCodeList = clientCodeList,
                    FilteredServiceCodeList = serviceCodeList,
                    FirstDate = firstDate,
                    LastDate = lastDate
                });

            var loadResult = await clientServicePaymentService.LoadClientServiceFirstDateCountsAsync();
            if (loadResult.IsFailed)
                return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(loadResult.Exception);

            loadResult = await clientServicePaymentService.LoadClientServiceLastDateCountsAsync();
            if (loadResult.IsFailed)
                return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(loadResult.Exception);

            if (withPaymentAmount)
            {
                loadResult = await clientServicePaymentService.LoadServicesAsync();
                if (loadResult.IsFailed)
                    return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(loadResult.Exception);

                loadResult = await clientServicePaymentService.LoadClientServiceDocumentsAsync();
                if (loadResult.IsFailed)
                    return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(loadResult.Exception);
            }

            foreach (var modelGroup in groupedReportModels)
            {
                var line = data.FirstOrDefault(d =>
                    d.ClientCode == modelGroup.Key.ClientCode && d.ServiceCode == modelGroup.Key.ServiceCode);

                if (line == null) continue;

                line.PreviousCount = clientServicePaymentService.GetClientServiceFirstCount(modelGroup.Key.ClientCode, modelGroup.Key.ServiceCode);
                line.LastCount = clientServicePaymentService.GetClientServiceLastCount(modelGroup.Key.ClientCode, modelGroup.Key.ServiceCode);

                if (withPaymentAmount)
                {
                    var paymentResult = clientServicePaymentService.CalculateClientServicePayment(new ClientServicePaymentCalculationOptions()
                    {
                        ClientCode = modelGroup.Key.ClientCode,
                        ServiceCode = modelGroup.Key.ServiceCode
                    });

                    if (paymentResult.IsFailed)
                        return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Failed(paymentResult.Exception);

                    line.ClientServicePayment = paymentResult.Data;
                }
            }

            return ActionResult<IEnumerable<ClientServiceCubeReportModel>>.Succeed(data);
        }

        public async Task<ActionResult<IEnumerable<ClientServiceDocumentReportModel>>> GetDocumentReport(DateTime firstDate, DateTime lastDate, List<string> clientCodeList = null, List<string> serviceCodeList = null)
        {
            var result = await _repository.GetDocumentReport(firstDate, lastDate, clientCodeList, serviceCodeList);
            if (result.IsFailed)
                return result;

            var data = result.Data?.ToList();
            if (data == null || !data.Any())
                return ActionResult<IEnumerable<ClientServiceDocumentReportModel>>.Succeed(new List<ClientServiceDocumentReportModel>());

            var groupedReportModels = data.GroupBy(d => new { d.ClientCode, d.ServiceCode });

            foreach (var modelGroup in groupedReportModels)
            {
                var servicePreviousCountResult = await _repository.GetClientServiceCount(modelGroup.Key.ClientCode, modelGroup.Key.ServiceCode, firstDate.AddDays(-1));
                if (servicePreviousCountResult.IsFailed)
                {
                    return ActionResult<IEnumerable<ClientServiceDocumentReportModel>>.Failed(servicePreviousCountResult.Exception);
                }

                var serviceLastCountResult = await _repository.GetClientServiceCount(modelGroup.Key.ClientCode, modelGroup.Key.ServiceCode, lastDate);
                if (serviceLastCountResult.IsFailed)
                {
                    return ActionResult<IEnumerable<ClientServiceDocumentReportModel>>.Failed(serviceLastCountResult.Exception);
                }

                foreach (var line in data.Where(d => d.ClientCode == modelGroup.Key.ClientCode && d.ServiceCode == modelGroup.Key.ServiceCode))
                {
                    line.PreviousCount = servicePreviousCountResult.Data;
                    line.LastCount = serviceLastCountResult.Data;
                }
            }

            return ActionResult<IEnumerable<ClientServiceDocumentReportModel>>.Succeed(data);
        }
    }
}
