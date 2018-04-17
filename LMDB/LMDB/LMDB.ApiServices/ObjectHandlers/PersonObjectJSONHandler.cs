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
    public class PersonObjectJSONHandler : IObjectHandler<string, PersonResponseObject>
    {
        public PersonObjectJSONHandler()
        {
            this.HandledResponseObjects = new List<PersonResponseObject>();
        }

        public IList<PersonResponseObject> HandledResponseObjects { get; private set; }

        public void HandleObject(string objectToHandle)
        {
            JObject parseResults = JObject.Parse(objectToHandle);

            IList<JToken> objectResults = parseResults["results"].Children().ToList();

            foreach (var obj in objectResults)
            {
                PersonResponseObject objectToAdd = obj.ToObject<PersonResponseObject>();
                HandledResponseObjects.Add(objectToAdd);
            }
        }
    }
}
