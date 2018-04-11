using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    /// <summary>
    /// Class representing the implementation of searching movie objects in the in-memory collection by a set of given user input parameters.
    /// </summary>
    public class SearchCommand : ICommand
    {
        private IDataService dataService;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<string> collectedData;

        public SearchCommand(IDataService dataService, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("Enter Movie Title: ");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string movieTitle = collectedData[0];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //searching for a movie with specific title.
            this.dataService.MovieList = this.dataService.MovieList
                .Where(x => x.Title.IndexOf(movieTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            writer.WriteLine(string.Join("\n", this.dataService.MovieList));

            string movieFound = @"

======================================================================================================================================
Movie(s) Found!
======================================================================================================================================";

            string movieNotFound = @"

======================================================================================================================================
Movie Not Found!
======================================================================================================================================";

            stopwatch.Stop();
            Console.WriteLine(@"
Searching done! Time Elapsed : {0} milisecond(s)", stopwatch.ElapsedMilliseconds.ToString());

            return this.dataService.MovieList.Count == 0 ? movieNotFound : movieFound;
        }
    }
}
