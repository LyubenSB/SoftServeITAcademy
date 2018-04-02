using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.DataService.IOFileService.Output
{
    public class JsonOutputController
    {
        private IDataService dataService;
        private const string FILEPATH = @"..\..\..\SourceData\JsonMovieData.json";

        public JsonOutputController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        private JArray ReadJson()
        {
            using (StreamReader readJson = new StreamReader(FILEPATH))
            {
                string jsonInfo = readJson.ReadToEnd();
                JArray jsonMovieList = JArray.Parse(jsonInfo);
                return jsonMovieList;
            }
        }

        //TODO:QUESTIONABLE QUALITY 
        public void SaveMovieToFile(Movie movie)
        {
            var movieList = ReadJson();

            using (StreamWriter writeJson = new StreamWriter(FILEPATH))
            {
                var movieToAdd = new JObject();

                movieToAdd["Title"] = movie.Title;
                movieToAdd["Genre"] = string.Join(", ", movie.Genre);
                movieToAdd["Description"] = movie.Description;
                movieToAdd["Director"] = movie.Director;
                movieToAdd["Actors"] = string.Join(", ", movie.Actors);
                movieToAdd["Year"] = movie.Year;
                movieList.Add(movieToAdd);

                string outputJson = JsonConvert.SerializeObject(movieList, Formatting.Indented);
                writeJson.WriteLine(outputJson);
            }
        }

        public void RemoveMovieFromFile(Movie movie)
        {
            var movieList = ReadJson();

            using (StreamWriter wrtieJson = new StreamWriter(FILEPATH))
            {
                var movieToRemove = new JObject();

                movieToRemove["Title"] = movie.Title;
                movieToRemove["Genre"] = string.Join(", ", movie.Genre);
                movieToRemove["Description"] = movie.Description;
                movieToRemove["Director"] = movie.Director;
                movieToRemove["Actors"] = string.Join(", ", movie.Actors);
                movieToRemove["Year"] = movie.Year;

                movieList.Remove(movieToRemove.Parent);

                string outputJson = JsonConvert.SerializeObject(movieList, Formatting.Indented);
                wrtieJson.WriteLine(outputJson);
            }
        }

    }
}
