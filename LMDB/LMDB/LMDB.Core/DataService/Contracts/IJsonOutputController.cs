using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.DataService.Contracts
{
    public interface IJsonOutputController
    {
        void Add<T>(T objectToAdd);
        void Remove<T>(T objectToRemove);
    }
}
