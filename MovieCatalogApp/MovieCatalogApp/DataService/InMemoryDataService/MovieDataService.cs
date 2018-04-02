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
            this.MovieList = new SortedSet<Movie>();
            this.EditedMovieList = new SortedSet<Movie>();
        }

        public ICollection<Movie> MovieList { get; set; }
        public ICollection<Movie> EditedMovieList { get; set; }


        public void Add(Movie movieToAdd)
        {
            this.MovieList.Add(movieToAdd);
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void ResetData()
        {
            this.EditedMovieList = this.MovieList;
        }
    }
}
