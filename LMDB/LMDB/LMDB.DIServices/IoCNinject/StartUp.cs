using LMDB.ApiServices;
using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.Strategies;
using LMDB.Core.Core.Providers;
using LMDB.DIServices.IoCNinject;
using LMDB.WebServices;
using Newtonsoft.Json.Linq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //initializes a kernal instance/
            IKernel kernel = new StandardKernel(new MovieCatalogModule());

            //adding strategies
            var strategyContainer = kernel.Get<StrategyContainer>();

            ICallProcessorStrategy<string> movieStrategy = kernel.Get<ICallProcessorStrategy<string>>("SearchMovieStrategy");
            ICallProcessorStrategy<string> tvStrategy = kernel.Get<ICallProcessorStrategy<string>>("SearchTVSeriesStrategy");
            ICallProcessorStrategy<string> getMovieDetailsStrategy = kernel.Get<ICallProcessorStrategy<string>>("GetMovieDetailsStrategy");

            strategyContainer.AddStrategy("movie", movieStrategy);
            strategyContainer.AddStrategy("tvseries", tvStrategy);
            strategyContainer.AddStrategy("details/movie", getMovieDetailsStrategy);
            //strategyContainer.AddStrategy("details/tvseries", tvStrategy);

            //inital data collection
            var dataGetter = kernel.Get<InitialDataGetter>();
            dataGetter.GetData();

            //Starting the application
            var engine = kernel.Get<Engine>();
            engine.DisplayStartScreen();
            engine.Start();
        }
    }
}
