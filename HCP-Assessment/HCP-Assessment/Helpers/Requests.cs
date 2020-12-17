using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HCP_Assessment.Helpers
{
    public class Requests
    {
        private readonly HttpClient _httpClient;

        public Requests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<string> BaseSendAsyncRequest(string uri, HttpMethod method)
        {
            using var request = new HttpRequestMessage(method, uri);
            using var response = await _httpClient.SendAsync(request);
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }

        public async Task<string> GetRequest(string uri)
        {
            return await BaseSendAsyncRequest(uri, HttpMethod.Get);
        }

        public async Task<string> GetRequest(Uri uri)
        {
            return await GetRequest(uri.ToString());
        }

        public async Task<string> DeleteRequest(string uri)
        {
            return await BaseSendAsyncRequest(uri, HttpMethod.Delete);
        }

        public async Task<string> PutRequest(string uri, Dictionary<string, string> values)
        {
            using var response = await _httpClient.PutAsync(uri, new FormUrlEncodedContent(values));
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }

        public async Task<string> PostRequest(string uri, Dictionary<string, string> values = null)
        {
            using var response = await _httpClient.PostAsync(uri, values == null ? null : new FormUrlEncodedContent(values));
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }

        public async Task<string> PostRequest(string uri, string json = null)
        {
            using var response = await _httpClient.PostAsync(uri, json == null ? null : new StringContent(json, Encoding.UTF8, "application/json"));
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }

    }
}