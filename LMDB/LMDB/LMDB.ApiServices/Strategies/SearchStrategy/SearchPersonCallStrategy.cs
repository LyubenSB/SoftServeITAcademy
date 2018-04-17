using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies.SearchStrategy
{
    //trq se injectne querybuilder za search movie i objectconverter za movie
    public class SearchPersonCallStrategy :  ICallProcessorStrategy<string>
    {
        private readonly StrategyServices strategyServices;
        private readonly IQueryBuilder<string> queryBuilder;
        private readonly IObjectHandler<string, PersonResponseObject> objectHandler;

        public SearchPersonCallStrategy(StrategyServices strategyServices, IQueryBuilder<string> queryBuilder, IObjectHandler<string, PersonResponseObject> objectHandler) 
        {
            this.strategyServices = strategyServices;
            this.queryBuilder = queryBuilder;
            this.objectHandler = objectHandler;
        }
        public string  PersonId { get; private set; }

        public void ExectuteStrategy(string parameter)
        {
            string searchCallQuery = this.queryBuilder.BuildQuery(parameter);

            string responseString = this.strategyServices.ClientCaller.CallClient(searchCallQuery).Result;

            //person handle object
            this.objectHandler.HandleObject(responseString);

            var handledObjects = this.objectHandler.HandledResponseObjects.FirstOrDefault();
            int personId = handledObjects.Id;
            this. PersonId = personId.ToString();
        }
    }
}
