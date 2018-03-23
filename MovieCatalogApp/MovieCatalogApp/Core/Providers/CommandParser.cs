using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Factories.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieCatalogApp.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            this.factory = factory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand;

            return this.factory.CreateCommand(commandName);
        }
    }
}
