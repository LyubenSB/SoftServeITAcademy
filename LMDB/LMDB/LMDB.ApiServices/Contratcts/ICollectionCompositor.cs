using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface ICollectionCompositor<T>
    {
        void Composite(T collectionToCompose);
    }
}
