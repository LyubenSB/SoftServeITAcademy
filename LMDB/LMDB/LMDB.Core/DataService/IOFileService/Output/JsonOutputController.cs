using LMDB.DataService.Contracts;
using LMDB.ObjectModels
using MovieCatalogApp.DataService.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace MovieCatalogApp.DataService.IOFileService.Output
{
    /// <summary>
    /// Class responsible for saving and removing C# objects to external JSON file.
    /// </summary>
    public class JsonOutputController : IJsonOutputController
    {
        private IDataService dataService;
        private const string FILEPATH = @"..\..\..\SourceData\JsonMovieData.json";

        public JsonOutputController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Method responsible for reading JSON file.
        /// </summary>
        /// <returns>returns array of JSON objects</returns>
        private JArray ReadJson()
        {
            using (StreamReader readJson = new StreamReader(FILEPATH))
            {
                string jsonInfo = readJson.ReadToEnd();
                JArray jsonMovieList = JArray.Parse(jsonInfo);
                return jsonMovieList;
            }
        }

        /// <summary>
        /// Method responsible for adding C# objects to JSON file.
        /// </summary>
        /// <param name="movie">movie object</param>
        public void Add<Movie>(Movie movie)
        {
            //reading json
            var movieList = ReadJson();

            using (StreamWriter writeJson = new StreamWriter(FILEPATH))
            {
                //converting C# object to JSON object
                var movieToAdd = new JObject();

                movieToAdd["Title"] = movie.Title;
                movieToAdd["Genre"] = string.Join(", ", movie.Genre);
                movieToAdd["Description"] = movie.Description;
                movieToAdd["Director"] = movie.Director;
                movieToAdd["Actors"] = string.Join(", ", movie.Actors);
                movieToAdd["Year"] = movie.Year;
                movieList.Add(movieToAdd);

                //updating JSON file
                string outputJson = JsonConvert.SerializeObject(movieList, Formatting.Indented);
                writeJson.WriteLine(outputJson);
            }
        }

        /// <summary>
        /// Method responsible for removing movie objects from JSON file.
        /// </summary>
        /// <param name="movie">movie object</param>
        public void Remove<Movie>(Movie movie)
        {
            //reading json
            var movieList = ReadJson();

            using (StreamWriter wrtieJson = new StreamWriter(FILEPATH))
            {
                //removing specified movie object from the JSON file.
                var movieToRemove = movieList.Where(t => t.First.First.ToString() == movie.Title).FirstOrDefault();
                movieList.Remove(movieToRemove);

                //updating JSON file
                string outputJson = JsonConvert.SerializeObject(movieList, Formatting.Indented);
                wrtieJson.WriteLine(outputJson);
            }
        }
    }
}
