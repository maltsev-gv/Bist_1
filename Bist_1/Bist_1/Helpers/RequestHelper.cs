using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Bist_1.ExtensionMethods;
using Bist_1.Models;

namespace Bist_1.Helpers
{
    public class RequestHelper
    {
        public static async Task<ResponseInfo> Post(string url, object model, Dictionary<string, string> headers = null)
        {
            var response = new ResponseInfo();
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromMinutes(1) })
            {
                headers?.ForEach(pair => httpClient.DefaultRequestHeaders.Add(pair.Key, pair.Value));
                var strContent = JsonHelper.GetSerializedString(model);
                HttpContent httpContent = new StringContent(strContent);
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var httpResponse = await httpClient.PostAsync(url, httpContent);
                response.StatusCode = (int)httpResponse.StatusCode;
                response.Headers = httpResponse.Content.Headers.ToDictionary(h => h.Key, h => h.Value.FirstOrDefault());
                response.Content = await httpResponse.Content.ReadAsStringAsync();
            }

            return response;
        }

        public static async Task<ResponseInfo> Get(string url, Dictionary<string, string> headers = null)
        {
            var response = new ResponseInfo();
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromMinutes(1) })
            {
                headers?.ForEach(pair => httpClient.DefaultRequestHeaders.Add(pair.Key, pair.Value));

                var httpResponse = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.StatusCode = (int)httpResponse.StatusCode;
                response.Headers = httpResponse.Content.Headers.ToDictionary(h => h.Key, h => h.Value.FirstOrDefault());
                response.Content = await httpResponse.Content.ReadAsStringAsync();
            }

            return response;
        }
    }
}
