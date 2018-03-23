using MovieCatalogApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieCatalogApp.Core.Providers.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);
    }
}
