using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Metricool;

using System;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IMetricoolService
    {
        Task<OperationResult<MetricoolExportFileDto>> ExportFileByWebinarAsync(Guid webinarId);
    }

    public class MetricoolService : IMetricoolService
    {
        const string URL = "api/v1/callforspeakers-module/metricool";

        private readonly IApiClient _apiClient;

        public MetricoolService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<MetricoolExportFileDto>> ExportFileByWebinarAsync(Guid proposalId)
           => _apiClient.GetAsync<OperationResult<MetricoolExportFileDto>>(URL + "/Proposals/" + proposalId.ToString());
    }
}
