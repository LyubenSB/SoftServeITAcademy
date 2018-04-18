using LMDB.Core.Commands.Contracts;
using System;
using System.Text;

namespace LMDB.Core.Commands
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
            commands.AppendLine("'search for' - Searches movies or tv series by title");
            commands.AppendLine("'get details on' - gets the details on a specific movie or tv series");
            commands.AppendLine("'list movies by' - lists movies by given parameter");
            commands.AppendLine("'list tvseries by' - lists tv series by given parameter");
            commands.AppendLine("'sort by' - Sorts movies or tv series by a parameter");
            commands.AppendLine("'reset' - resets the program");
            commands.AppendLine("'exit' - exits the program");

            return commands.ToString();
        }
    }
}
