using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public class CallProcessor
    {
        private IQueryBuilder queryBuilder;
        private IClientCaller<string> clientCaller;

        public CallProcessor(IQueryBuilder queryBuilder, IClientCaller<string> clientCaller)
        {
            this.queryBuilder = queryBuilder;
            this.clientCaller = clientCaller;
        }

        async Task<string> ProcessSearchCall(string searchParameter)
        {
            string searchCallQuery = this.queryBuilder.BuildSearchQuery(searchParameter);

            string responseString = await this.clientCaller.CallClient(searchCallQuery);

            
        }
    }
}
