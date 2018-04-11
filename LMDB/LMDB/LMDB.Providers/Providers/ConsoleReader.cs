using MovieCatalogApp.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Providers
{
    /// <summary>
    /// Class responsible for reading commands represented as a string from the user's input.
    /// </summary>
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
