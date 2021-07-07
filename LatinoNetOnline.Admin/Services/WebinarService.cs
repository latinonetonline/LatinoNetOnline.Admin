using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Webinars;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IWebinarService
    {
        Task<OperationResult<IList<Webinar>>> GetAsync();
        Task<OperationResult<Webinar>> CreateAsync(CreateWebinarInput input);
        Task<OperationResult<Webinar>> ConfirmAsync(ConfirmWebinarInput input);
        Task<OperationResult<Webinar>> GetByProposalAsync(Guid proposalId);
    }

    public class WebinarService : IWebinarService
    {

        const string URL = "api/v1/events-module/webinars";

        private readonly IApiClient _apiClient;

        public WebinarService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<OperationResult<Webinar>> ConfirmAsync(ConfirmWebinarInput input)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(input.Image), "file", "file");
            formData.Add(new StringContent(input.LiveStreaming.ToString()), "LiveStreaming");
            formData.Add(new StringContent(input.Streamyard.ToString()), "Streamyard");
            formData.Add(new StringContent(input.Id.ToString()), "Id");
 
            var request = new HttpRequestMessage(HttpMethod.Post, URL+ "/confirm")
            {
                Content = formData
            };

            var response = await _apiClient.HttpClient.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<OperationResult<Webinar>>();
        }

        public Task<OperationResult<Webinar>> CreateAsync(CreateWebinarInput input)
            => _apiClient.PostAsync<CreateWebinarInput, OperationResult<Webinar>>(URL, input);

        public Task<OperationResult<IList<Webinar>>> GetAsync()
            => _apiClient.GetAsync<OperationResult<IList<Webinar>>>(URL);

        public Task<OperationResult<Webinar>> GetByProposalAsync(Guid proposalId)
            => _apiClient.GetAsync<OperationResult<Webinar>>(URL + "/Proposals/" + proposalId.ToString());
    }
}
