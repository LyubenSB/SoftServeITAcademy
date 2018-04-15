using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.OperationalObjects
{
    public class DetailedTVSeries : IComparable<DetailedTVSeries>, IMotionPictureData
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CompareTo(DetailedTVSeries other)
        {
            throw new NotImplementedException();
        }
    }
}
