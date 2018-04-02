using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands
{
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
            writer.WriteLine("=================");
            writer.WriteLine("Sort by Ascending or Descendig Order:");
            writer.WriteLine("ascending | descending");
            writer.WriteLine("=================");
            collectedData.Add(reader.ReadLine());

        }

        public void QuickSortByYear(Movie[] elements, int left, int right)
        {
            
            int i = left;
            int j = right;
            
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
                    // Swap
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
                this.dataService.EditedMovieList = elements;
            }

        }
        public void QuickSortByTitle(Movie[] elements, int left, int right)
        {

            int i = left;
            int j = right;

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
                    // Swap
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
                this.dataService.EditedMovieList = elements;
            }

        }


        public string Execute()
        {
            CollectData();
            string sortBy = collectedData[0];

            switch (sortBy)
            {
                case "title":
                    var moviesByTitle = this.dataService.EditedMovieList.ToArray();
                    QuickSortByTitle(moviesByTitle, 0, this.dataService.EditedMovieList.Count - 1);
                    writer.WriteLine(string.Join("\n", this.dataService.EditedMovieList));
                    break;
                case "year":
                    var moviesByYear = this.dataService.EditedMovieList.ToArray();
                    QuickSortByYear(moviesByYear, 0, this.dataService.EditedMovieList.Count - 1);
                    writer.WriteLine(string.Join("\n", this.dataService.EditedMovieList));
                    break;
                default:
                    break;
            }

           return @"

=================
Movies Listed!
=================";
        }
    }
}
