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

            if (this.dataService.EditedMovieList.Count > 1)
            {
                writer.WriteLine("More than one movies with that title found.You must enter the exact title!");
                this.searchCommand.Execute();
                writer.WriteLine("Are you sure you want to remove this movie?");
                writer.WriteLine("(yes/no)");
                collectedData.Add(reader.ReadLine());
            }
            else if (this.dataService.EditedMovieList.Count == 1)
            {
                writer.WriteLine("Are you sure you want to remove this movie?");
                writer.WriteLine("(yes/no)");
                collectedData.Add(reader.ReadLine());
            }
            
        }

        public string Execute()
        {
            CollectData();
            this.outputController.RemoveMovieFromFile(this.dataService.EditedMovieList.FirstOrDefault());

            return @"

======================================================================================================================================
Movie Removed!
======================================================================================================================================";
        }
    }
}
