using LMDB.ApiServices;
using LMDB.ConsoleServices.Contracts;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.Commands
{
    /// <summary>
    /// Class representing the implementation of getting details on movie/tvseries objects from third site api.
    /// </summary>
    public class GetDetailsCommand : ICommand, IDataCollector
    {
        private IDataService<IMotionPictureData> dataService;
        private ProcessorContext processorCtx;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<string> collectedData;

        public GetDetailsCommand(IDataService<IMotionPictureData> dataService, ProcessorContext processorCtx, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.processorCtx = processorCtx;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("To check details for movies or tv series:");
            writer.WriteLine("Enter 'details/movie' or 'details/tvseries'");
            collectedData.Add(reader.ReadLine());
            writer.WriteLine("Enter ID: ");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string strategyParameter = collectedData[0];
            string motionPictureID = collectedData[1];
            this.processorCtx.AddParameter(motionPictureID);
            this.processorCtx.ContextExecute(strategyParameter);

            var moviesFound = this.dataService.DetailedMovieList;
            writer.WriteLine(string.Join("\n", moviesFound));

            string movieFound = @"

======================================================================================================================================
Details Found!
======================================================================================================================================";

            string movieNotFound = @"

======================================================================================================================================
Wrong ID! Try again!
======================================================================================================================================";

            return this.dataService.MovieList.Count == 0 ? movieNotFound : movieFound;
        }


    }
}
