using LMDB.ApiServices.Contratcts;
using LMDB.ConsoleServices.Contracts;
using LMDB.ObjectModels.Contracts;
using System.Collections.Generic;

namespace LMDB.ApiServices.Strategies.SortingStrategy
{
    public class PrintAscendingStrategy : ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>
    {
        private readonly IWriter writer;

        public PrintAscendingStrategy( IWriter writer)
        {
            this.writer = writer;
        }

        public void ExectuteStrategy(string printOrder, ICollection<IMotionPictureData> collectionToPrint)
        {

            foreach (var item in collectionToPrint)
            {
                writer.WriteLine(string.Join("\n", item.ToString()));
            }
        }
    }
}