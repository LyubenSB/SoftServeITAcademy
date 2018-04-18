using LMDB.ApiServices;
using LMDB.ConsoleServices.Contracts;
using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace LMDB.Core.Commands.ListByCommand
{
    /// <summary>
    /// Class representing the implementation of listing data by a given parameter.
    /// </summary>
    public class SortObjectsCommand : ICommand
    {
        private IDataService<IMotionPictureData> dataService;
        private readonly ProcessorContext processorCtx;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public SortObjectsCommand(IDataService<IMotionPictureData> dataService, ProcessorContext processorCtx, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.processorCtx = processorCtx;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("=================");
            writer.WriteLine("Sort Movies by:");
            writer.WriteLine("title | year");
            writer.WriteLine("=================");
            collectedData.Add(reader.ReadLine());


            if (string.IsNullOrEmpty(collectedData[0]) || string.IsNullOrWhiteSpace(collectedData[0]))
            {
                writer.WriteLine("Invalid Input! Type either one of these parameters to sort movies!");
                collectedData.Remove(collectedData[0]);
                CollectData();
            }

            writer.WriteLine("=================");
            writer.WriteLine("Sort by Ascending or Descendig Order:");
            writer.WriteLine("ascending | descending");
            writer.WriteLine("=================");
            collectedData.Add(reader.ReadLine());


            if (string.IsNullOrEmpty(collectedData[1]) || string.IsNullOrWhiteSpace(collectedData[1]))
            {
                writer.WriteLine("Invalid Input! Type either one of these parameters to sort movies!");
                collectedData.Clear();
                CollectData();
            }
        }

        public string Execute()
        {
            CollectData();
            //sort by parameter
            string strategyCtx = "sortby" + collectedData[0];

            //sorting order
            string sortingParametr = collectedData[1];

            this.processorCtx.AddParameter(sortingParametr);
            this.processorCtx.ContextExecute(strategyCtx);

            return @"

======================================================================================================================================
Movies Sorted!
======================================================================================================================================";
        }
    }
}
