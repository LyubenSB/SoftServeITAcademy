using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class ListMoviesByYearQueryBuilder : TMDBQueryBuilder
    {
        public override string BuildQuery(string queryParams)
        {
            string queryComposite = $"{Url}/discover/movie?api_key={ApiKey}&sort_by=popularity.desc&year={queryParams}";

            return queryComposite;
        }
    }
}
