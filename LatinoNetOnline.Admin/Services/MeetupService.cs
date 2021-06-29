using Blazored.LocalStorage;

using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Meetups;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    interface IMeetupService
    {
        Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync();

    }

    public class MeetupService : IMeetupService
    {
        const string URL = "api/v1/events-module/meetup/GetEvents";

        private readonly IApiClient _apiClient;
        private readonly ISyncLocalStorageService _localStorageService;

        public MeetupService(IApiClient apiClient, ISyncLocalStorageService localStorageService)
        {
            _apiClient = apiClient;
            _localStorageService = localStorageService;
        }

        public Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync()
            => _apiClient.GetAsync<OperationResult<IList<MeetupEvent>>>(URL);


    }
}
