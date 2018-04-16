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
    public class SearchCommand : ICommand, IDataCollector
    {
        private IDataService<IMotionPictureData> dataService;
        private ProcessorContext processorCtx;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<string> collectedData;

        public SearchCommand(IDataService<IMotionPictureData> dataService, ProcessorContext processorCtx, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.processorCtx = processorCtx;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("('movie' or 'tvseries')");
            collectedData.Add(reader.ReadLine());
            writer.WriteLine("Enter Title: ");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string typeOfPicture = collectedData[0];
            string title = collectedData[1];
            this.processorCtx.AddParameter(title);
            this.processorCtx.ContextExecute(typeOfPicture);

            var moviesFound = this.dataService.MovieList;
            writer.WriteLine(string.Join("\n", moviesFound));

            string movieFound = @"

======================================================================================================================================
Movie(s)/TV Series Found!
======================================================================================================================================";

            string movieNotFound = @"

======================================================================================================================================
Movie(s)/TV Series Not Found!
======================================================================================================================================";

            return this.dataService.MovieList.Count == 0 ? movieNotFound : movieFound;
        }


    }
}
