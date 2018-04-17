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
    public class DetailTVSeriesObjectConverter : IObjectConverter<DetailedTVseriesResponseObject, IMotionPictureData>
    {
        private IObjectHandler<string, DetailedTVseriesResponseObject> objectHandler;

        public DetailTVSeriesObjectConverter(IObjectHandler<string, DetailedTVseriesResponseObject> objectHandler)
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

        private void ConvertNetworks(ICollection<NetworksResponseObject> inputNetworks, ICollection<Networks> outputNetworks)
        {
            foreach (var inputGenre in inputNetworks)
            {
                Networks network = new Networks()
                {
                    Name = inputGenre.Name,
                    Country = inputGenre.Country

                };
                outputNetworks.Add(network);
            }
        }


        public void Convert(DetailedTVseriesResponseObject objctToConvert)
        {

            DetailedTVSeries newTVSeries = new DetailedTVSeries()
            {
                Id = objctToConvert.Id,
                Title = objctToConvert.Title,
                ReleaseDate = objctToConvert.ReleaseDate,
                NumberOfEpisodes = objctToConvert.NumberOfEpisodes,
                NumberOfSeasons = objctToConvert.NumberOfSeasons,
                Overview = objctToConvert.Overview,
                Rating = objctToConvert.Rating,
                Status = objctToConvert.Status
            };

            ConvertGenres(objctToConvert.Genres, newTVSeries.Genres);
            ConvertNetworks(objctToConvert.Networks, newTVSeries.Networks);

            this.ConvertedObjects = newTVSeries;
        }
    }

}


