using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Factories.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;
        private readonly IWriter writer;

        public CommandFactory(IKernel kernel, IWriter writer)
        {
            this.kernel = kernel;
            this.writer = writer;
        }

        public ICommand CreateCommand(string commandName)
        {
            try
            {
                return this.kernel.Get<ICommand>(commandName);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
