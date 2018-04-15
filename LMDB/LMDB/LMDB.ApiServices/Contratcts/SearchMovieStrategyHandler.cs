using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public class SearchMovieStrategyHandler
    {
        private IQueryBuilder<string> queryBuilder;
        private IClientCaller<string> clientCaller;
        private IObjectHandler<string, IResponseObject> objectHandler;
        private IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter;
        private CollectionCompositor collectionCompositor;

        public SearchMovieStrategyHandler(IQueryBuilder<string> queryBuilder, IClientCaller<string> clientCaller, IObjectHandler<string, IResponseObject> objectHandler, IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter, CollectionCompositor collectionCompositor)
        {
            this.queryBuilder = queryBuilder;
            this.clientCaller = clientCaller;
            this.objectHandler = objectHandler;
            this.objectConverter = objectConverter;
            this.collectionCompositor = collectionCompositor;
        }

        public IQueryBuilder<string> QueryBuilder { get => queryBuilder;}
        public IClientCaller<string> ClientCaller { get => clientCaller;}
        public IObjectHandler<string, IResponseObject> ObjectHandler { get => objectHandler;}
        public IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> ObjectConverter { get => objectConverter;}
        public CollectionCompositor CollectionCompositor { get => collectionCompositor;}
    }
}
