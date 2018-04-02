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
        void Remove();
        void ResetData();
        ICollection<Movie> MovieList { get; set; }
        ICollection<Movie> EditedMovieList { get; set; }


    }
}
