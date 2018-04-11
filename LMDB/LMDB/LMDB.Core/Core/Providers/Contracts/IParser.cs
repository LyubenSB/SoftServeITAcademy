using LMDB.Core.Commands.Contracts;


namespace LMDB.Core.Core.Providers.Contracts
{
    /// <summary>
    /// Interface responsible for classes that implement parsing of commands from the user's input.
    /// </summary>
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);
    }
}
