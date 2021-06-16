using LatinoNetOnline.Admin.Models;

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface ILinkService
    {
        Task<OperationResult<Link>> CreateAsync(Link link);
        Task<OperationResult> DeleteAsync(Link link);
        Task<OperationResult<IList<Link>>> GetAllAsync();
        Task<OperationResult<Link>> UpdateAsync(Link link);
    }

    public class LinkService : ILinkService
    {
        const string URL = "api/v1/links-module/links";

        private readonly IApiClient _apiClient;

        public LinkService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<IList<Link>>> GetAllAsync()
            => _apiClient.GetAsync<OperationResult<IList<Link>>>(URL);

        public Task<OperationResult<Link>> CreateAsync(Link link)
            => _apiClient.PostAsync<Link, OperationResult<Link>>(URL, link);

        public Task<OperationResult<Link>> UpdateAsync(Link link)
            => _apiClient.PutAsync<Link, OperationResult<Link>>(URL, link);

        public Task<OperationResult> DeleteAsync(Link link)
            => _apiClient.DeleteAsync<OperationResult>(Path.Combine(URL, link.Name));
    }
}
