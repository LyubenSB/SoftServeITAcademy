using MovieCatalogApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Wintellect.PowerCollections;
using MovieCatalogApp.DataService.Contracts;

namespace MovieCatalogApp.DataService.IOFileService.Input
{
    /// <summary>
    /// Class responsible for loading movie dataset from external JSON file.
    /// </summary>
    public class JsonInputController
    {
        //the path of the external JSON file.
        private string FILEPATH = @"..\..\..\SourceData\JsonMovieData.json";
        private IDataService dataService;

        public JsonInputController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Method responsible for loading objects from the JSON file.
        /// </summary>
        public void LoadObjects()
        {
            using (StreamReader readJson = new StreamReader(FILEPATH))
            {
                //reads the json file
                string jsonInfo = readJson.ReadToEnd();
                
                //parsing the json file to a json Array
                var jsonObject = JArray.Parse(jsonInfo);

                //parsing JSON objects to C# classes
                foreach (var jsonMovie in jsonObject)
                {
                    dataService.Add(new Movie()
                    {
                        Title = jsonMovie.Value<string>("Title"),
                        Genre = jsonMovie.Value<string>("Genre").Split(','),
                        Description = jsonMovie.Value<string>("Description"),
                        Director = jsonMovie.Value<string>("Director"),
                        Actors = jsonMovie.Value<string>("Actors").Split(','),
                        Year = jsonMovie.Value<int>("Year")
                    });
                }
                //removing empty spaces from JSON file's object properties.
                RemoveEmptySpaces(dataService.InitialMovieList);

                //initializing in-memory collection responsible for data manipulation during application execution
                this.dataService.ResetData();
            }
        }

        /// <summary>
        /// Method responsile for removing empty spaces from JSON object's properties
        /// </summary>
        /// <param name="movies">In-memory collection of movies</param>
        private static void RemoveEmptySpaces(ICollection<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                foreach (var genre in movie.Genre)
                {
                    genre.Trim();
                }
                foreach (var actor in movie.Actors)
                {
                    actor.Trim();
                }
            }
        }
    }
}
