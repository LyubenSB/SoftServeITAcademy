using LMDB.ApiServices.Contratcts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.OperationalObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.ObjectConverters
{
    public class TVSeriesObjectConverter : IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>
    {
        private IDataService<IMotionPicture> dataService;
        private IObjectHandler<string, IResponseObject> objectHandler;

        public TVSeriesObjectConverter(IDataService<IMotionPicture> dataService, IObjectHandler<string, IResponseObject> objectHandler)
        {
            this.dataService = dataService;
            this.objectHandler = objectHandler;
        }

        public ICollection<IMotionPicture> ConvertedObjects { get; private set; }

        public void Convert(ICollection<IResponseObject> objctsToConvert)
        {
            foreach (var respObj in objctsToConvert)
            {
                TVSeries newTVseries = new TVSeries()
                {
                //    Id = respObj.Id,
                //    Title = respObj.Title,
                //    ReleaseDate = respObj.ReleaseDate,
                //    Description = respObj.Overview,
                };
                ConvertedObjects.Add(newTVseries);
            }
        }
    }
}
