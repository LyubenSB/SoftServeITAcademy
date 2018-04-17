using Newtonsoft.Json;

namespace LMDB.ObjectModels.ResponseObjects
{
    public class NetworksResponseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string Country { get; set; }

    }
}