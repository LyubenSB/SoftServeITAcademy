using MovieCatalogApp.DataService.IOFileService.Input;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp
{
    public class StartUp
    {
        //@"..\..\..\SourceData\JsonMovieData.json";
        public static void Main(string[] args)
        {
            string filePath = @"..\..\..\SourceData\JsonMovieData.json";
            ICollection<Movie> movies = JsonInputController.ParseJsonToMovieObj(filePath);

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.ToString());
            }
        }
    }
}
