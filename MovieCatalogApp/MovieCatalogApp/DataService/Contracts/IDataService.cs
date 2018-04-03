using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.DataService.Contracts
{
    public interface IDataService
    {
        void Add(Movie movieToAdd);
        void Remove(Movie movieToRemove);
        void ResetData();
        ICollection<Movie> InitialMovieList { get; set; }
        ICollection<Movie> MovieList { get; set; }


    }
}
