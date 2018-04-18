using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface ILocalApiStrategyContainer
    {
        Dictionary<string, ILocalProcessorStrategy<string, ICollection<IMotionPictureData>>> LocalApiStrategies { get; }
    }
}
