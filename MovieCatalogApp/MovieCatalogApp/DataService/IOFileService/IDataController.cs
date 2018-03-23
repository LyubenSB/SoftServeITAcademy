using MovieCatalogApp.DataService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.DataService.IOFileService
{
    public interface IDataController
    {
        void LoadObjects(string filePath, IDataService dataService);
    }
}
