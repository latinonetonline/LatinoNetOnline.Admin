using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.UnavailableDates;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{

    public interface IUnavailableDateService
    {
        Task<OperationResult<IList<UnavailableDate>>> GetAllAsync();
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult<UnavailableDate>> CreateAsync(CreateUnavailableDateInput input);
        Task<OperationResult<UnavailableDate>> UpdateAsync(UnavailableDate input);


    }

    public class UnavailableDateService : IUnavailableDateService
    {
        const string URL = "api/v1/webinars-module/unavailabledates";

        private readonly IApiClient _apiClient;

        public UnavailableDateService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public Task<OperationResult<UnavailableDate>> CreateAsync(CreateUnavailableDateInput input)
            => _apiClient.PostAsync<CreateUnavailableDateInput, OperationResult<UnavailableDate>>(URL, input);

        public Task<OperationResult> DeleteAsync(Guid id)
            => _apiClient.DeleteAsync<OperationResult>(URL + "/" + id.ToString());

        public Task<OperationResult<IList<UnavailableDate>>> GetAllAsync()
            => _apiClient.GetAsync<OperationResult<IList<UnavailableDate>>>(URL);

        public Task<OperationResult<UnavailableDate>> UpdateAsync(UnavailableDate input)
            => _apiClient.PutAsync<UnavailableDate, OperationResult<UnavailableDate>>(URL, input);
    }
}
