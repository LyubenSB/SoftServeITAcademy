using MovieCatalogApp.Core.Providers;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.IOFileService.Input;
using MovieCatalogApp.IoCNinject;
using MovieCatalogApp.Models;
using Ninject;
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
            //string filePath = @"..\..\..\SourceData\JsonMovieData.json";
            //ICollection<Movie> movies = JsonInputController.ParseJsonToMovieObj(filePath);

            //foreach (var movie in movies)
            //{
            //    Console.WriteLine(movie.ToString());
            //}


            IKernel kernel = new StandardKernel(new MovieCatalogModule());
            IEngine engine = kernel.Get<Engine>();
            engine.Start();
        }
    }
}
