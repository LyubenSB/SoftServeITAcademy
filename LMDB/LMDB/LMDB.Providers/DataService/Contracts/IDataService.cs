using LMDB.ObjectModels.Contracts;
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
    public interface IDataService<T>
    {
        void Add(T movieToAdd);
        void Remove(T movieToRemove);
        void ResetData();
        //TODO: FIGURE OUT THESE TWO DOWN HERE
        ICollection<IMotionPicture> InitialMovieList { get; }
        ICollection<IMotionPicture> MovieList { get;}
        ICollection<IMotionPicture> DetailedMovieList { get; }



    }
}
