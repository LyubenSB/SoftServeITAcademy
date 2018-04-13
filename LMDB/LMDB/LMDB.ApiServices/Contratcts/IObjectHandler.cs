using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface IObjectHandler<in T, out IList>
    {
        void HandleObject(T objectToHandle);
        IList GetCollection();
    }
}
