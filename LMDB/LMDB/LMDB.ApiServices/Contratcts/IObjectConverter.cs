using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.ObjectConverters
{
    public interface IObjectConverter<in T, out G>
    {
        void Convert(T objctsToConvert);
        G ConvertedObjects { get;}
    }
}
