using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Factories.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Factories
{
    /// <summary>
    /// Class responsible for creating commands.
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;
        private readonly IWriter writer;

        public CommandFactory(IKernel kernel, IWriter writer)
        {
            this.kernel = kernel;
            this.writer = writer;
        }

        /// <summary>
        /// Method responsible for creating command via Ninject's kernel Get<T> method.
        /// </summary>
        /// <param name="commandName">command name represented as a string</param>
        /// <returns>Returns ICommand implementing class</returns>
        public ICommand CreateCommand(string commandName)
        {
            try
            {
                //Gets an instance of the specified service by using the first binding in the IOC container with the specified name
                return this.kernel.Get<ICommand>(commandName);
            }
            //catches the ninject "command not binded"
            catch (Ninject.ActivationException)
            {

                return null;
            }
        }
    }
}
