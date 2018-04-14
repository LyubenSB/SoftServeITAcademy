using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.Core.Commands.Contracts
{
    /// <summary>
    /// Interface for classes that execute commands.
    /// </summary>
    public interface ICommand
    {
        //TODO : SEPARATE COLLECTIND FROM EXECUTING
        /// <summary>
        /// Void method responsible for collecting data from the user's input.
        /// </summary>

        /// <summary>
        /// Method responsible for execution of the specific class' command implementation.
        /// </summary>
        /// <returns></returns>
        string Execute();
        void CallProcess();
    }
}
