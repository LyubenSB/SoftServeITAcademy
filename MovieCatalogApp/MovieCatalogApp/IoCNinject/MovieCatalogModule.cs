using MovieCatalogApp.Core.Providers;
using MovieCatalogApp.Core.Providers.Contracts;
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
        }
    }
}
