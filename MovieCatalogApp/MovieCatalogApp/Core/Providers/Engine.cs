using MovieCatalogApp.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Providers
{
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

        private void displayStartScreen()
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

        public void Start()
        {
            displayStartScreen();

            while (true)
            {
                string command = this.reader.ReadLine();

                if (command.ToLower() == TerminationCommand.ToLower())
                {
                    break;
                }
                else
                {
                    this.ProcessCommand(command);
                }
            }
        }

        private void ProcessCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException("Command cannot be null or empty");
            }

            var commandToExectue = this.parser.ParseCommand(command);
            var exectutionResult = commandToExectue.Execute();
            writer.WriteLine(exectutionResult);
        }
    }
}
