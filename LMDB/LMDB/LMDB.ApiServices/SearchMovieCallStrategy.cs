using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class SearchMovieCallStrategy : ICallProcessorStrategy
    {
        private IQueryBuilder<string> queryBuilder;
        private IClientCaller<string> clientCaller;
        private IObjectHandler<string, IResponseObject> objectHandler;
        private IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter;
        private CollectionCompositor collectionCompositor;

        public SearchMovieCallStrategy(IQueryBuilder<string> queryBuilder, IClientCaller<string> clientCaller,
            IObjectHandler<string, IResponseObject> objectHandler, IObjectConverter<ICollection<IResponseObject>,
                ICollection<IMotionPicture>> objectConverter, CollectionCompositor collectionCompositor)
        {
            this.queryBuilder = queryBuilder;
            this.clientCaller = clientCaller;
            this.objectHandler = objectHandler;
            this.objectConverter = objectConverter;
            this.collectionCompositor = collectionCompositor;
        }

        public void ExectuteStrategy(string parameter)
        {
            string searchCallQuery = this.queryBuilder.BuildQuery(parameter);

            string responseString = this.clientCaller.CallClient(searchCallQuery).Result;

            this.objectHandler.HandleObject(responseString);

            var handledObjects = this.objectHandler.HandledResponseObjects;

            this.objectConverter.Convert(handledObjects);

            var convertedObjects = this.objectConverter.ConvertedObjects;

            this.collectionCompositor.Composite(convertedObjects);
        }
    }
}
