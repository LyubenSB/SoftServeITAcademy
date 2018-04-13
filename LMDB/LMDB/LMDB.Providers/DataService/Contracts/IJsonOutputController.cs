using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.DataService.Contracts
{
    public interface IJsonOutputController<T>
    {
        void Add(T objectToAdd);
        void Remove(T objectToRemove);
    }
}
