using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies.SearchStrategy
{
    public class StrategyServices
    {
        private IClientCaller<string> clientCaller;
        private RecievedDataHandler collectionCompositor;

        public StrategyServices(IClientCaller<string> clientCaller,  RecievedDataHandler collectionCompositor)
        {
            this.clientCaller = clientCaller;
            this.collectionCompositor = collectionCompositor;
        }

        public IClientCaller<string> ClientCaller { get => clientCaller; }
        public RecievedDataHandler CollectionCompositor { get => collectionCompositor; }
    }
}
