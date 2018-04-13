using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.ResponseObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.ObjectHandlers
{
    public class MovieObjectJSONHandler : IObjectHandler<string, IList<MovieResponseObject>>
    {
        public MovieObjectJSONHandler()
        {
            IList<MovieResponseObject> responseObjectCollection = new List<MovieResponseObject>();
        }

        public IList<MovieResponseObject> ResponseObjectCollection { get; private set; }

        public void HandleObject(string objectToHandle)
        {
            JObject parseResults = JObject.Parse(objectToHandle);

            IList<JToken> objectResults = parseResults["results"].Children().ToList();

            foreach (var obj in objectResults)
            {
                MovieResponseObject objectToAdd = obj.ToObject<MovieResponseObject>();
                ResponseObjectCollection.Add(objectToAdd);
            }
        }

        public IList<MovieResponseObject> GetCollection()
        {
            return this.ResponseObjectCollection;
        }
    }
}
