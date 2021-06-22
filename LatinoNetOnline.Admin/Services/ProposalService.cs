using LatinoNetOnline.Admin.Helpers.QueryParams;
using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Proposals;

using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LatinoNetOnline.Admin.Services
{
    public interface IProposalService
    {
        Task<OperationResult<IList<ProposalFull>>> GetAllAsync();
        Task<OperationResult<IList<ProposalFull>>> GetAllAsync(ProposalFilter filter);
        Task<OperationResult<ProposalFull>> GetByIdAsync(Guid id);
        Task<OperationResult> DeleteAsync(Guid id);
    }


    public class ProposalService : IProposalService
    {
        const string URL = "api/v1/callforspeakers-module/proposals";

        private readonly IApiClient _apiClient;

        public ProposalService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<IList<ProposalFull>>> GetAllAsync()
            => GetAllAsync(new());
        public Task<OperationResult<IList<ProposalFull>>> GetAllAsync(ProposalFilter filter)
            => _apiClient.GetAsync<OperationResult<IList<ProposalFull>>>(URL + filter.ToQueryParams());

        public Task<OperationResult<ProposalFull>> GetByIdAsync(Guid id)
            => _apiClient.GetAsync<OperationResult<ProposalFull>>(URL + "/" + id.ToString());

        public Task<OperationResult> DeleteAsync(Guid id)
            => _apiClient.DeleteAsync<OperationResult>(URL + "/" + id.ToString());
    }
}
