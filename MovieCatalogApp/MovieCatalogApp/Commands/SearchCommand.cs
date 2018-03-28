using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    public class SearchCommand : ICommand
    {
        private IDataService dataService;
        private IReader reader;
        private IWriter writer;
        private List<string> collectedData;

        public SearchCommand(IDataService dataService, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("Enter Movie Title: ");
            collectedData.Add(reader.ReadLine());
        }

        private void BinarySearch()
        {

        }

        public string Execute()
        {
            BinarySearch();

            return (@"=================
New Movie Is Registered!
=================");
        }
    }
}
