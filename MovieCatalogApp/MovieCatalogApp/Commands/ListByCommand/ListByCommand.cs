﻿using MovieCatalogApp.Commands.Contracts;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.DataService.InMemoryDataService;
using MovieCatalogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieCatalogApp.Commands.ListByCommand
{
    public class ListByCommand : ICommand
    {
        private IDataService dataService;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<string> collectedData;

        public ListByCommand(IDataService dataService, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("=================");
            writer.WriteLine("List Movies by:");
            writer.WriteLine("Genre | Actor | Director | Year | All Movies");
            writer.WriteLine("=================");
            collectedData.Add(reader.ReadLine());

        }

        public string Execute()
        {
            CollectData();
            string listedObjectsBy = collectedData[0];

            switch (listedObjectsBy)
            {
                case "All Movies":
                    writer.WriteLine(string.Join("\n", this.dataService.MovieList));
                    break;

                case "Genre":
                    writer.WriteLine("Enter Genre:");
                    string genre = reader.ReadLine();
                    var moviesByGenre = dataService.MovieList.Where(x => x.Genre.Contains(genre)).ToList();
                    writer.WriteLine(string.Join("\n", moviesByGenre));
                    break;

                case "Actor":
                    writer.WriteLine("Enter Actor:");
                    string actor = reader.ReadLine();
                    var moviesByActor = dataService.MovieList.Where(x => x.Actors.Contains(actor)).ToList();
                    writer.WriteLine(string.Join("\n", moviesByActor));
                    break;

                case "Director":
                    writer.WriteLine("Enter Director:");
                    string director = reader.ReadLine();
                    var moviesByDirector = dataService.MovieList.Where(x => x.Director.Contains(director)).ToList();
                    writer.WriteLine(string.Join("\n", moviesByDirector));
                    break;

                case "Year":
                    writer.WriteLine("Enter Year:");
                    int year = int.Parse(reader.ReadLine());
                    var moviesByYear = dataService.MovieList.Where(x => x.Year == year).ToList();
                    writer.WriteLine(string.Join("\n", moviesByYear));
                    break;

                default:
                    writer.WriteLine("Invalid Input!Enter either one of these parameters to list movies");
                    writer.WriteLine("Genre | Actor | Director | Year | All Movies");
                    break;
            }
            return @"=================
Movies Listed!
=================";
        }
    }
}
