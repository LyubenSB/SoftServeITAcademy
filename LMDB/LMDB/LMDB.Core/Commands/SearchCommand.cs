using LMDB.ApiServices;
using LMDB.ApiServices.Contratcts;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.CoreServices.Providers.Contracts;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LMDB.Core.Commands
{
    /// <summary>
    /// Class representing the implementation of searching movie objects in the in-memory collection by a set of given user input parameters.
    /// </summary>
    public class SearchCommand : ICommand, IDataCollector
    {
        private IDataService<IMotionPicture> dataService;
        private IDataCollector dataCollector;
        private ICallProcessor<string> callProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<string> collectedData;

        public SearchCommand(IDataService<IMotionPicture> dataService, IDataCollector dataCollector,ICallProcessor<string> callProcessor,  IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.dataCollector = dataCollector;
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

        public string Execute()
        {
            CollectData();
            string movieTitle = collectedData[0];
            //string quertString = queryBuilder.BuildSearchQuery(movieTitle);
            //izvika httpclient s toq url
            //posle obache imam json nasran ???

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

            return this.dataService.MovieList.Count == 0 ? movieNotFound : movieFound;
        }
    }
}
