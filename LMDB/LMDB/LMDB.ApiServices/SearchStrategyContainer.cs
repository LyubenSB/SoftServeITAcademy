using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using System.Collections.Generic;

namespace LMDB.ApiServices
{
    public class SearchStrategyContainer : IStrategyContainer
    {
        private Dictionary<string, ICallProcessorStrategy> strategies;

        private IQueryBuilder<string> queryBuilder;
        private IClientCaller<string> clientCaller;
        private IObjectHandler<string, IResponseObject> objectHandler;
        private IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter;
        private CollectionCompositor collectionCompositor;

        public SearchStrategyContainer(SearchMovieStrategyHandler strategyHandler)
        {
            this.queryBuilder = strategyHandler.QueryBuilder;
            this.clientCaller = strategyHandler.ClientCaller;
            this.objectHandler = strategyHandler.ObjectHandler;
            this.objectConverter = strategyHandler.ObjectConverter;
            this.collectionCompositor = strategyHandler.CollectionCompositor;

            this.Strategies = new Dictionary<string, ICallProcessorStrategy>();

            Strategies.Add("movie", new SearchMovieCallStrategy(queryBuilder, clientCaller, objectHandler, objectConverter, collectionCompositor));

            Strategies.Add("tvseries", new SearchTVSeriesCallStrategy());
        }

        public Dictionary<string, ICallProcessorStrategy> Strategies { get => strategies; private set => strategies = value; }
    }
}