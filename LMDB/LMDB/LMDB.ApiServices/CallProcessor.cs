using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public class CallProcessor : ICallProcessor
    {
        private IQueryBuilder queryBuilder;
        private IClientCaller<string> clientCaller;
        private IObjectHandler<string, IResponseObject> objectHandler;
        private IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter;
        private CollectionCompositor collectionCompositor;

        public CallProcessor(IQueryBuilder queryBuilder, IClientCaller<string> clientCaller,
            IObjectHandler<string, IResponseObject> objectHandler,
            IObjectConverter<ICollection<IResponseObject>,
                ICollection<IMotionPicture>> objectConverter,
            CollectionCompositor collectionCompositor)
        {
            this.queryBuilder = queryBuilder;
            this.clientCaller = clientCaller;
            this.objectHandler = objectHandler;
            this.objectConverter = objectConverter;
            this.collectionCompositor = collectionCompositor;
        }

        public void ProcessSearchCall(string searchParameter)
        {
            string searchCallQuery = this.queryBuilder.BuildSearchQuery(searchParameter);

            string responseString = this.clientCaller.CallClient(searchCallQuery).Result;

            this.objectHandler.HandleObject(responseString);

            var handledObjects = this.objectHandler.HandledResponseObjects;

            this.objectConverter.Convert(handledObjects);

            var convertedObjects = this.objectConverter.ConvertedObjects;

            this.collectionCompositor.Composite(convertedObjects);
        }

        
    }
}
