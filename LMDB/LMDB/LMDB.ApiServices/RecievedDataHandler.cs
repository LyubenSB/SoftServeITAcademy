using LMDB.ApiServices.Contratcts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ApiServices.ObjectConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class RecievedDataHandler : IDataHandler<ICollection<IMotionPictureData>>
    {
        private IDataService<IMotionPictureData> dataService;

        public RecievedDataHandler(IDataService<IMotionPictureData> dataService)
        {
            this.dataService = dataService;
        }

        public void Composite(ICollection<IMotionPictureData> collectionToCompose)
        {
            this.dataService.ResetData();

            foreach (var obj in collectionToCompose)
            {
                this.dataService.Add(obj);
            }
        }

        public void AddDetailedObject(IMotionPictureData objectToAdd)
        {
            this.dataService.ResetData();
            this.dataService.AddDetailedObject(objectToAdd);
        }
    }
}
