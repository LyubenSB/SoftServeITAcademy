using LMDB.ApiServices;
using LMDB.ApiServices.Contratcts;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.ConsoleServices.Contracts;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LMDB.Core.Commands
{
    /// <summary>
    /// Class representing the implementation of searching movie objects in the in-memory collection by a set of given user input parameters.
    /// </summary>
    public class SearchMovieCommand : ICommand, IDataCollector
    {
        private IDataService<IMotionPicture> dataService;
        private ICallProcessor callProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<string> collectedData;

        public SearchMovieCommand(IDataService<IMotionPicture> dataService, ICallProcessor callProcessor, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.callProcessor = callProcessor;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("Enter Movie Title: ");
            collectedData.Add(reader.ReadLine());
        }

        public void CallProcess()
        {
            string movieTitle = collectedData[0];
             this.callProcessor.ProcessSearchCall(movieTitle);
        }

        public string Execute()
        {
            CollectData();
            CallProcess();
            var moviesFound = this.dataService.MovieList;

            writer.WriteLine(string.Join("\n", moviesFound));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //searching for a movie with specific title.

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

            return "success";
        }


    }
}
