using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface IObjectHandler<T,G>
    {
        void HandleObject(T objectToHandle);
        IList<G> HandledResponseObjects { get;}
    }
}
