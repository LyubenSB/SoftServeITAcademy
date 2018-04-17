using LMDB.WebServices.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LMDB.WebServices
{
    public class HttpClientProvider : IClientProvider<string>
    {

        public async Task<string> HttpGetAsync(string url)
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                client.Dispose();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Http request was not succesfull");
                Console.WriteLine($"Message:{ex.Message}");

                client.Dispose();
                return null;
            }

        }
    }
}
