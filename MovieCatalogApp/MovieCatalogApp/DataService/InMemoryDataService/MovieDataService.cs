using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.DataService.IOFileService;
using MovieCatalogApp.DataService.IOFileService.Input;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.DataService.InMemoryDataService
{
    /// <summary>
    /// Class responsible for operations with in-memory data collections. 
    /// </summary>
    public class MovieDataService : IDataService
    {
        public MovieDataService()
        {
            this.InitialMovieList = new SortedSet<Movie>();
            this.MovieList = new SortedSet<Movie>();
        }

        /// <summary>
        /// Initial collection of data after loading upon start of the application from external data file.
        /// </summary>
        public ICollection<Movie> InitialMovieList { get; set; }

        /// <summary>
        /// Collection holding data used for operations by the user during application execution.
        /// </summary>
        public ICollection<Movie> MovieList { get; set; }

        /// <summary>
        /// Adding data to in-memory collections.
        /// </summary>
        /// <param name="movieToAdd">movie object</param>
        public void Add(Movie movieToAdd)
        {
            this.InitialMovieList.Add(movieToAdd);
            this.MovieList.Add(movieToAdd);
        }

        /// <summary>
        /// Removing data from in-memory collections.
        /// </summary>
        /// <param name="movieToRemove"></param>
        public void Remove(Movie movieToRemove)
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
