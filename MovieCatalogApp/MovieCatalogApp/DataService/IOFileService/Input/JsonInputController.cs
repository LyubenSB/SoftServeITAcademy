using MovieCatalogApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Wintellect.PowerCollections;

namespace MovieCatalogApp.DataService.IOFileService.Input
{
    public class JsonInputController
    {
        public static ICollection<Movie> ParseJsonToMovieObj(string jsonFilePath)
        {
            using (StreamReader readJson = new StreamReader(jsonFilePath))
            {
                string jsonInfo = readJson.ReadToEnd();
                var jsonObject = JObject.Parse(jsonInfo);
                ICollection<Movie> movies = new OrderedSet<Movie>();

                foreach (var jsonMovie in jsonObject["movies"])
                {
                    movies.Add(new Movie()
                    {
                        Title = jsonMovie.Value<string>("Title"),
                        Genre = jsonMovie.Value<string>("Genre").Split(','),
                        Description = jsonMovie.Value<string>("Description"),
                        Director = jsonMovie.Value<string>("Director"),
                        Actors = jsonMovie.Value<string>("Actors").Split(','),
                        Year = jsonMovie.Value<int>("Year"),
                    });
                }
                RemoveEmptySpaces(movies);
                return movies;
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
