using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies.SearchStrategy
{
    public class SearchStrategyServices
    {
        private IClientCaller<string> clientCaller;
        private IObjectHandler<string, IResponseObject> objectHandler;
        private CollectionCompositor collectionCompositor;

        public SearchStrategyServices(IClientCaller<string> clientCaller, IObjectHandler<string, IResponseObject> objectHandler, CollectionCompositor collectionCompositor)
        {
            this.clientCaller = clientCaller;
            this.objectHandler = objectHandler;
            this.collectionCompositor = collectionCompositor;
        }

        public IClientCaller<string> ClientCaller { get => clientCaller; }
        public IObjectHandler<string, IResponseObject> ObjectHandler { get => objectHandler; }
        public CollectionCompositor CollectionCompositor { get => collectionCompositor; }
    }
}
