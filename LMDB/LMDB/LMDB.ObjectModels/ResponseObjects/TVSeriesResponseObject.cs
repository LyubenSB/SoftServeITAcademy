using LMDB.ObjectModels.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.ResponseObjects
{
    public class TVSeriesResponseObject : IResponseObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("first_air_date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
