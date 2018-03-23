using MovieCatalogApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    public class HelpCommand : ICommand
    {
        private StringBuilder commands = new StringBuilder();

        public void CollectData()
        {
            throw new NotImplementedException();
        }

        public string Execute()
        {
            commands.AppendLine("'Create Movie' - creates a movie");
            commands.AppendLine("'Remove Movie' - removes a specific movie from the list");
            commands.AppendLine("'List Movies By' - lists movies by given parameter");
            commands.AppendLine("'Search Movie' - Searches movies by title");
            commands.AppendLine("'Sort Movies' - Sorts movies by a parameter");
            commands.AppendLine("'Exit' - exit the program");

            return commands.ToString();
        }
    }
}
