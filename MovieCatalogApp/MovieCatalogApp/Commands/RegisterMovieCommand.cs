using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.DataService.IOFileService.Output;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    public class RegisterMovieCommand : ICommand
    {
        private IDataService dataService;
        private JsonOutputController outputController;
        private IReader reader;
        private IWriter writer;
        private List<string> collectedData;

        public RegisterMovieCommand(IDataService dataService, JsonOutputController outputController, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.outputController = outputController;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("Enter Movie Title: ");
            collectedData.Add(reader.ReadLine());

            writer.WriteLine("Enter Genres: ");
            collectedData.Add(reader.ReadLine());

            writer.WriteLine("Enter Description: ");
            collectedData.Add(reader.ReadLine());

            writer.WriteLine("Enter Director: ");
            collectedData.Add(reader.ReadLine());

            writer.WriteLine("Enter Actors: ");
            collectedData.Add(reader.ReadLine());

            writer.WriteLine("Enter Year: ");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();

            string movieTitle = collectedData[0];
            ICollection<string> movieGenres = collectedData[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string movieDescription = collectedData[2];
            string movieDirector = collectedData[3];
            ICollection<string> movieActors = collectedData[4].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int movieYear = int.Parse(collectedData[5]);


            Movie newMovie = new Movie()
            {
                Title = movieTitle,
                Genre = movieGenres,
                Description = movieDescription,
                Director = movieDirector,
                Actors = movieActors,
                Year = movieYear,
                IsNew = true
            };

            dataService.Add(newMovie);
            outputController.SaveMovieToFile(newMovie);
            return (@"=================
New Movie Is Registered!
=================");

        }
    }
}
