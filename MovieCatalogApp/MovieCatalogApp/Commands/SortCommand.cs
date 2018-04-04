using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
    /// <summary>
    /// Class representing the implementation of sorting movie objects in the in-memory collection by a set of given user input parameters.
    /// </summary>
    public class SortCommand : ICommand
    {
        private IDataService dataService;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public SortCommand(IDataService dataService, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
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

        /// <summary>
        /// Implementation of Quicksort algorithm
        /// </summary>
        /// <param name="elements">Collection of elements to be sorted</param>
        /// <param name="left">left index</param>
        /// <param name="right">right index</param>
        public void QuickSortByYear(Movie[] elements, int left, int right)
        {
            //iterators
            int i = left;
            int j = right;
            
            //pivot element
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].Year < pivot.Year)
                {
                    i++;
                }

                while (elements[j].Year > pivot.Year)
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
                this.dataService.MovieList = elements;
            }

        }
        public void QuickSortByTitle(Movie[] elements, int left, int right)
        {
            //iterators
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
                this.dataService.MovieList = elements;
            }

        }

        /// <summary>
        /// Method responsible for printing the sorted collection in ascending or descending order.
        /// </summary>
        /// <param name="order">sorting order</param>
        /// <param name="movieList">sorted collection</param>
        public void PrintInOrder(string order, ICollection<Movie> movieList)
        {
            switch (order)
            {
                case "ascending":
                    writer.WriteLine(string.Join("\n", movieList));
                    break;
                case "descending":
                    writer.WriteLine(string.Join("\n", movieList.Reverse()));
                    break;
                default:
                    writer.WriteLine("");
                    writer.WriteLine("Invalid Input! Type either one of these parameters to sort movies!");
                    writer.WriteLine("");
                    collectedData.Clear();
                    this.Execute();
                    break;
            }
        }


        public string Execute()
        {
            CollectData();
            string sortBy = collectedData[0];
            string sortingOrder = collectedData[1];

            //Stopwatch for measuring elapsed time while sorting.
            Stopwatch stopwatch = new Stopwatch();

            switch (sortBy)
            {
                case "title":
                    var moviesByTitle = this.dataService.MovieList.ToArray();
                    stopwatch.Start();
                    QuickSortByTitle(moviesByTitle, 0, this.dataService.MovieList.Count - 1);
                    stopwatch.Stop();
                    PrintInOrder(sortingOrder, moviesByTitle);
                    break;
                case "year":
                    var moviesByYear = this.dataService.MovieList.ToArray();
                    stopwatch.Start();
                    QuickSortByYear(moviesByYear, 0, this.dataService.MovieList.Count - 1);
                    stopwatch.Stop();
                    PrintInOrder(sortingOrder, moviesByYear);
                    break;
                default:
                    writer.WriteLine("");
                    writer.WriteLine("Invalid Input! Type either one of these parameters to sort movies!");
                    writer.WriteLine("");
                    collectedData.Clear();
                    this.Execute();
                    break;
            }

            Console.WriteLine(@"
Searching done! Time Elapsed : {0} ticks", stopwatch.ElapsedTicks.ToString());

            return @"

=================
Movies Listed!
=================";
        }
    }
}
