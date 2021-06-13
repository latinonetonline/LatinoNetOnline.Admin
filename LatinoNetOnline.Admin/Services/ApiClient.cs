using LatinoNetOnline.Admin.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IApiClient
    {
        Task<TResponse> GetAsync<TResponse>(string requestUri) where TResponse : OperationResult;
        Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult;
        Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult;
        Task<TResponse> DeleteAsync<TResponse>(string requestUri) where TResponse : OperationResult;
        Task<TResponse> DeleteAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult;
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResponse> GetAsync<TResponse>(string requestUri) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.GetAsync(requestUri);
            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(requestUri, requestBody);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(requestUri, requestBody);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string requestUri) where TResponse : OperationResult
        {
            var httpResponse = await _httpClient.DeleteAsync(requestUri);
            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(string requestUri, TRequest requestBody) where TResponse : OperationResult
        {
            return await PostAsync<TRequest, TResponse>(requestUri, requestBody);
        }
    }
}
