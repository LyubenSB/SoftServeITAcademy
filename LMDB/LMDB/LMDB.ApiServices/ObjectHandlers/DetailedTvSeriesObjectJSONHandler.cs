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
    public class DetailedTvSeriesObjectJSONHandler : IObjectHandler<string, DetailedTVseriesResponseObject>
    {
        public DetailedTvSeriesObjectJSONHandler()
        {
            this.HandledResponseObjects = new List<DetailedTVseriesResponseObject>();
            this.Genres = new List<GenreResponseObject>();
        }

        public IList<DetailedTVseriesResponseObject> HandledResponseObjects { get; private set; }
        public List<GenreResponseObject> Genres { get; private set; }

        public void HandleObject(string objectToHandle)
        {
            JObject parseResults = JObject.Parse(objectToHandle);

            var parsedObject = parseResults.ToObject<DetailedTVseriesResponseObject>();
            this.HandledResponseObjects.Add(parsedObject);

        }


    }
}
