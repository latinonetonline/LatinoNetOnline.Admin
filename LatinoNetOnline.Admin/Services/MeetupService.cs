using Blazored.LocalStorage;

using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Meetups;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    interface IMeetupService
    {
        Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync();
        Task<MeetupUser> GetSelfAsync();
    }

    public class MeetupService : IMeetupService
    {
        const string URL = "api/v1/callforspeakers-module/meetup/GetEvents";
        private readonly Uri GraphQLEndpoint = new Uri("https://api.meetup.com/gql");

        private readonly IApiClient _apiClient;
        private readonly IGraphQLService _graphQLService;
        private readonly ISyncLocalStorageService _localStorageService;

        public MeetupService(IApiClient apiClient, ISyncLocalStorageService localStorageService, IGraphQLService graphQLService)
        {
            _apiClient = apiClient;
            _graphQLService = graphQLService;
            _localStorageService = localStorageService;
        }

        public Task<OperationResult<IList<MeetupEvent>>> GetEventsAsync()
            => _apiClient.GetAsync<OperationResult<IList<MeetupEvent>>>(URL);

        public async Task<MeetupUser> GetSelfAsync()
        {
            var token = _localStorageService.GetItemAsString("meetup_access_token");
            var user = await _graphQLService.ExceuteQueryAsync<MeetupUser>(GraphQLEndpoint, "self", "query { self { id name } }", token);

            return user;
        }





    }
}
