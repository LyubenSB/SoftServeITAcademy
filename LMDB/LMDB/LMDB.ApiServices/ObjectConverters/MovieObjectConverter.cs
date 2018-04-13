using LMDB.ApiServices.Contratcts;
using LMDB.Core.DataService.Contracts;
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
    public class MovieObjectConverter : IObjectConverter
    {
        private IDataService<Movie> dataService;
        private IObjectHandler<MovieResponseObject, IList<MovieResponseObject>> objectHandler;

        public MovieObjectConverter(IDataService<Movie> dataService, IObjectHandler<MovieResponseObject, IList<MovieResponseObject>> objectHandler)
        {
            this.dataService = dataService;
            this.objectHandler = objectHandler;
        }

        public void Convert()
        {
            IList<MovieResponseObject> respObjcts = this.objectHandler.GetCollection();
            foreach (var respObj in respObjcts)
            {
                NonDetailMovie newMovie = new NonDetailMovie()
                {
                    MovieID = respObj.Id,
                    Title = respObj.Title,
                    ReleaseDate = respObj.ReleaseDate,
                    Description = respObj.Overview,
                };
                this.dataService.Add()
                    //DOTUK STIGNAGH
            }
        }
    }
}
