using LMDB.ApiServices.Contratcts;
using LMDB.ConsoleServices.Contracts;
using LMDB.ObjectModels.Contracts;
using System.Collections.Generic;

namespace LMDB.ApiServices.Strategies.SortingStrategy
{
    public class PrintDescendingStrategy : ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>
    {
        private readonly IWriter writer;

        public PrintDescendingStrategy(IWriter writer)
        {
            this.writer = writer;
        }

        public void ExectuteStrategy(string printOrder, ICollection<IMotionPictureData> collectionToPrint)
        {
            List<IMotionPictureData> printList = new List<IMotionPictureData>();

            foreach (var item in collectionToPrint)
            {
                printList.Add(item);
            }
            printList.Reverse();
            foreach (var item in printList)
            {
                writer.WriteLine(string.Join("\n", item.ToString()));
            }
        }
    }
}