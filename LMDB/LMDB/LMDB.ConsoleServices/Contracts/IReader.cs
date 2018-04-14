using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ConsoleServices.Contracts
{
    /// <summary>
    /// Interface responsible for classes that implement reading of commands from the user's input.
    /// </summary>
    public interface IReader
    {
        string ReadLine();
    }
}
