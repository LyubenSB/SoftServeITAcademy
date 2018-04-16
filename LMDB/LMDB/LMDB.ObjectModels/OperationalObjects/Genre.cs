using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.OperationalObjects
{
    public class Genre
    {
        public int Id { get; set; }
        public string  Genres { get; set; }

        public override string ToString()
        {
            return Genres.ToString();
        }
    }
}
