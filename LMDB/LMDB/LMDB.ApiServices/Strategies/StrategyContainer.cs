using LMDB.ApiServices.Contratcts;
using Ninject;
using System.Collections.Generic;

namespace LMDB.ApiServices.Strategies
{
    public class StrategyContainer : IStrategyContainer
    {
        private Dictionary<string, ICallProcessorStrategy<string>> strategies;

        public StrategyContainer()
        {
            this.Strategies = new Dictionary<string, ICallProcessorStrategy<string>>();
        }

        public void AddStrategy(string strategyKey, ICallProcessorStrategy<string> callProcessorStrategy)
        {
            this.Strategies.Add(strategyKey, callProcessorStrategy);
        }

        public Dictionary<string, ICallProcessorStrategy<string>> Strategies { get => strategies; private set => strategies = value; }
    }
}