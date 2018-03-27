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
        private const string FILEPATH = @"..\..\..\SourceData\TEST.json";

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
        public void SaveMovieToFile(Movie movieToSave)
        {
            var movieList = ReadJson();

            using (StreamWriter writeJson = new StreamWriter(FILEPATH, true))
            {
                var movieToAdd = new JObject();

                movieToAdd["Title"] = movieToSave.Title;
                movieToAdd["Genre"] = string.Join(", ", movieToSave.Genre);
                movieToAdd["Description"] = movieToSave.Description;
                movieToAdd["Director"] = movieToSave.Director;
                movieToAdd["Actors"] = string.Join(", ", movieToSave.Actors);
                movieToAdd["Year"] = movieToSave.Year;
                movieList.Add(movieToAdd);

                string outputJson = JsonConvert.SerializeObject(movieList, Formatting.Indented);
                writeJson.WriteLine(outputJson);
            }
        }

    }
}
