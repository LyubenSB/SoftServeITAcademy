﻿using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.OperationalObjects
{
    public class TVSeries : IComparable<TVSeries>, IMotionPicture
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CompareTo(TVSeries other)
        {
            throw new NotImplementedException();
        }
    }
}