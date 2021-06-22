using LatinoNetOnline.Admin.Models.Notifications;

using System.Linq;

namespace LatinoNetOnline.Admin.Helpers.QueryParams
{
    static class DeviceQueryParams
    {
        public static string ToQueryParams(this DeviceFilter filter)
        {
            string queryParams = string.Empty;

            if (filter.Users?.Any() ?? false)
            {
                foreach (var userId in filter.Users)
                {
                    queryParams = QueryParamsHelper.AddParams(queryParams, $"users={userId}");
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.OperativeSystem))
                queryParams = QueryParamsHelper.AddParams(queryParams, $"operativeSystem={filter.OperativeSystem}");

            if (!string.IsNullOrWhiteSpace(filter.Name))
                queryParams = QueryParamsHelper.AddParams(queryParams, $"name={filter.Name}");

            return queryParams;
        }
    }
}
