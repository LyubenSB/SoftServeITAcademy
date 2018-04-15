using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.Models;
using System.Collections.Generic;

namespace LMDB.Core.DataService.InMemoryDataService
{
    /// <summary>
    /// Class responsible for operations with in-memory data collections. 
    /// </summary>
    public class ObjectDataService : IDataService<IMotionPictureData>
    {
        public ObjectDataService()
        {
            this.InitialMovieList = new List<IMotionPictureData>();
            this.MovieList = new List<IMotionPictureData>();
            this.DetailedMovieList = new List<IMotionPictureData>();
        }

        /// <summary>
        /// Initial collection of data after loading upon start of the application from external data file.
        /// </summary>
        public ICollection<IMotionPictureData> InitialMovieList { get; private set; }

        public List<IMotionPictureData> GenreList { get; private set; }

        /// <summary>
        /// Collection holding non-detailed data used for operations by the user during application execution.
        /// </summary>
        public ICollection<IMotionPictureData> MovieList { get; private set; }


        /// <summary>
        /// Collection holding detailed data used for operations by the user during application execution.
        /// </summary>
        public ICollection<IMotionPictureData> DetailedMovieList { get; private set; }

        /// <summary>
        /// Adding data to in-memory collections.
        /// </summary>
        /// <param name="movieToAdd">movie object</param>
        public void Add(IMotionPictureData movieToAdd)
        {
            this.MovieList.Add(movieToAdd);
        }
        /// <summary>
        /// Adding data to in-memory collections.
        /// </summary>
        /// <param name="movieToAdd">movie object</param>
        
        /// <summary>
        /// Removing data from in-memory collections.
        /// </summary>
        /// <param name="movieToRemove"></param>
        public void Remove(IMotionPictureData movieToRemove)
        {
            this.InitialMovieList.Remove(movieToRemove);
            this.MovieList.Remove(movieToRemove);
        }

        /// <summary>
        /// Reseting in-memory collection to its initial state
        /// </summary>
        public void ResetData()
        {
            this.MovieList = this.InitialMovieList;
        }
    }
}
