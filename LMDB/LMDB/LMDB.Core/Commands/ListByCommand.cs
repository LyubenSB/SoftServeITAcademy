using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieCatalogApp.Commands.ListByCommand
{
    /// <summary>
    /// Class representing the implementation of listing data by a given parameter.
    /// </summary>
    public class ListByCommand : ICommand
    {
        private IDataService dataService;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;
        private readonly List<Movie> validCollection;

        public ListByCommand(IDataService dataService, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
            this.validCollection = new List<Movie>();
        }
        
        public void CollectData()
        {
            writer.WriteLine("======================================================================================================================================");
            writer.WriteLine("List Movies by:");
            writer.WriteLine("genre | actor | director | year | all movies");
            writer.WriteLine("======================================================================================================================================");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string listedObjectsBy = collectedData.Last();

            switch (listedObjectsBy)
            {
                case "all movies":
                    writer.WriteLine(string.Join("\n", this.dataService.InitialMovieList));
                    break;

                case "genre":
                    writer.WriteLine("Enter Genre:");
                    string genre = reader.ReadLine();
                    this.dataService.MovieList = dataService.MovieList.Where(x => x.Genre.Contains(genre)).ToList();
                    writer.WriteLine(string.Join("\n", this.dataService.MovieList));
                    break;

                case "actor":
                    writer.WriteLine("Enter Actor:");
                    string actor = reader.ReadLine();
                    this.dataService.MovieList = dataService.MovieList.Where(x => x.Actors.Contains(actor)).ToList();
                    writer.WriteLine(string.Join("\n", this.dataService.MovieList));
                    break;

                case "director":
                    writer.WriteLine("Enter Director:");
                    string director = reader.ReadLine();
                    this.dataService.MovieList = dataService.MovieList.Where(x => x.Director.Contains(director)).ToList();
                    writer.WriteLine(string.Join("\n", this.dataService.MovieList));
                    break;

                case "year":
                    writer.WriteLine("Enter Year:");
                    int year = int.Parse(reader.ReadLine());
                    this.dataService.MovieList = dataService.MovieList.Where(x => x.Year == year).ToList();
                    writer.WriteLine(string.Join("\n", this.dataService.MovieList));
                    break;

                default:
                    writer.WriteLine("");
                    writer.WriteLine("Invalid Input! Type either one of these parameters to list movies!");
                    writer.WriteLine("");
                    this.Execute();
                    break;
            }
            string moviesListed = @"
======================================================================================================================================
Movie(s) Listed!
======================================================================================================================================";

            string movieNotFound = @"
======================================================================================================================================
Movie(s) with that parameter are Not Found!
======================================================================================================================================";
            return this.dataService.MovieList.Count == 0 ? movieNotFound : moviesListed;
        }
    }
}
