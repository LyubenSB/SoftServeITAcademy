using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies.SearchStrategy
{
    //trq se injectne querybuilder za search movie i objectconverter za movie
    public class SearchMovieCallStrategy :  ICallProcessorStrategy
    {
        private readonly SearchStrategyServices strategyServices;
        private readonly IQueryBuilder<string> queryBuilder;
        private readonly IObjectHandler<string, IResponseObject> objectHandler;
        private readonly IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter;

        public SearchMovieCallStrategy(SearchStrategyServices strategyServices, IQueryBuilder<string> queryBuilder, IObjectHandler<string, IResponseObject> objectHandler, IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>> objectConverter) 
        {
            this.strategyServices = strategyServices;
            this.queryBuilder = queryBuilder;
            this.objectHandler = objectHandler;
            this.objectConverter = objectConverter;
        }

        public void ExectuteStrategy(string parameter)
        {
            string searchCallQuery = this.queryBuilder.BuildQuery(parameter);

            string responseString = this.strategyServices.ClientCaller.CallClient(searchCallQuery).Result;

            this.objectHandler.HandleObject(responseString);

            var handledObjects = this.objectHandler.HandledResponseObjects;

            this.objectConverter.Convert(handledObjects);

            var convertedObjects = this.objectConverter.ConvertedObjects;

            this.strategyServices.CollectionCompositor.Composite(convertedObjects);
        }
    }
}
