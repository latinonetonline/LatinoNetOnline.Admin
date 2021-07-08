using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Webinars;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IWebinarService
    {
        Task<OperationResult<IList<Webinar>>> GetAsync();
        Task<OperationResult<Webinar>> GetAsync(Guid id);
        Task<OperationResult<Webinar>> CreateAsync(CreateWebinarInput input);
        Task<OperationResult<Webinar>> UpdateAsync(UpdateWebinarInput input);
        Task<OperationResult<Webinar>> ConfirmAsync(ConfirmWebinarInput input);
        Task<OperationResult<Webinar>> ChangePhotoAsync(Guid id, Stream image);
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

        public async Task<OperationResult<Webinar>> ChangePhotoAsync(Guid id, Stream image)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(image), "file", "file");

            var request = new HttpRequestMessage(HttpMethod.Post, URL + "/" + id.ToString() + "/Photo")
            {
                Content = formData
            };

            var response = await _apiClient.HttpClient.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<OperationResult<Webinar>>();
        }

        public Task<OperationResult<Webinar>> ConfirmAsync(ConfirmWebinarInput input)
            => _apiClient.PostAsync<ConfirmWebinarInput, OperationResult<Webinar>>(URL + "/Confirm", input);

        public Task<OperationResult<Webinar>> CreateAsync(CreateWebinarInput input)
            => _apiClient.PostAsync<CreateWebinarInput, OperationResult<Webinar>>(URL, input);

        public Task<OperationResult<IList<Webinar>>> GetAsync()
            => _apiClient.GetAsync<OperationResult<IList<Webinar>>>(URL);

        public Task<OperationResult<Webinar>> GetAsync(Guid id)
            => _apiClient.GetAsync<OperationResult<Webinar>>(URL + "/" + id.ToString());

        public Task<OperationResult<Webinar>> GetByProposalAsync(Guid proposalId)
            => _apiClient.GetAsync<OperationResult<Webinar>>(URL + "/Proposals/" + proposalId.ToString());

        public Task<OperationResult<Webinar>> UpdateAsync(UpdateWebinarInput input)
            => _apiClient.PutAsync<UpdateWebinarInput, OperationResult<Webinar>>(URL, input);
    }
}
