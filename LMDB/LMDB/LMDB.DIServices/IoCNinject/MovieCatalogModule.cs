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
            //operational object bindings
            this.Bind<IMotionPictureData>().To<Movie>().WhenInjectedInto<MovieObjectConverter>();

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
            this.Bind<IQueryBuilder<string>>().To<GetDetailsQueryBuilder>().WhenInjectedInto<GetMovieDetailsCallStrategy>();
            this.Bind<IObjectConverter<DetailedMovieResponseObject, IMotionPictureData>>().To<DetailMovieObjectConverter>().WhenInjectedInto<GetMovieDetailsCallStrategy>();
            this.Bind<IObjectHandler<string, DetailedMovieResponseObject>>().To<DetailedMovieObjectJSONHandler>().WhenInjectedInto<GetMovieDetailsCallStrategy>();

            //dataservice bindings
            this.Bind<IDataService<IMotionPictureData>>().To<ObjectDataService>().InSingletonScope();
            this.Bind<GenreQueryBuilder>().ToSelf();
            this.Bind<InitialDataGetter>().ToSelf();
            this.Bind<GenreCollectionHandler>().ToSelf().InSingletonScope();

            //apiservice bindings
            this.Bind<IClientCaller<string>>().To<HttpClientCaller>().InSingletonScope();
            //this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>>().To<MovieObjectConverter>();
            //this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>>().To<TVSeriesObjectConverter>();

            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().WhenInjectedInto<MovieObjectConverter>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<TVObjectJSONHandler>().WhenInjectedInto<TVSeriesObjectConverter>();
            this.Bind<IObjectHandler<string, DetailedMovieResponseObject>>().To<DetailedMovieObjectJSONHandler>().WhenInjectedInto<DetailMovieObjectConverter>();

            //webservice bindings
            this.Bind<IClientProvider<string>>().To<HttpClientProvider>().InSingletonScope();

            //command bindings
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommand>().To<ListByCommand>().Named("list movies by");
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
