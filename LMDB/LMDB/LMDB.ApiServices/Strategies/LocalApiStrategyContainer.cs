using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.Contracts;
using Ninject;
using System.Collections.Generic;

namespace LMDB.ApiServices.Strategies
{
    public class LocalApiStrategyContainer : ILocalApiStrategyContainer
    {
        private Dictionary<string, ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>> strategies;

        public LocalApiStrategyContainer()
        {
            this.LocalApiStrategies = new Dictionary<string, ILocalProcessorStrategy<string,ICollection<IMotionPictureData>>>();
        }

        public void AddStrategy(string strategyKey, ILocalProcessorStrategy<string, ICollection<IMotionPictureData>> callProcessorStrategy)
        {
            this.LocalApiStrategies.Add(strategyKey, callProcessorStrategy);
        }

        public Dictionary<string, ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>> LocalApiStrategies { get => strategies; private set => strategies = value; }
    }
}