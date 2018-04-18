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
    public class SortByTitleStrategy : ICallProcessorStrategy<string>
    {
        private readonly IDataService<IMotionPictureData> dataService;
        private readonly PrintingContext processorContext;
        private readonly ICallProcessorStrategy<string> printOrderStr;

        public SortByTitleStrategy(IDataService<IMotionPictureData> dataService, PrintingContext processorContext)
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

            QuickSortByTitle(collectionToBeSorted, leftIndex, rightIndex);

            processorContext.ContextExecute(sortingOrder, this.SortedCollection);
        }

        private void QuickSortByTitle(IMotionPictureData[] elements, int left, int right)
        { //iterators
            int i = left;
            int j = right;

            //pivot elements
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].Title.CompareTo(pivot.Title) < 0)
                {
                    i++;
                }

                while (elements[j].Title.CompareTo(pivot.Title) > 0)
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
                QuickSortByTitle(elements, left, j);
            }

            if (i < right)
            {
                QuickSortByTitle(elements, i, right);
            }
            else
            {
                this.SortedCollection = elements;
            }
        }
    }
}
