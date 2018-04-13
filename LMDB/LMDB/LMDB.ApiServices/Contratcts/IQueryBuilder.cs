using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public interface IQueryBuilder
    {
        string BuildSearchQuery(string searchParameter);
    }
}
