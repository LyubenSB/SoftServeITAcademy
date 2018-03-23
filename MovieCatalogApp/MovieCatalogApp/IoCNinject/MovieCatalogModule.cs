﻿using MovieCatalogApp.Commands;
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
    public class MovieCatalogModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>();
            this.Bind<IDataService>().To<MovieDataService>().InSingletonScope();
            this.Bind<IDataController>().To<JsonInputController>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommand>().To<ListByCommand>().Named("List Movies By");

            this.Bind<ICommand>().To<HelpCommand>().Named("/help");

        }
    }
}
