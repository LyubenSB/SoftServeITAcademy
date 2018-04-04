using MovieCatalogApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieCatalogApp.Core.Providers.Contracts
{
    /// <summary>
    /// Interface responsible for classes that implement parsing of commands from the user's input.
    /// </summary>
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);
    }
}
