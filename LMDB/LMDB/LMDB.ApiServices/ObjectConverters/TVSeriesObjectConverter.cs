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
    public class TVSeriesObjectConverter : IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>>
    {
        private IObjectHandler<string, IResponseObject> objectHandler;

        public TVSeriesObjectConverter(IObjectHandler<string, IResponseObject> objectHandler)
        {
            this.objectHandler = objectHandler;
            this.ConvertedObjects = new List<IMotionPictureData>();
        }

        public ICollection<IMotionPictureData> ConvertedObjects { get; private set; }

        public void Convert(ICollection<IResponseObject> objctsToConvert)
        {
            foreach (var respObj in objctsToConvert)
            {
                TVSeries newTVseries = new TVSeries()
                {
                    Id = respObj.Id,
                    Title = respObj.Title,
                    ReleaseDate = respObj.ReleaseDate,
                };
                ConvertedObjects.Add(newTVseries);
            }
        }
    }
}
