using LMDB.CoreServices.Providers.Contracts;
using System;

namespace LMDB.CoreServices.Providers
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
