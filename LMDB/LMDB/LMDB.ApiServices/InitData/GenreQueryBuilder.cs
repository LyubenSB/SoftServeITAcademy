using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class GenreQueryBuilder 
    {
        public string BuildQuery()
        {
            string queryComposite = $"https://api.themoviedb.org/3/genre/movie/list?api_key=81e01557d5026a137a95543112911069";

            return queryComposite;
        }
    }
}
