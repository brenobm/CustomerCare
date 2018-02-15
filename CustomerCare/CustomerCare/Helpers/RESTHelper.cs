using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCare.Helpers
{
    public class RESTHelper
    {
        public static async Task<string> ExecuteGet(string uri, Dictionary<string, string> headers = null)
        {
            HttpClient client = new HttpClient
            {
                MaxResponseContentBufferSize = long.MaxValue
            };

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    client.DefaultRequestHeaders.Add(key, headers[key]);
                }
            }

            var response = await client.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> ExecutePost(string uri, string jsonBody, Dictionary<string, string> headers = null)
        {
            HttpClient client = new HttpClient
            {
                MaxResponseContentBufferSize = long.MaxValue
            };

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    client.DefaultRequestHeaders.Add(key, headers[key]);
                }
            }

            HttpContent jsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");


            var response = await client.PostAsync(uri, jsonContent);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> ExecutePut(string uri, int id, string jsonBody, Dictionary<string, string> headers = null)
        {
            HttpClient client = new HttpClient
            {
                MaxResponseContentBufferSize = long.MaxValue
            };

            client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "PUT");

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    client.DefaultRequestHeaders.Add(key, headers[key]);
                }
            }

            HttpContent jsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");


            var response = await client.PostAsync($"{uri}/{id}", jsonContent);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> ExecuteDelete(string uri, int id, Dictionary<string, string> headers = null)
        {
            HttpClient client = new HttpClient
            {
                MaxResponseContentBufferSize = long.MaxValue
            };

            client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "DELETE");

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    client.DefaultRequestHeaders.Add(key, headers[key]);
                }
            }

            HttpContent jsonContent = new StringContent("", Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{uri}/{id}", jsonContent);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
