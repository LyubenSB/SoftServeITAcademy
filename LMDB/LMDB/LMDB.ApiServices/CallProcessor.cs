using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public class CallProcessor : ICallProcessor<string>
    {
        private IQueryBuilder queryBuilder;
        private IClientCaller<string> clientCaller;
        private IObjectHandler objectHandler;

        public CallProcessor(IQueryBuilder queryBuilder, IClientCaller<string> clientCaller,IObjectHandler objectHandler)
        {
            this.queryBuilder = queryBuilder;
            this.clientCaller = clientCaller;
            this.objectHandler = objectHandler;
        }

        public async Task<string> ProcessSearchCall(string searchParameter)
        {
            string searchCallQuery = this.queryBuilder.BuildSearchQuery(searchParameter);

            string responseString = await this.clientCaller.CallClient(searchCallQuery);

            //DO TUK STIGNAH
            return "sa";
        }

        
    }
}
