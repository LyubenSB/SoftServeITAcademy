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

namespace LMDB.ApiServices.Strategies
{
    public class GetMovieDetailsCallStrategy : ICallProcessorStrategy<string>
    {
        private readonly StrategyServices strategyServices;
        private readonly IQueryBuilder<string> queryBuilder;
        private readonly IObjectHandler<string, DetailedMovieResponseObject> objectHandler;
        private readonly IObjectConverter<DetailedMovieResponseObject, IMotionPictureData> objectConverter;

        public GetMovieDetailsCallStrategy(StrategyServices strategyServices, IQueryBuilder<string> queryBuilder, IObjectHandler<string, DetailedMovieResponseObject> objectHandler, IObjectConverter<DetailedMovieResponseObject, IMotionPictureData> objectConverter)
        {
            this.strategyServices = strategyServices;
            this.queryBuilder = queryBuilder;
            this.objectHandler = objectHandler;
            this.objectConverter = objectConverter;
        }

        public void ExectuteStrategy(string parameter)
        {
            //query with id
            string searchCallQuery = this.queryBuilder.BuildQuery(parameter);
            //http call
            string responseString = this.strategyServices.ClientCaller.CallClient(searchCallQuery).Result;
            //jsonhandler
            this.objectHandler.HandleObject(responseString);
            //handled objects
            var handledObjects = this.objectHandler.HandledResponseObjects.FirstOrDefault();
            //converting objects
            this.objectConverter.Convert(handledObjects);
            //converted objects
            var convertedObjects = this.objectConverter.ConvertedObjects;
            //adding to memory
            this.strategyServices.CollectionCompositor.AddDetailedObject(convertedObjects);
        }
    }
}
