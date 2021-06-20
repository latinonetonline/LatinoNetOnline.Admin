namespace LatinoNetOnline.Admin.Helpers.QueryParams
{
    public static class QueryParamsHelper
    {
        public static string AddParams(string url, string param)
        {
            if (!url.Contains("?"))
                url += "?" + param;
            else
                url += "&" + param;

            return url;
        }
    }
}
