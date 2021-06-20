using LatinoNetOnline.Admin.Models.Notifications;

namespace LatinoNetOnline.Admin.Helpers.QueryParams
{
    static class DeviceQueryParams
    {
        public static string ToQueryParams(this DeviceFilter filter)
        {
            string queryParams = string.Empty;

            if (filter.UserId.HasValue)
                queryParams = QueryParamsHelper.AddParams(queryParams, $"userId={filter.UserId.Value}");

            if (!string.IsNullOrWhiteSpace(filter.OperativeSystem))
                queryParams = QueryParamsHelper.AddParams(queryParams, $"operativeSystem={filter.OperativeSystem}");

            if (!string.IsNullOrWhiteSpace(filter.Name))
                queryParams = QueryParamsHelper.AddParams(queryParams, $"name={filter.Name}");

            return queryParams;
        }
    }
}
