using LMDB.ObjectModels.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.ResponseObjects
{
    public class MovieDetailsResponseObject : IResponseObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Overview { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ReleaseDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
