using LMDB.ObjectModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.Core.DataService.Contracts
{
    /// <summary>
    /// Interface for classes responsible for operations with data collections. 
    /// </summary>
    public interface IDataService
    {
        void Add(Movie movieToAdd);
        void Remove(Movie movieToRemove);
        void ResetData();
        ICollection<Movie> InitialMovieList { get; set; }
        ICollection<Movie> MovieList { get; set; }


    }
}
