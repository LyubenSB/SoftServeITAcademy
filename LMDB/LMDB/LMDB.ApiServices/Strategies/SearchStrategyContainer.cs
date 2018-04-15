using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ApiServices.Strategies.SearchStrategy;
using LMDB.ObjectModels.Contracts;
using Ninject;
using System.Collections.Generic;

namespace LMDB.ApiServices.Strategies
{
    public class SearchStrategyContainer : IStrategyContainer
    {
        private Dictionary<string, ICallProcessorStrategy> strategies;


        public SearchStrategyContainer([Named("SearchMovieStrategy")] ICallProcessorStrategy movieStrategy,
            [Named("SearchTVSeriesStrategy")]ICallProcessorStrategy tvStrategy)
        {
            this.Strategies = new Dictionary<string, ICallProcessorStrategy>();

            Strategies.Add("movie", movieStrategy);

            Strategies.Add("tvseries", tvStrategy);
        }

        public Dictionary<string, ICallProcessorStrategy> Strategies { get => strategies; private set => strategies = value; }
    }
}