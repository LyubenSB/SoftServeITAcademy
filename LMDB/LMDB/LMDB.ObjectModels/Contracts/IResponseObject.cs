using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.Contracts
{
    public interface IResponseObject
    {
        int Id { get; set; }

        string Title { get; set; }

        string Overview { get; set; }

        DateTime? ReleaseDate { get; set; }
    }
}
