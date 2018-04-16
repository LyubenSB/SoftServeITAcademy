using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class ListByGenreQueryBuidler : TMDBQueryBuilder
    {
        public int Page { get; private set; }

        public void SetPage(int page)
        {
            this.Page = page;
        }

        public override string BuildQuery(string queryParams)
        {
            //https://api.themoviedb.org/3/discover/movie?api_key=81e01557d5026a137a95543112911069&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_genres=28
            string queryComposite = $"{Url}/discover/movie?api_key={ApiKey}&sort_by=popularity.desc&page={this.Page}&&with_genres='{queryParams}'";

            return queryComposite;

        }
    }
}
