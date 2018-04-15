using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class ListByGenreQueryBuidler : TMDBQueryBuilder
    {
        public override string BuildQuery(string queryParams)
        {
            string queryComposite = $"{Url}/search/movie?api_key={ApiKey}&query='{queryParams}'";

            return queryComposite;

        }
    }
}
