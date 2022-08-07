using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Proposals;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface ISpeakerService
    {
        Task<OperationResult<IList<Speaker>>> GetAllAsync();
    }

    public class SpeakerService : ISpeakerService
    {
        const string URL = "api/v1/webinars-module/speakers";

        private readonly IApiClient _apiClient;

        public SpeakerService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<IList<Speaker>>> GetAllAsync()
            => _apiClient.GetAsync<OperationResult<IList<Speaker>>>(URL);
    }
}
