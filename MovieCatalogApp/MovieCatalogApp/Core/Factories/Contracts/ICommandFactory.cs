using MovieCatalogApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Factories.Contracts
{
    /// <summary>
    /// Interface for classes that are responsible for creating commands.
    /// </summary>
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
