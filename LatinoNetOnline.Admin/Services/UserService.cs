using LatinoNetOnline.Admin.Helpers.QueryParams;
using LatinoNetOnline.Admin.Models;
using LatinoNetOnline.Admin.Models.Users;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IUserService
    {
        Task<OperationResult<UserQueryFilteredDto>> GetAllAsync();
        Task<OperationResult<UserQueryFilteredDto>> GetAllAsync(UserFilter filter);
        Task<OperationResult<IList<Role>>> GetAllRolesAsync();
        Task<OperationResult<UserRolesDto>> UpdateAsync(UserRolesDto userRoles);
    }

    public class UserService : IUserService
    {
        const string URL = "api/v1/identities-module/users/";

        private readonly IApiClient _apiClient;

        public UserService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<OperationResult<UserQueryFilteredDto>> GetAllAsync()
            => _apiClient.GetAsync<OperationResult<UserQueryFilteredDto>>(URL + "suggestions");

        public Task<OperationResult<UserQueryFilteredDto>> GetAllAsync(UserFilter filter)
            => _apiClient.GetAsync<OperationResult<UserQueryFilteredDto>>(URL + "suggestions" + filter.ToQueryParams());

        public Task<OperationResult<IList<Role>>> GetAllRolesAsync()
            => _apiClient.GetAsync<OperationResult<IList<Role>>>(URL + "GetAllRoles");

        public Task<OperationResult<UserRolesDto>> UpdateAsync(UserRolesDto userRoles)
            => _apiClient.PutAsync<UserRolesDto, OperationResult<UserRolesDto>>(URL + "edit", userRoles);

    }
}
