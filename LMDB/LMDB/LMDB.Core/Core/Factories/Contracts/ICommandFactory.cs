using LMDB.Core.Commands.Contracts;

namespace LMDB.Core.Core.Factories.Contracts
{
    /// <summary>
    /// Interface for classes that are responsible for creating commands.
    /// </summary>
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
