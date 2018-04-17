using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class GetTVSeriesDetailsQueryBuilder : TMDBQueryBuilder
    {
        //https://api.themoviedb.org/3/movie/150?api_key=81e01557d5026a137a95543112911069&language=en-US
        public override string BuildQuery(string queryParams)
        {
            string queryComposite = $"{Url}/tv/{queryParams}?api_key={ApiKey}";

            return queryComposite;
        }
    }
}
