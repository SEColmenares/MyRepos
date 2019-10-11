using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVC_Core.Client

{
    public partial class ApiClient {
        private readonly HttpClient httpClient;
        private Uri BaseEndPoint;

        public ApiClient (Uri baseEndPoint) {
            if (baseEndPoint == null) {
                throw new ArgumentNullException ("baseEndPoint");
            }
            BaseEndPoint = baseEndPoint;
            httpClient = new HttpClient ();
        }

        private async Task<T> GetAsync<T> (Uri requestURL) {

            addHeaders(); 
            var response = await httpClient.GetAsync (requestURL, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode ();
            var data = await response.Content.ReadAsStringAsync (); // leo el objeto de respuesta serializado
            return JsonConvert.DeserializeObject<T> (data);

        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings {
            get {
                return new JsonSerializerSettings {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private HttpContent CreateHttpContent<T> (T content) {
            var json = JsonConvert.SerializeObject (content, MicrosoftDateFormatSettings);
            return new StringContent (json, Encoding.UTF8, "application/json");
        }

        private async Task<Message<T>> PostAsync<T> (Uri requestURL, T content) {

            addHeaders(); 
            var response = await httpClient.PostAsync (requestURL.ToString (), CreateHttpContent<T> (content));
            response.EnsureSuccessStatusCode ();
            var data = await response.Content.ReadAsStringAsync ();
            return JsonConvert.DeserializeObject<Message<T>> (data);
        }

        private async Task<Message<T1>> PostAsync<T1, T2> (Uri requestUrl, T2 content) {
            
            addHeaders(); 
            var response = await httpClient.PostAsync (requestUrl.ToString (), CreateHttpContent<T2> (content));
            response.EnsureSuccessStatusCode ();
            var data = await response.Content.ReadAsStringAsync ();
            return JsonConvert.DeserializeObject<Message<T1>> (data);
        }

        private Uri CreateRequestUri(string relativePath, string querystring="")
        {
            var endpoint = new Uri(BaseEndPoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = querystring;
            return uriBuilder.Uri;
        }

        private void addHeaders()  
        {  
            httpClient.DefaultRequestHeaders.Remove("userIP");  
            httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");  
        } 

    }
}