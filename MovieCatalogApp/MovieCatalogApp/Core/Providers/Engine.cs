using Bytes2you.Validation;
using MovieCatalogApp.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Providers
{
    /// <summary>
    /// Class responsible for application initialization and execution.
    /// </summary>
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IParser parser;

        public Engine(IWriter writer, IReader reader, IParser parser)
        {
            this.writer = writer;
            this.reader = reader;
            this.parser = parser;
        }

        /// <summary>
        /// Method responsible for displaying the application's start screen.
        /// </summary>
        public void DisplayStartScreen()
        {
            string startScreen = @"███╗   ███╗ ██████╗ ██╗   ██╗██╗███████╗     ██████╗ █████╗ ████████╗ █████╗ ██╗      ██████╗  ██████╗ 
████╗ ████║██╔═══██╗██║   ██║██║██╔════╝    ██╔════╝██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔═══██╗██╔════╝ 
██╔████╔██║██║   ██║██║   ██║██║█████╗      ██║     ███████║   ██║   ███████║██║     ██║   ██║██║  ███╗
██║╚██╔╝██║██║   ██║╚██╗ ██╔╝██║██╔══╝      ██║     ██╔══██║   ██║   ██╔══██║██║     ██║   ██║██║   ██║
██║ ╚═╝ ██║╚██████╔╝ ╚████╔╝ ██║███████╗    ╚██████╗██║  ██║   ██║   ██║  ██║███████╗╚██████╔╝╚██████╔╝
╚═╝     ╚═╝ ╚═════╝   ╚═══╝  ╚═╝╚══════╝     ╚═════╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝ ╚═════╝  ╚═════╝ 
                                                                                                       ";


            writer.WriteLine(startScreen);
            writer.WriteLine("Enter Command...");
            writer.WriteLine("(For help type '/help')");
        }

        /// <summary>
        /// Method responsible for application initialization. 
        /// </summary>
        public void Start()
        {
            while (true)
            {
                string command = this.reader.ReadLine();

                if (command.ToLower() == TerminationCommand.ToLower())
                {
                    break;
                }
                else if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command))
                {
                    writer.WriteLine("Invalid Command.Type /help for details.");
                    continue;
                }
                else
                {
                    //calling the processCommand method
                    this.ProcessCommand(command);
                }
            }
        }

        /// <summary>
        /// Method responsible for command processing
        /// </summary>
        /// <param name="command">user's command input represented as a string</param>
        private void ProcessCommand(string command)
        {
            //passing the command to the command parser.
            var commandToExectue = this.parser.ParseCommand(command);
            try
            {
                var exectutionResult = commandToExectue.Execute();
                writer.WriteLine(exectutionResult);
            }
            catch (NullReferenceException)
            {
                writer.WriteLine("Invalid Command.Type /help for details.");
                this.Start();
            }
        }
    }
}
