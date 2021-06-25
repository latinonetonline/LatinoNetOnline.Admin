using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Meetups;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    interface IMeetupService
    {
        Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync();
    }

    public class MeetupService : IMeetupService
    {
        const string URL = "api/v1/callforspeakers-module/meetup/GetEvents";

        private readonly IApiClient _apiClient;

        public MeetupService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync()
            => _apiClient.GetAsync<OperationResult<IList<MeetupEvent>>>(URL);
    }
}
