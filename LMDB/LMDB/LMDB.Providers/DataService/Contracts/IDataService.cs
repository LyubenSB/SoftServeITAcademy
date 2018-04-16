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
        void AddDetailedObject(T movieToAdd);
        void Remove(T movieToRemove);
        void ResetData();
        //TODO: FIGURE OUT THESE TWO DOWN HERE
        ICollection<IMotionPictureData> InitialMovieList { get; }
        ICollection<IMotionPictureData> MovieList { get;}
        ICollection<IMotionPictureData> DetailedMovieList { get; }



    }
}
