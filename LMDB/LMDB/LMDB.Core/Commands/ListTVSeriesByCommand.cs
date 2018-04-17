using LMDB.ApiServices;
using LMDB.ConsoleServices.Contracts;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace LMDB.Core.Commands.ListByCommand
{
    /// <summary>
    /// Class representing the implementation of listing data by a given parameter.
    /// </summary>
    public class ListTVSeriesByCommand : ICommand
    {
        private IDataService<IMotionPictureData> dataService;
        private readonly ProcessorContext processorCtx;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public ListTVSeriesByCommand(IDataService<IMotionPictureData> dataService, ProcessorContext processorCtx, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.processorCtx = processorCtx;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }
        
        public void CollectData()
        {
            writer.WriteLine("======================================================================================================================================");
            writer.WriteLine("List TVSeries by:");
            writer.WriteLine("genre | year ");
            writer.WriteLine("======================================================================================================================================");
            collectedData.Add(reader.ReadLine());
            writer.WriteLine("Enter Parameter :");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string strategyCtx = "tvseries" + collectedData[0];
            //genre person or year parameter
            string listingParameter = collectedData[1];

            this.processorCtx.AddParameter(listingParameter);
            this.processorCtx.ContextExecute(strategyCtx);

            string TVSeriesListed = @"
======================================================================================================================================
TVSeries(s) Listed!
======================================================================================================================================";

            string TVSeriesNotFound = @"
======================================================================================================================================
TVSeries(s) with that parameter are Not Found!
======================================================================================================================================";

            return this.dataService.MovieList.Count == 0 ? TVSeriesNotFound : string.Join("\n", this.dataService.MovieList) + TVSeriesListed;
        }
    }
}
