using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.ObjectHandlers
{
    /// <summary>
    /// Handles incoming json response and converts it to C# POCO objects
    /// </summary>
    public class GenreObjectJSONHandler : IObjectHandler<string, GenreResponseObject>
    {
        public GenreObjectJSONHandler()
        {
            this.HandledResponseObjects = new List<GenreResponseObject>();
        }

        public IList<GenreResponseObject> HandledResponseObjects { get; private set; }

        public void HandleObject(string objectToHandle)
        {
            JObject parseResults = JObject.Parse(objectToHandle);

            IList<JToken> objectResults = parseResults["genres"].Children().ToList();

            foreach (var obj in objectResults)
            {
                GenreResponseObject objectToAdd = obj.ToObject<GenreResponseObject>();
                HandledResponseObjects.Add(objectToAdd);
            }
        }


    }
}
