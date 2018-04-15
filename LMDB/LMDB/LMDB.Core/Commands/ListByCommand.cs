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
    public class ListByCommand : ICommand
    {
        private IDataService<IMotionPicture> dataService;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public ListByCommand(IDataService<IMotionPicture> dataService, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
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
