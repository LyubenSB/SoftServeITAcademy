using LMDB.ApiServices.Contratcts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class GenreCollectionHandler
    {

        public GenreCollectionHandler()
        {
            this.GenreCollection = new Dictionary<int, string>();
        }

        public Dictionary<int, string> GenreCollection { get; private set; }

        public void Composite(IList<GenreResponseObject> collectionToCompose)
        {
            foreach (var obj in collectionToCompose)
            {
                this.GenreCollection.Add(obj.Id, obj.Genre);
            }
        }
    }
}
