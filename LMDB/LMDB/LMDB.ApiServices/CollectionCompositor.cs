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
    public class CollectionCompositor
    {
        private IDataService<IMotionPicture> dataService;


        public CollectionCompositor(IDataService<IMotionPicture> dataService)
        {
            this.dataService = dataService;
        }

        public void Composite(ICollection<IMotionPicture> collectionToCompose)
        {
            foreach (var obj in collectionToCompose)
            {
                this.dataService.Add(obj);
            }
        }
    }
}
