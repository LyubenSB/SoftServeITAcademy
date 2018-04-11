using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.DataService.IOFileService.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    /// <summary>
    /// Class representing the implementation of removing movie objects from the memory and external data file.
    /// </summary>
    public class RemoveMovieCommand : ICommand
    {
        private IDataService dataService;
        private readonly JsonOutputController outputController;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommand searchCommand;
        private List<string> collectedData;

        public RemoveMovieCommand(IDataService dataService, JsonOutputController outputController, IReader reader, IWriter writer, SearchCommand searchCommand)
        {
            this.dataService = dataService;
            this.outputController = outputController;
            this.reader = reader;
            this.writer = writer;
            this.searchCommand = searchCommand;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            this.searchCommand.Execute();

            if (this.dataService.MovieList.Count > 1)
            {
                writer.WriteLine("More than one movies with that title found.You must enter the exact title!");
                this.searchCommand.Execute();
                writer.WriteLine("Are you sure you want to remove this movie?");
                writer.WriteLine("(yes/no)");
                collectedData.Add(reader.ReadLine());
            }
            else if (this.dataService.MovieList.Count == 1)
            {
                writer.WriteLine("Are you sure you want to remove this movie?");
                writer.WriteLine("(yes/no)");
                collectedData.Add(reader.ReadLine());
            }

        }

        public string Execute()
        {
            string movieRemoved = @"
======================================================================================================================================
Movie Removed!
======================================================================================================================================";

            CollectData();
            string userChoice = collectedData[0];
            switch (userChoice)
            {
                case "yes":
                    this.outputController.Remove(this.dataService.MovieList.FirstOrDefault());
                    this.dataService.Remove(this.dataService.MovieList.FirstOrDefault());
                    this.writer.WriteLine(movieRemoved);
                    break;

                case "no":
                    break;
                default:
                    writer.WriteLine("Invalid Input. Type 'yes' or 'no'");
                    this.collectedData.Clear();
                    this.Execute();
                    break;
            }


            return @"Enter Command:...
(For help type '/help')";
        }
    }
}
