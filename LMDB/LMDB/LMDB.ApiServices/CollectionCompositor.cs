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
    public class CollectionCompositor : ICollectionCompositor<ICollection<IMotionPictureData>>
    {
        private IDataService<IMotionPictureData> dataService;

        public CollectionCompositor(IDataService<IMotionPictureData> dataService)
        {
            this.dataService = dataService;
        }

        public void Composite(ICollection<IMotionPictureData> collectionToCompose)
        {
            foreach (var obj in collectionToCompose)
            {
                this.dataService.Add(obj);
            }
        }
    }
}
