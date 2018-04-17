using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.OperationalObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.ResponseObjects
{
    public class DetailedMovieResponseObject : IResponseObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("genres")]
        public ICollection<GenreResponseObject> Genres{get;set;}

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("vote_average")]
        public string Rating { get; set; }

        [JsonProperty("budget")]
        public decimal Budget { get; set; }
               
    }
}
