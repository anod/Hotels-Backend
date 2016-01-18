using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNet.Http;

using HotelsWizard.Models.Response;

namespace HotelsWizard.Connector.Rest
{
    public class RestClient
    {
        private ILogger _logger;
        private HttpClient HttpClient;
        private string Endpoint;

        public ILogger Logger {
            get { return _logger; }
            set { _logger = value; }
        }

        public RestClient(String endpoint, HttpClient httpClient) {
            HttpClient = httpClient == null ? new HttpClient() : httpClient;
            Endpoint = endpoint;
        }

        public async Task<T> Get<T>(String path, IReadableStringCollection query) {
            return await Send<T>(HttpMethod.Get, path, query, null);
        }

        public async Task<T> Post<T>(String path, IReadableStringCollection query, HttpContent content) {
            return await Send<T>(HttpMethod.Get, path, query, content);
        }

        private async Task<T> Send<T>(HttpMethod method, String path, IReadableStringCollection query, HttpContent content) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(Endpoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestUri = path;
                if (query != null) {
                    requestUri += '?' + query.ToString();
                }
                var request = new HttpRequestMessage(method, requestUri);
                if (content != null) {
                    request.Content = content;
                }
                if (Logger != null) {
                    Logger.LogInformation("[RestClient] Request: {0}{1}", Endpoint, requestUri);
                }
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode) {
                    var stream = await response.Content.ReadAsStreamAsync();
                    using (StreamReader sr = new StreamReader(stream))
                    using (JsonReader reader = new JsonTextReader(sr)) {
                        JsonSerializer serializer = new JsonSerializer();
                        T responseObject = serializer.Deserialize<T>(reader);

                        return responseObject;
                    }
                } else if (response.StatusCode < HttpStatusCode.InternalServerError) {
                    var stream = await response.Content.ReadAsStreamAsync();
                    using (StreamReader sr = new StreamReader(stream))
                    using (JsonReader reader = new JsonTextReader(sr)) {
                        JsonSerializer serializer = new JsonSerializer();
                        ErrorResponse errorObject = serializer.Deserialize<ErrorResponse>(reader);
                        throw new RestException(errorObject);
                    }
                } else {
                    ErrorResponse errorObject = new ErrorResponse();
                    errorObject.Meta = new ErrorMeta((int)response.StatusCode, 0, "Generic error has occurred on the server.");
                    throw new RestException(errorObject);
                }
            }
        }
    }
}
