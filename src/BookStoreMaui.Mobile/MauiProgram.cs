using BookStoreMaui.Mobile.Services;
using BookStoreMaui.Shared.Interfaces;
using Microsoft.Extensions.Logging;
using Refit;


#if ANDROID
using Xamarin.Android.Net;
using System.Net.Security;
#elif IOS
using Security;
#endif


namespace BookStoreMaui.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<IBookService, ApiBookFetcher>()
                            .AddSingleton<ICommonService, CommonService>();

            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
            var refitSettings = new RefitSettings
            {
                HttpMessageHandlerFactory = () =>
                {
#if ANDROID
                    return new AndroidMessageHandler()
                    {
                        ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                        {
                            return certificate?.Issuer == "CN=localhost"
                            || sslPolicyErrors == SslPolicyErrors.None;
                        }
                    };
#elif IOS
                    return new NSUrlSessionHandler
                    {
                        TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) =>
                        url.StartsWith("http://localhost")
                    };
#endif

                    return null;
                }
            };

            services.AddRefitClient<IBookApi>(refitSettings)
                 .ConfigureHttpClient(SetHttpClient);
        }

        static void SetHttpClient(HttpClient httpClient)
        {
            string baseUrl = string.Empty;

            if (DeviceInfo.DeviceType == DeviceType.Physical)
            {
                baseUrl = "https://stxfvblr-7262.euw.devtunnels.ms/";
            }
            else
            {
                baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7262"
                                                                        : "https://localhost:7262";
            }


            httpClient.BaseAddress = new Uri(baseUrl);
        }
    }
}
