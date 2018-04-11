using LMDB.Core.Commands;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.Commands.ListByCommand;
using LMDB.Core.Core.Factories;
using LMDB.Core.Core.Factories.Contracts;
using LMDB.Core.Core.Providers;
using LMDB.Core.Core.Providers.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.Core.DataService.InMemoryDataService;
using LMDB.CoreServices.Providers;
using LMDB.CoreServices.Providers.Contracts;
using MovieCatalogApp.Core.Providers;
using Ninject.Modules;

namespace MovieCatalogApp.IoCNinject
{
    /// <summary>
    /// Inversion of control container implemented with Ninject.
    /// Class responsible for dependency binding.
    /// </summary>
    public class MovieCatalogModule : NinjectModule
    {
        public override void Load()
        {
            //service bindings
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IDataService>().To<MovieDataService>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            //command bindings
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommand>().To<ListByCommand>().Named("list movies by");
            this.Bind<ICommand>().To<RegisterMovieCommand>().Named("register movie");
            this.Bind<ICommand>().To<RemoveMovieCommand>().Named("remove movie");
            this.Bind<ICommand>().To<SearchCommand>().Named("search movie");
            this.Bind<ICommand>().To<SortCommand>().Named("sort movies");
            this.Bind<ICommand>().To<HelpCommand>().Named("/help");
            this.Bind<ICommand>().To<ResetDataCommand>().Named("reset");


        }
    }
}
