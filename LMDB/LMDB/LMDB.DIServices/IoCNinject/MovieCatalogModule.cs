using LMDB.ApiServices;
using LMDB.ApiServices.ObjectConverters;
using LMDB.Core.Commands;
using LMDB.Core.Commands.Contracts;
//using LMDB.Core.Commands.ListByCommand;
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
            this.Bind<IMotionPicture>().To<Movie>().WhenInjectedInto<ObjectDataService>();
            this.Bind<IMotionPicture>().To<Movie>().WhenInjectedExactlyInto<SearchCommand>();
            this.Bind<IMotionPicture>().To<Movie>().WhenInjectedInto<MovieObjectConverter>();

            //response object bindings
            this.Bind<IResponseObject>().To<MovieResponseObject>().WhenInjectedInto<MovieObjectConverter>();

            //service bindings
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IDataCollector>().ToSelf();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            //strategy bindings
            //search Movie Bindings
            this.Bind<IStrategyContainer>().To<SearchStrategyContainer>().WhenInjectedInto<SearchProcessorContext>();

            this.Bind<IQueryBuilder<string>>().To<SearchMovieQueryBuilder>().WhenInjectedInto<SearchMovieStrategyHandler>();
            this.Bind<IClientCaller<string>>().To<HttpClientCaller>().WhenInjectedInto<SearchMovieStrategyHandler>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().WhenInjectedInto<SearchMovieStrategyHandler>();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>>().To<MovieObjectConverter>().WhenInjectedInto<SearchMovieStrategyHandler>();



            //dataservice bindings
            //DataServicea trq da e singleton
            this.Bind<IDataService<IMotionPicture>>().To<ObjectDataService>().InSingletonScope();
            //this.Bind<IDataService<IMotionPicture>>().To<MovieDataService>().WhenInjectedExactlyInto<MovieObjectConverter>().InSingletonScope();

            //apiservice bindings
            
            this.Bind<IClientCaller<string>>().To<HttpClientCaller>().InSingletonScope();
            this.Bind<IQueryBuilder<string>>().To<SearchMovieQueryBuilder>().WhenInjectedInto<SearchMovieCallStrategy>();
            this.Bind<IObjectHandler<string, IResponseObject>>().To<MovieObjectJSONHandler>().InSingletonScope();
            this.Bind<IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>>().To<MovieObjectConverter>();

            //webservice bindings
            this.Bind<IClientProvider<string>>().To<HttpClientProvider>().InSingletonScope();

            //command bindings
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            //this.Bind<ICommand>().To<ListByCommand>().Named("list movies by");
            //this.Bind<ICommand>().To<RegisterMovieCommand>().Named("register movie");
            //this.Bind<ICommand>().To<RemoveMovieCommand>().Named("remove movie");
            this.Bind<ICommand>().To<SearchCommand>().Named("search for");
            //this.Bind<ICommand>().To<SortCommand>().Named("sort movies");
            //this.Bind<ICommand>().To<HelpCommand>().Named("/help");
            //this.Bind<ICommand>().To<ResetDataCommand>().Named("reset");


        }
    }
}
