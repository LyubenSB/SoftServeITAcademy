using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Models;
using LMDB.ObjectModels.OperationalObjects;
using System.Collections.Generic;

namespace LMDB.Core.DataService.InMemoryDataService
{
    /// <summary>
    /// Class responsible for operations with in-memory data collections. 
    /// </summary>
    public class TvSeriesDataService : IDataService<TVSeries>
    {
        public TvSeriesDataService()
        {
            this.InitialTvSeriesList = new SortedSet<TVSeries>();
            this.TvSeriesList = new SortedSet<TVSeries>();
            this.DetailedTvSeriesList = new SortedSet<TVSeries>();
        }

        /// <summary>
        /// Initial collection of data after loading upon start of the application from external data file.
        /// </summary>
        public ICollection<TVSeries> InitialTvSeriesList { get; set; }

        /// <summary>
        /// Collection holding non-detailed data used for operations by the user during application execution.
        /// </summary>
        public ICollection<TVSeries> TvSeriesList { get; set; }


        /// <summary>
        /// Collection holding detailed data used for operations by the user during application execution.
        /// </summary>
        public ICollection<TVSeries> DetailedTvSeriesList { get; private set; }

        /// <summary>
        /// Adding data to in-memory collections.
        /// </summary>
        /// <param name="movieToAdd">movie object</param>
        public void Add(TVSeries seriesToAdd)
        {
            this.InitialTvSeriesList.Add(seriesToAdd);
        }

        /// <summary>
        /// Removing data from in-memory collections.
        /// </summary>
        /// <param name="movieToRemove"></param>
        public void Remove(TVSeries seriesToRemove)
        {
            this.InitialTvSeriesList.Remove(seriesToRemove);
            this.TvSeriesList.Remove(seriesToRemove);
        }

        /// <summary>
        /// Reseting in-memory collection to its initial state
        /// </summary>
        public void ResetData()
        {
            this.TvSeriesList = this.InitialTvSeriesList;
        }
    }
}
