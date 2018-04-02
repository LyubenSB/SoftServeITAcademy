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
    public class ResetDataCommand : ICommand
    {
        private IDataService dataService;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public ResetDataCommand(IDataService dataService, IWriter writer, IReader reader)
        {
            this.dataService = dataService;
            this.writer = writer;
            this.reader = reader;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("Are you sure you want to reset current session?");
            writer.WriteLine("(yes/no)");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string userChoice = collectedData[0];

            switch (userChoice)
            {
                case "yes":
                    this.dataService.ResetData();
                    break;

                case "no":
                    break;
                default:
                    writer.WriteLine("Type 'yes' or 'no'");
                    break;
            }

            return "Enter Command:...";
        }
    }
}
