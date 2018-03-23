﻿using MovieCatalogApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Wintellect.PowerCollections;
using MovieCatalogApp.DataService.Contracts;

namespace MovieCatalogApp.DataService.IOFileService.Input
{
    public class JsonInputController : IDataController
    {
        private IDataService dataService;

        public JsonInputController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public void LoadObjects(string filePath)
        {
            using (StreamReader readJson = new StreamReader(filePath))
            {
                string jsonInfo = readJson.ReadToEnd();
                var jsonObject = JObject.Parse(jsonInfo);

                foreach (var jsonMovie in jsonObject["movies"])
                {
                    dataService.Add(new Movie()
                    {
                        Title = jsonMovie.Value<string>("Title"),
                        Genre = jsonMovie.Value<string>("Genre").Split(','),
                        Description = jsonMovie.Value<string>("Description"),
                        Director = jsonMovie.Value<string>("Director"),
                        Actors = jsonMovie.Value<string>("Actors").Split(','),
                        Year = jsonMovie.Value<int>("Year"),
                    });
                }
                RemoveEmptySpaces(dataService.MovieList);
            }
        }

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
