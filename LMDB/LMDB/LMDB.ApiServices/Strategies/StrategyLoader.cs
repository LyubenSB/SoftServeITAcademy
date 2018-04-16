using LMDB.ApiServices.Contratcts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies
{
    public class StrategyLoader
    {
        public StrategyLoader(IKernel kernel)
        {
            this.kernel = kernel;
        }
        private readonly IKernel kernel;

        public void LoadStrategies()
        {
            var strategyContainer = kernel.Get<StrategyContainer>();
            ICallProcessorStrategy<string> movieStrategy = kernel.Get<ICallProcessorStrategy<string>>("SearchMovieStrategy");
            ICallProcessorStrategy<string> tvStrategy = kernel.Get<ICallProcessorStrategy<string>>("SearchTVSeriesStrategy");
            ICallProcessorStrategy<string> getMovieDetailsStrategy = kernel.Get<ICallProcessorStrategy<string>>("GetMovieDetailsStrategy");

            strategyContainer.AddStrategy("movie", movieStrategy);
            strategyContainer.AddStrategy("tvseries", tvStrategy);
            strategyContainer.AddStrategy("details/movie", getMovieDetailsStrategy);
            //strategyContainer.AddStrategy("details/tvseries", tvStrategy);
        }
    }
}
