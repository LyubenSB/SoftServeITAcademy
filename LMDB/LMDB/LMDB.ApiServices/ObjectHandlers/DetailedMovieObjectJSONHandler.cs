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
    public class DetailedMovieObjectJSONHandler : IObjectHandler<string, DetailedMovieResponseObject>
    {
        public DetailedMovieObjectJSONHandler()
        {
            this.HandledResponseObjects = new List<DetailedMovieResponseObject>();
            this.Genres = new List<GenreResponseObject>();
        }

        public IList<DetailedMovieResponseObject> HandledResponseObjects { get; private set; }
        public List<GenreResponseObject> Genres { get; private set; }

        public void HandleObject(string objectToHandle)
        {
            this.HandledResponseObjects.Clear();
            JObject parseResults = JObject.Parse(objectToHandle);

            try
            {
                var parsedObject = parseResults.ToObject<DetailedMovieResponseObject>();
                this.HandledResponseObjects.Add(parsedObject);
            }
            catch (Exception)
            {}
            

        }


    }
}
