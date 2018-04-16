using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ApiServices.Strategies.SearchStrategy;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMDB.ApiServices.ObjectHandlers;

namespace LMDB.ApiServices
{
    public class InitialDataGetter
    {
        private readonly StrategyServices strategyServices;
        private readonly GenreQueryBuilder queryBuilder;
        private readonly GenreObjectJSONHandler objectHandler;
        private readonly GenreCollectionHandler genreCollectionHandler;

        public InitialDataGetter(StrategyServices strategyServices, GenreQueryBuilder queryBuilder, GenreObjectJSONHandler objectHandler, GenreCollectionHandler genreCollectionHandler)
        {
            this.strategyServices = strategyServices;
            this.queryBuilder = queryBuilder;
            this.objectHandler = objectHandler;
            this.genreCollectionHandler = genreCollectionHandler;
        }

        public void GetData()
        {
            string searchCallQuery = this.queryBuilder.BuildQuery();

            string responseString = this.strategyServices.ClientCaller.CallClient(searchCallQuery).Result;

            this.objectHandler.HandleObject(responseString);

            var handledObjects = this.objectHandler.HandledResponseObjects;

            this.genreCollectionHandler.Composite(handledObjects);
        }
    }
}
