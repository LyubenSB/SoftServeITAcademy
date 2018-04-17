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
    public class PersonResponseObject 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

    }
}
