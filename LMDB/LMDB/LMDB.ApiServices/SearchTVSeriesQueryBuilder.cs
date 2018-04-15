using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class SearchTVSeriesQueryBuilder : TMDBQueryBuilder
    {
        public override string BuildQuery(string queryParams)
        {
            string queryComposite = $"{Url}/search/tv?api_key={ApiKey}&query='{queryParams}'";

            return queryComposite;
        }
    }
}
