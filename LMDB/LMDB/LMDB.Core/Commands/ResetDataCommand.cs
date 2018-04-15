using LMDB.ConsoleServices.Contracts;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using System.Collections.Generic;

namespace LMDB.Core.Commands
{
    /// <summary>
    /// Class representing the implementation of reseting the in-memory collection of objects to its initial state.
    /// </summary>
    public class ResetDataCommand : ICommand
    {
        private IDataService<IMotionPicture> dataService;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public ResetDataCommand(IDataService<IMotionPicture> dataService, IWriter writer, IReader reader)
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
                    writer.WriteLine("Invalid Input. Type 'yes' or 'no'");
                    this.collectedData.Clear();
                    this.Execute();
                    break;
            }
            
            return @"Enter Command:...
(For help type '/help')";

        }
    }
}
