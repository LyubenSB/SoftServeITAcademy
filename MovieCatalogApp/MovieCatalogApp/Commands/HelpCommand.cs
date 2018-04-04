using MovieCatalogApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    /// <summary>
    /// Class responsible for displaying available application commands.
    /// </summary>
    public class HelpCommand : ICommand
    {
        private StringBuilder commands = new StringBuilder();

        public void CollectData()
        {
            throw new NotImplementedException();
        }

        public string Execute()
        {
            commands.AppendLine("'list movies by' - lists movies by given parameter");
            commands.AppendLine("'search movie' - Searches movies by title");
            commands.AppendLine("'sort movies' - Sorts movies by a parameter");
            commands.AppendLine("'register movie' - creates a movie");
            commands.AppendLine("'remove movie' - removes a specific movie from the list");
            commands.AppendLine("'reset' - resets the program");
            commands.AppendLine("'exit' - exit the program");

            return commands.ToString();
        }
    }
}
