using LatinoNetOnline.Admin.Helpers.QueryParams;
using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Notifications;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    interface IDeviceService
    {
        Task<OperationResult> DeleteDeviceAsync(Guid deviceId);
        Task<OperationResult<IList<Device>>> GetAllAsync(DeviceFilter filter);
        Task<OperationResult> SendNotificationAsync(SendNotificationInput input);
        Task<OperationResult<Device>> SubscribeDeviceAsync(SubscriptionDeviceInput input);
    }

    class DeviceService : IDeviceService
    {
        const string URL = "api/v1/notifications-module/devices";

        private readonly IApiClient _apiClient;

        public DeviceService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<IList<Device>>> GetAllAsync(DeviceFilter filter)
            => _apiClient.GetAsync<OperationResult<IList<Device>>>(URL + filter.ToQueryParams());

        public Task<OperationResult<Device>> SubscribeDeviceAsync(SubscriptionDeviceInput input)
            => _apiClient.PostAsync<SubscriptionDeviceInput, OperationResult<Device>>(URL + "/subscribe", input);

        public Task<OperationResult> SendNotificationAsync(SendNotificationInput input)
            => _apiClient.PostAsync<SendNotificationInput, OperationResult>(URL + "/sendnotification", input);


        public Task<OperationResult> DeleteDeviceAsync(Guid deviceId)
            => _apiClient.DeleteAsync<OperationResult>(URL + "/"+ deviceId.ToString());
    }
}
