using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class ListTVSeriesByYearQueryBuilder : TMDBQueryBuilder
    {
        public override string BuildQuery(string queryParams)
        {
            string queryComposite = $"{Url}/discover/tv?api_key={ApiKey}&sort_by=popularity.desc&first_air_date_year={queryParams}";

            return queryComposite;
        }
    }
}
