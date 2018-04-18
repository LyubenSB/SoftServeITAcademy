using LMDB.ApiServices.Contratcts;
using Ninject;
using System.Collections.Generic;

namespace LMDB.ApiServices.Strategies
{
    public class WebApiStrategyContainer : IWebApiStrategyContainer
    {
        private Dictionary<string, ICallProcessorStrategy<string>> strategies;

        public WebApiStrategyContainer()
        {
            this.WebApiStrategies = new Dictionary<string, ICallProcessorStrategy<string>>();
        }

        public void AddStrategy(string strategyKey, ICallProcessorStrategy<string> callProcessorStrategy)
        {
            this.WebApiStrategies.Add(strategyKey, callProcessorStrategy);
        }

        public Dictionary<string, ICallProcessorStrategy<string>> WebApiStrategies { get => strategies; private set => strategies = value; }
    }
}