﻿using LMDB.ApiServices.Contratcts;
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
            ICallProcessorStrategy<string> getTvSeriesDetailsStrategy = kernel.Get<ICallProcessorStrategy<string>>("GetTVSeriesDetailsStrategy");

            ICallProcessorStrategy<string> listMoviesByGenreStrategy = kernel.Get<ICallProcessorStrategy<string>>("ListMoviesByGenreStrategy");


            strategyContainer.AddStrategy("movie", movieStrategy);
            strategyContainer.AddStrategy("tvseries", tvStrategy);
            strategyContainer.AddStrategy("/movie", getMovieDetailsStrategy);
            strategyContainer.AddStrategy("/tvseries", getTvSeriesDetailsStrategy);
            strategyContainer.AddStrategy("genre", listMoviesByGenreStrategy);

        }
    }
}