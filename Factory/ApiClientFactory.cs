using System;
using System.Threading;
using MVC_Core.Client;
using MVC_Core.Utility;

namespace MVC_Core.Factory
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        private static Lazy<ApiClient> restClient =  new Lazy<ApiClient>(
            () => new ApiClient(apiUri), LazyThreadSafetyMode.ExecutionAndPublication);      

        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiURL);
        }

        public static ApiClient Instance
        {
            get 
            {
                return restClient.Value;
            }
        }
        
    }
}