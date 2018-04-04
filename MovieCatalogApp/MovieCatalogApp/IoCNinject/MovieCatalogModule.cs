using MovieCatalogApp.Commands;
using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Commands.ListByCommand;
using MovieCatalogApp.Core.Factories;
using MovieCatalogApp.Core.Factories.Contracts;
using MovieCatalogApp.Core.Providers;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.DataService.InMemoryDataService;
using MovieCatalogApp.DataService.IOFileService;
using MovieCatalogApp.DataService.IOFileService.Input;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
