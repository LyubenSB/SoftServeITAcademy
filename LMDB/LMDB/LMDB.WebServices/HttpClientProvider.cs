using LMDB.CoreServices.Providers.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace LMDB.WebServices
{
    public class HttpClientProvider
    {
        private readonly IWriter writer;

        public async Task<string> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
                catch (HttpRequestException ex)
                {
                    writer.WriteLine("Http request was not succesfull");
                    writer.WriteLine($"Message:{ex.Message}");

                    return null;
                }
            }
        }
    }
}
