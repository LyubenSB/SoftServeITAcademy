using LMDB.Core.Commands.Contracts;
using LMDB.Core.Core.Factories.Contracts;
using LMDB.Core.Core.Providers.Contracts;

namespace LMDB.Core.Core.Providers
{
    /// <summary>
    /// Class responsible for parsing commands represented as a string from the user's input.
    /// </summary>
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
