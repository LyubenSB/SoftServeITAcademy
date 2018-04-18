using LMDB.ApiServices.Contratcts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.OperationalObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies.SortingStrategy
{
    public class SortByYearStrategy : ICallProcessorStrategy<string>
    {
        private readonly IDataService<IMotionPictureData> dataService;
        private readonly PrintingContext processorContext;
        private readonly ICallProcessorStrategy<string> printOrderStr;

        public SortByYearStrategy(IDataService<IMotionPictureData> dataService, PrintingContext processorContext)
        {
            this.dataService = dataService;
            this.processorContext = processorContext;
        }

        public ICollection<IMotionPictureData> SortedCollection { get; private set; }

        public void ExectuteStrategy(string sortingOrder)
        {
            var collectionToBeSorted = this.dataService.MovieList.ToArray();

            int leftIndex = 0;

            int rightIndex = collectionToBeSorted.Length - 1;

            QuickSortByYear(collectionToBeSorted, leftIndex, rightIndex);

            processorContext.ContextExecute(sortingOrder, this.SortedCollection);
        }

        private void QuickSortByYear(IMotionPictureData[] elements, int left, int right)
        {
            //iterators
            int i = left;
            int j = right;

            //pivot element
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].ReleaseDate < pivot.ReleaseDate)
                {
                    i++;
                }

                while (elements[j].ReleaseDate > pivot.ReleaseDate)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swapping
                    var tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSortByYear(elements, left, j);
            }

            if (i < right)
            {
                QuickSortByYear(elements, i, right);
            }
            else
            {
                this.SortedCollection = elements;
            }

        }
    }
}
