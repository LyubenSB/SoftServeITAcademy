﻿using LMDB.ApiServices.Contratcts;
using LMDB.Core.DataService.Contracts;
using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.Models;
using LMDB.ObjectModels.OperationalObjects;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.ObjectConverters
{
    public class MovieObjectConverter : IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPicture>>
    {
        private IObjectHandler<string, IResponseObject> objectHandler;

        public MovieObjectConverter(IObjectHandler<string, IResponseObject> objectHandler)
        {
            this.objectHandler = objectHandler;
            this.ConvertedObjects = new List<IMotionPicture>();
        }

        public ICollection<IMotionPicture> ConvertedObjects { get; private set; }

        public void Convert(ICollection<IResponseObject> objctsToConvert)
        {
            foreach (var respObj in objctsToConvert)
            {
                Movie newMovie = new Movie()
                {
                    Id = respObj.Id,
                    Title = respObj.Title,
                    ReleaseDate = respObj.ReleaseDate,
                    Description = respObj.Overview,
                };
                ConvertedObjects.Add(newMovie);
            }
            
        }

        
    }
}