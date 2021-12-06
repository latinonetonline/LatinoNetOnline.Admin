using Blazored.LocalStorage;

using LatinoNetOnline.Admin.Security;
using LatinoNetOnline.Admin.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Radzen;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("api", o => o.BaseAddress = new(builder.Configuration["Backend"]))
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            authorizedUrls: new[] { builder.Configuration["Backend"] },
                            scopes: new[] { "IdentityServerApi" });

                    return handler;
                });

            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));

            builder.Services
                .AddOidcAuthentication(options =>
                {
                    builder.Configuration.Bind("oidc", options.ProviderOptions);
                    options.UserOptions.RoleClaim = "role";
                })
                .AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            builder.Services.AddScoped<ILinkService, LinkService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IProposalService, ProposalService>();
            builder.Services.AddScoped<IMeetupService, MeetupService>();
            builder.Services.AddScoped<IWebinarService, WebinarService>();
            builder.Services.AddScoped<IMetricoolService, MetricoolService>();
            builder.Services.AddScoped<IUnavailableDateService, UnavailableDateService>();

            builder.Services.AddScoped<IApiClient, ApiClient>();

            builder.Services.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.IgnoreNullValues = true;
                config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                config.JsonSerializerOptions.WriteIndented = false;

            });

            await builder.Build().RunAsync();
        }
    }
}
