using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.CoreServices.Providers.Contracts
{
    /// <summary>
    /// Interface responsible for classes that implement writing of the program's execution results.
    /// </summary>
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
