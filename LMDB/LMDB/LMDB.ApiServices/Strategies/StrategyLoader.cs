using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.Contracts;
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
            var webApiStrategyContainer = kernel.Get<WebApiStrategyContainer>();
            var localApiStrategyContainer = kernel.Get<LocalApiStrategyContainer>();

            ICallProcessorStrategy<string> searchMovieStrategy = kernel.Get<ICallProcessorStrategy<string>>("SearchMovieStrategy");
            ICallProcessorStrategy<string> searchTvStrategy = kernel.Get<ICallProcessorStrategy<string>>("SearchTVSeriesStrategy");

            ICallProcessorStrategy<string> getMovieDetailsStrategy = kernel.Get<ICallProcessorStrategy<string>>("GetMovieDetailsStrategy");
            ICallProcessorStrategy<string> getTvSeriesDetailsStrategy = kernel.Get<ICallProcessorStrategy<string>>("GetTVSeriesDetailsStrategy");

            ICallProcessorStrategy<string> listMoviesByGenreStrategy = kernel.Get<ICallProcessorStrategy<string>>("ListMoviesByGenreStrategy");
            ICallProcessorStrategy<string> listTVSeriesByGenreStrategy = kernel.Get<ICallProcessorStrategy<string>>("ListTVSeriesByGenreStrategy");
            ICallProcessorStrategy<string> listMoviesByPersonStrategy = kernel.Get<ICallProcessorStrategy<string>>("ListMoviesByPersonStrategy");
            ICallProcessorStrategy<string> listMoviesByYearCallStrategy = kernel.Get<ICallProcessorStrategy<string>>("ListMoviesByYearCallStrategy");
            ICallProcessorStrategy<string> listTVSeriesByYearCallStrategy = kernel.Get<ICallProcessorStrategy<string>>("ListTVSeriesByYearCallStrategy");

            ICallProcessorStrategy<string> sortByYearStrategy = kernel.Get<ICallProcessorStrategy<string>>("SortByYearStrategy");

            ILocalProcessorStrategy<string, ICollection<IMotionPictureData>> printAscendingStrategy = kernel.Get<ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>>("PrintAscendingStrategy");
            ILocalProcessorStrategy<string, ICollection<IMotionPictureData>> printDescendingStrategy = kernel.Get<ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>>("PrintDescendingStrategy");

            webApiStrategyContainer.AddStrategy("movie", searchMovieStrategy);
            webApiStrategyContainer.AddStrategy("tvseries", searchTvStrategy);

            webApiStrategyContainer.AddStrategy("/movie", getMovieDetailsStrategy);
            webApiStrategyContainer.AddStrategy("/tvseries", getTvSeriesDetailsStrategy);

            webApiStrategyContainer.AddStrategy("moviegenre", listMoviesByGenreStrategy);
            webApiStrategyContainer.AddStrategy("tvseriesgenre", listTVSeriesByGenreStrategy);
            webApiStrategyContainer.AddStrategy("movieperson", listMoviesByPersonStrategy);
            webApiStrategyContainer.AddStrategy("movieyear", listMoviesByYearCallStrategy);
            webApiStrategyContainer.AddStrategy("tvseriesyear", listTVSeriesByYearCallStrategy);

            webApiStrategyContainer.AddStrategy("sortbyyear", sortByYearStrategy);


            localApiStrategyContainer.AddStrategy("ascending", printAscendingStrategy);
            localApiStrategyContainer.AddStrategy("descending", printDescendingStrategy);


        }
    }
}
