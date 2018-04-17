using LMDB.ApiServices.Contratcts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.Models;
using LMDB.ObjectModels.OperationalObjects;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.ObjectConverters
{
    public class DetailMovieObjectConverter : IObjectConverter<DetailedMovieResponseObject, IMotionPictureData>
    {
        private IObjectHandler<string, DetailedMovieResponseObject> objectHandler;

        public DetailMovieObjectConverter(IObjectHandler<string, DetailedMovieResponseObject> objectHandler)
        {
            this.objectHandler = objectHandler;

        }

        public IMotionPictureData ConvertedObjects { get; private set; }

        private void ConvertGenres(ICollection<GenreResponseObject> inputGenres, ICollection<Genre> outputGenres)
        {
            foreach (var inputGenre in inputGenres)
            {
                Genre genre = new Genre()
                {
                    Id = inputGenre.Id,
                    Genres = inputGenre.Genre

                };
                outputGenres.Add(genre);
            }
        }


        public void Convert(DetailedMovieResponseObject objctToConvert)
        {

            DetailedMovie newMovie = new DetailedMovie()
            {
                Id = objctToConvert.Id,
                Title = objctToConvert.Title,
                ReleaseDate = objctToConvert.ReleaseDate,
                Overview = objctToConvert.Overview,
                Rating = objctToConvert.Rating,
                Budget = objctToConvert.Budget,
                Runtime = objctToConvert.Runtime
            };

            ConvertGenres(objctToConvert.Genres, newMovie.Genres);

            this.ConvertedObjects = newMovie;
        }
    }

}


