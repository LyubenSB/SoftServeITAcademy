using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.WebServices.Contracts
{
    public interface IClientProvider<T>
    {
        Task<T> HttpGetAsync(string url);
    }
}
