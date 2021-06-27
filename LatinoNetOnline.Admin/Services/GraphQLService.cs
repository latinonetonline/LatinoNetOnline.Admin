using GraphQL;
using GraphQL.Client.Http;

using ModernHttpClient;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Services
{
    public interface IGraphQLService
    {
        Task<T> ExceuteMutationAsync<T>(Uri endpoint, string graphQLQueryType, string completeQueryString, string accessToken);
        Task<T> ExceuteQueryAsync<T>(Uri endpoint, string graphQLQueryType, string completeQueryString, string accessToken);
        Task<IEnumerable<T>> ExceuteQueryReturnListAsync<T>(Uri endpoint, string graphQLQueryType, string completeQueryString, string accessToken);
    }

    public class GraphQLService : IGraphQLService
    {
        protected readonly GraphQLHttpClient graphQLHttpClient;

        public GraphQLService()
        {
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                HttpMessageHandler = new NativeMessageHandler()
            };

            graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new GraphQL.Client.Serializer.SystemTextJson.SystemTextJsonSerializer());
        }

        public async Task<T> ExceuteQueryAsync<T>(Uri endpoint, string graphQLQueryType, string completeQueryString, string accessToken)
        {
            try
            {
                graphQLHttpClient.Options.EndPoint = endpoint;
                graphQLHttpClient.HttpClient.DefaultRequestHeaders.Remove("Authorization");
                graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {accessToken}");

                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };

                var response = await graphQLHttpClient.SendQueryAsync<object>(request);

                var stringResult = response.Data.ToString();
                stringResult = stringResult.Replace($"\"{graphQLQueryType}\":", string.Empty);
                stringResult = stringResult.Remove(0, 1);
                stringResult = stringResult.Remove(stringResult.Length - 1, 1);

                var result = JsonSerializer.Deserialize<T>(stringResult);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> ExceuteQueryReturnListAsync<T>(Uri endpoint, string graphQLQueryType, string completeQueryString, string accessToken)
        {
            try
            {
                graphQLHttpClient.Options.EndPoint = endpoint;
                graphQLHttpClient.HttpClient.DefaultRequestHeaders.Remove("Authorization");
                graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {accessToken}");

                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };

                var response = await graphQLHttpClient.SendQueryAsync<object>(request);

                var stringResult = response.Data.ToString();
                stringResult = stringResult.Replace($"\"{graphQLQueryType}\":", string.Empty);
                stringResult = stringResult.Remove(0, 1);
                stringResult = stringResult.Remove(stringResult.Length - 1, 1);

                var result = JsonSerializer.Deserialize<List<T>>(stringResult);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> ExceuteMutationAsync<T>(Uri endpoint, string graphQLQueryType, string completeQueryString, string accessToken)
        {
            try
            {
                graphQLHttpClient.Options.EndPoint = endpoint;
                graphQLHttpClient.HttpClient.DefaultRequestHeaders.Remove("Authorization");
                graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {accessToken}");

                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };

                var response = await graphQLHttpClient.SendMutationAsync<object>(request);

                var stringResult = response.Data.ToString();
                stringResult = stringResult.Replace($"\"{graphQLQueryType}\":", string.Empty);
                stringResult = stringResult.Remove(0, 1);
                stringResult = stringResult.Remove(stringResult.Length - 1, 1);

                var result = JsonSerializer.Deserialize<T>(stringResult);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
