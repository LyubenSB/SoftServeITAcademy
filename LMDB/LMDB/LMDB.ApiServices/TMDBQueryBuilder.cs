using LMDB.ApiServices.Contratcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class TMDBQueryBuilder : IQueryBuilder
    {
        //USER'S APIKEY
        private const string url = "https://api.themoviedb.org/3";
        private const string apiKey = "81e01557d5026a137a95543112911069";

        public TMDBQueryBuilder()
        {
            
        }
        //http://api.themoviedb.org/3/search/movie?api_key=81e01557d5026a137a95543112911069&query=%22terminator%22

        public string BuildSearchQuery(string searchParameter)
        {
            string queryComposite = $"{url}/search/movie?api_key={apiKey}&query='{searchParameter}'";

            return queryComposite;
        }
    }
}
