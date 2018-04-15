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
    public class TVObjectJSONHandler : IObjectHandler<string, IResponseObject>
    {
        public TVObjectJSONHandler()
        {
            this.HandledResponseObjects = new List<IResponseObject>();
        }

        public IList<IResponseObject> HandledResponseObjects { get; private set; }

        public void HandleObject(string objectToHandle)
        {
            JObject parseResults = JObject.Parse(objectToHandle);

            IList<JToken> objectResults = parseResults["results"].Children().ToList();

            foreach (var obj in objectResults)
            {
                IResponseObject objectToAdd = obj.ToObject<TVSeriesResponseObject>();
                HandledResponseObjects.Add(objectToAdd);
            }
        }


    }
}
