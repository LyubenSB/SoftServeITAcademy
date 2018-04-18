using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface ILocalProcessorStrategy<T, G>
    {
        void ExectuteStrategy(T strParameter, G strCollection);
    }
}
