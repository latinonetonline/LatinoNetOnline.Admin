using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Webinars;

using System;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IWebinarService
    {
        Task<OperationResult<Webinar>> CreateAsync(CreateWebinarInput input);
        Task<OperationResult<WebinarFull>> GetByProposalAsync(Guid proposalId);
    }

    public class WebinarService : IWebinarService
    {

        const string URL = "api/v1/callforspeakers-module/webinars";

        private readonly IApiClient _apiClient;

        public WebinarService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<Webinar>> CreateAsync(CreateWebinarInput input)
            => _apiClient.PostAsync<CreateWebinarInput, OperationResult<Webinar>>(URL, input);

        public Task<OperationResult<WebinarFull>> GetByProposalAsync(Guid proposalId)
            => _apiClient.GetAsync<OperationResult<WebinarFull>>(URL + "/Proposals/" + proposalId.ToString());
    }
}
