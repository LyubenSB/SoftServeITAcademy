using LMDB.ApiServices.Contratcts;
using LMDB.WebServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientCaller : IClientCaller<string>
    {
        private readonly IClientProvider<string> clientProvider;

        public HttpClientCaller(IClientProvider<string> clientProvider)
        {
            this.clientProvider = clientProvider;
        }

        //vryshta jsona
        public async Task<string> CallClient(string url)
        {
            string httpResponse = await this.clientProvider.HttpGetAsync(url);
            return httpResponse;
        }
    }
}
