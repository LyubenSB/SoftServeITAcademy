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
    public class MovieDataService : IDataService
    {
        public MovieDataService()
        {
            this.InitialMovieList = new SortedSet<Movie>();
            this.MovieList = new SortedSet<Movie>();
        }

        public ICollection<Movie> InitialMovieList { get; set; }
        public ICollection<Movie> MovieList { get; set; }


        public void Add(Movie movieToAdd)
        {
            this.InitialMovieList.Add(movieToAdd);
        }

        public void Remove(Movie movieToRemove)
        {
            this.InitialMovieList.Remove(movieToRemove);
            this.MovieList.Remove(movieToRemove);
        }

        public void ResetData()
        {
            this.MovieList = this.InitialMovieList;
        }
    }
}
