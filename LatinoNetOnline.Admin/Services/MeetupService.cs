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
        Task<OperationResult<MeetupEvent>> GetEventAsync(long meetupId);

    }

    public class MeetupService : IMeetupService
    {
        const string URL = "api/v1/events-module/meetup";

        private readonly IApiClient _apiClient;

        public MeetupService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync()
            => _apiClient.GetAsync<OperationResult<IList<MeetupEvent>>>(URL);

        public Task<OperationResult<MeetupEvent>> GetEventAsync(long meetupId)
            => _apiClient.GetAsync<OperationResult<MeetupEvent>>(URL + "/" + meetupId);


    }
}
