using LatinoNetOnline.Admin.Helpers.QueryParams;
using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Proposals;

using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using LatinoNetOnline.Admin.Models.Webinars;

namespace LatinoNetOnline.Admin.Services
{
    public interface IProposalService
    {
        Task<OperationResult<IList<ProposalFull>>> GetAllAsync();
        Task<OperationResult<IList<ProposalFull>>> GetAllAsync(ProposalFilter filter);
        Task<OperationResult<ProposalFull>> GetByIdAsync(Guid id);
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult<ProposalFull>> UpdateAsync(UpdateProposalInput input);
        Task<OperationResult<Proposal>> ChangePhotoAsync(Guid id, Stream image);
        Task<OperationResult<Proposal>> ConfirmAsync(ConfirmWebinarInput input);
        Task<OperationResult<ProposalDescriptionText>> GetDescriptionTextAsync(Guid id);


    }


    public class ProposalService : IProposalService
    {
        const string URL = "api/v1/webinars-module/proposals";

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

        public Task<OperationResult<ProposalFull>> UpdateAsync(UpdateProposalInput input)
            => _apiClient.PutAsync<UpdateProposalInput, OperationResult<ProposalFull>>(URL, input);

        public async Task<OperationResult<Proposal>> ChangePhotoAsync(Guid id, Stream image)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(image), "file", "file");

            var request = new HttpRequestMessage(HttpMethod.Post, URL + "/" + id.ToString() + "/Photo")
            {
                Content = formData
            };

            var response = await _apiClient.HttpClient.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<OperationResult<Proposal>>();
        }

        public Task<OperationResult<Proposal>> ConfirmAsync(ConfirmWebinarInput input)
           => _apiClient.PostAsync<ConfirmWebinarInput, OperationResult<Proposal>>(URL + "/Confirm", input);

        public Task<OperationResult<ProposalDescriptionText>> GetDescriptionTextAsync(Guid id)
            => _apiClient.GetAsync<OperationResult<ProposalDescriptionText>>(URL + "/" + id.ToString() + "/Description");
    }
}
