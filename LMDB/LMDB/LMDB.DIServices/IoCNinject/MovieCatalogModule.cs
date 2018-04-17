using LMDB.ApiServices;
using LMDB.ApiServices.ObjectConverters;
using LMDB.Core.Commands;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.Commands.ListByCommand;
using LMDB.Core.Core.Factories;
using LMDB.Core.Core.Factories.Contracts;
using LMDB.Core.Core.Providers;
using LMDB.Core.Core.Providers.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.Core.DataService.InMemoryDataService;
using LMDB.ConsoleServices;
using LMDB.ConsoleServices.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using Ninject.Modules;
using LMDB.ObjectModels.OperationalObjects;
using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectHandlers;
using LMDB.WebServices.Contracts;
using LMDB.WebServices;
using System.Collections.Generic;
using LMDB.ApiServices.Strategies.SearchStrategy;
using LMDB.ApiServices.Strategies;
using LMDB.Commands;

namespace LMDB.DIServices.IoCNinject
{
    /// <summary>
    /// Inversion of control container implemented with Ninject.
    /// Class responsible for dependency binding.
    /// </summary>
    public class MovieCatalogModule : NinjectModule
    {
        public override void Load()
        {
            //utils bindings
            this.Bind<StrategyLoader>().ToSelf().InSingletonScope();

            ////operational object bindings
            //this.Bind<IMotionPictureData>().To<Movie>().WhenInjectedInto<MovieObjectConverter>();

            //response object bindings
            this.Bind<IResponseObject>().To<MovieResponseObject>().WhenInjectedInto<MovieObjectConverter>();

            //service bindings
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IDataCollector>().ToSelf();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            //search strategy bindings
            this.Bind<StrategyContainer>().ToSelf().InSingletonScope();
            
            //person
            this.Bind<IQueryBuilder<string>>().To<SearchPersonQueryBuilder>().WhenInjectedInto<SearchPersonCallStrategy>();
            this.Bind<IObjectHandler<string, PersonResponseObject>>().To<PersonObjectJSONHandler>();

            this.Bind<ICallProcessorStrategy<string>>().To<SearchMovieCallStrategy>().Named("SearchMovieStrategy");
            this.Bind<ICallProcessorStrategy<string>>().To<SearchTVSeriesCallStrategy>().Named("SearchTVSeriesStrategy");

            this.Bind<IQueryBuilder<string>>().To<SearchMovieQueryBuilder>().WhenInjectedExactlyInto<SearchMovieCallStrategy>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>>().To<MovieObjectConverter>().WhenInjectedInto<SearchMovieCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().WhenInjectedInto<SearchMovieCallStrategy>();


            this.Bind<IQueryBuilder<string>>().To<SearchTVSeriesQueryBuilder>().WhenInjectedExactlyInto<SearchTVSeriesCallStrategy>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>>().To<TVSeriesObjectConverter>().WhenInjectedInto<SearchTVSeriesCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<TVObjectJSONHandler>().WhenInjectedInto<SearchTVSeriesCallStrategy>();

            //getDetails strategy bindings
            this.Bind<ICallProcessorStrategy<string>>().To<GetMovieDetailsCallStrategy>().Named("GetMovieDetailsStrategy");
            this.Bind<IQueryBuilder<string>>().To<GetMovieDetailsQueryBuilder>().WhenInjectedInto<GetMovieDetailsCallStrategy>();
            this.Bind<IObjectConverter<DetailedMovieResponseObject, IMotionPictureData>>().To<DetailMovieObjectConverter>().WhenInjectedInto<GetMovieDetailsCallStrategy>();
            this.Bind<IObjectHandler<string, DetailedMovieResponseObject>>().To<DetailedMovieObjectJSONHandler>().WhenInjectedInto<GetMovieDetailsCallStrategy>();

            this.Bind<ICallProcessorStrategy<string>>().To<GetTVSeriesDetailsCallStrategy>().Named("GetTVSeriesDetailsStrategy");
            this.Bind<IQueryBuilder<string>>().To<GetTVSeriesDetailsQueryBuilder>().WhenInjectedInto<GetTVSeriesDetailsCallStrategy>();
            this.Bind<IObjectConverter<DetailedTVseriesResponseObject, IMotionPictureData>>().To<DetailTVSeriesObjectConverter>().WhenInjectedInto<GetTVSeriesDetailsCallStrategy>();
            this.Bind<IObjectHandler<string, DetailedTVseriesResponseObject>>().To<DetailedTvSeriesObjectJSONHandler>().WhenInjectedInto<GetTVSeriesDetailsCallStrategy>();

            //list movies by genre by strategy bindings
            this.Bind<ICallProcessorStrategy<string>>().To<ListMoviesByGenreCallStrategy>().Named("ListMoviesByGenreStrategy");
            this.Bind<IQueryBuilder<string>>().To<ListMoviesByGenreQueryBuilder>().WhenInjectedInto<ListMoviesByGenreCallStrategy>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>>().To<MovieObjectConverter>().WhenInjectedInto<ListMoviesByGenreCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().WhenInjectedInto<ListMoviesByGenreCallStrategy>();

            //list TVSeries by genre by strategy bindings
            this.Bind<ICallProcessorStrategy<string>>().To<ListTVSeriesByGenreCallStrategy>().Named("ListTVSeriesByGenreStrategy");
            this.Bind<IQueryBuilder<string>>().To<ListTVSeriesByGenreQueryBuilder>().WhenInjectedInto<ListTVSeriesByGenreCallStrategy>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>>().To<TVSeriesObjectConverter>().WhenInjectedInto<ListTVSeriesByGenreCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<TVObjectJSONHandler>().WhenInjectedInto<ListTVSeriesByGenreCallStrategy>();

            //list movies by person by strategy bindings
            this.Bind<ICallProcessorStrategy<string>>().To<ListMoviesByPersonCallStrategy>().Named("ListMoviesByPersonStrategy");
            this.Bind<IQueryBuilder<string>>().To<ListMoviesByPersonQueryBuilder>().WhenInjectedInto<ListMoviesByPersonCallStrategy>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>>().To<MovieObjectConverter>().WhenInjectedInto<ListMoviesByPersonCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().WhenInjectedInto<ListMoviesByPersonCallStrategy>();

            //list tvSeries by person by strategy bindings
            this.Bind<ICallProcessorStrategy<string>>().To<ListTVSeriesByPersonCallStrategy>().Named("ListTvSeriesByPersonStrategy");
            this.Bind<IQueryBuilder<string>>().To<ListTVSeriesByPersonQueryBuilder>().WhenInjectedInto<ListTVSeriesByPersonCallStrategy>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>>().To<TVSeriesObjectConverter>().WhenInjectedInto<ListTVSeriesByPersonCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<TVObjectJSONHandler>().WhenInjectedInto<ListTVSeriesByPersonCallStrategy>();


            //dataservice bindings
            this.Bind<IDataService<IMotionPictureData>>().To<ObjectDataService>().InSingletonScope();
            this.Bind<GenreQueryBuilder>().ToSelf();
            this.Bind<InitialDataGetter>().ToSelf().InSingletonScope();
            this.Bind<GenreCollectionHandler>().ToSelf().InSingletonScope();

            //apiservice bindings
            this.Bind<IClientCaller<string>>().To<HttpClientCaller>().InSingletonScope();
            //this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>>().To<MovieObjectConverter>();
            //this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>>().To<TVSeriesObjectConverter>();

            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().WhenInjectedInto<MovieObjectConverter>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<TVObjectJSONHandler>().WhenInjectedInto<TVSeriesObjectConverter>();
            this.Bind<IObjectHandler<string, DetailedMovieResponseObject>>().To<DetailedMovieObjectJSONHandler>().WhenInjectedInto<DetailMovieObjectConverter>();
            this.Bind<IObjectHandler<string, DetailedTVseriesResponseObject>>().To<DetailedTvSeriesObjectJSONHandler>().WhenInjectedInto<DetailTVSeriesObjectConverter>();


            //webservice bindings
            this.Bind<IClientProvider<string>>().To<HttpClientProvider>().InSingletonScope();

            //command bindings
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommand>().To<ListMoviesByCommand>().Named("list movies by");
            this.Bind<ICommand>().To<ListTVSeriesByCommand>().Named("list tvseries by");
            this.Bind<ICommand>().To<GetDetailsCommand>().Named("get details on");
            //this.Bind<ICommand>().To<RegisterMovieCommand>().Named("register movie");
            //this.Bind<ICommand>().To<RemoveMovieCommand>().Named("remove movie");
            this.Bind<ICommand>().To<SearchCommand>().Named("search for");
            //this.Bind<ICommand>().To<SortCommand>().Named("sort movies");
            //this.Bind<ICommand>().To<HelpCommand>().Named("/help");
            this.Bind<ICommand>().To<ResetDataCommand>().Named("reset");


        }
    }
}
