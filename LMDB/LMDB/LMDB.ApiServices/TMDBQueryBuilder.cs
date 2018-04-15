using LMDB.ApiServices.Contratcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public abstract class TMDBQueryBuilder : IQueryBuilder<string>
    {
        //USER'S APIKEY
        private const string url = "https://api.themoviedb.org/3";
        private const string apiKey = "81e01557d5026a137a95543112911069";

        protected string Url { get { return url; } }

        protected string ApiKey { get { return apiKey; } }

        public abstract string BuildQuery(string queryParams);

    }
}
