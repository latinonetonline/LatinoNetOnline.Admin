using LatinoNetOnline.Admin.Models.Users;

using System.Linq;

namespace LatinoNetOnline.Admin.Helpers.QueryParams
{
    public static class UserQueryParams
    {
        public static string ToQueryParams(this UserFilter filter)
        {
            string queryParams = string.Empty;

            if (!string.IsNullOrWhiteSpace(filter.Search))
                queryParams = QueryParamsHelper.AddParams(queryParams, $"search={filter.Search}");

            if (filter.Users?.Any() ?? false)
            {
                foreach (var userId in filter.Users)
                {
                    queryParams = QueryParamsHelper.AddParams(queryParams, $"users={userId}");
                }
            }


            return queryParams;
        }
    }
}
