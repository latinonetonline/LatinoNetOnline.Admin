using LatinoNetOnline.Admin.Models.Proposals;

namespace LatinoNetOnline.Admin.Helpers.QueryParams
{
    static class ProposalQueryParams
    {
        public static string ToQueryParams(this ProposalFilter filter)
        {
            string queryParams = string.Empty;

            if (!string.IsNullOrWhiteSpace(filter.Title))
                queryParams = QueryParamsHelper.AddParams(queryParams, $"title={filter.Title}");

            if (filter.Date.HasValue)
                queryParams = QueryParamsHelper.AddParams(queryParams, $"date={filter.Date.Value.ToString("yyyy-MM-dd")}");

            if (filter.IsActive.HasValue)
                queryParams = QueryParamsHelper.AddParams(queryParams, $"isActive={filter.IsActive.Value}");

            if (filter.Oldest.HasValue)
                queryParams = QueryParamsHelper.AddParams(queryParams, $"oldest={filter.Oldest.Value}");


            return queryParams;
        }
    }
}
