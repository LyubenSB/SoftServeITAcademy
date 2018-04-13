using LMDB.WebServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HttpClientProvider cltpr = new HttpClientProvider();
            var msg = cltpr.HttpGetAsync("https://api.themoviedb.org/3/movie/87101?api_key=81e01557d5026a137a95543112911069&append_to_response=credits");

            JObject searchObj = JObject.Parse(msg.Result);

            // get JSON result objects into a list
            IList<JToken> results = searchObj["responseData"]["results"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<SearchResult> searchResults = new List<SearchResult>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                SearchResult searchResult = result.ToObject<SearchResult>();
                searchResults.Add(searchResult);
            }
        }
    }
}
