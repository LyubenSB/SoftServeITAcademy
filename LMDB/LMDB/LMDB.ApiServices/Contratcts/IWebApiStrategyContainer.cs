using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Contratcts
{
    public interface IWebApiStrategyContainer
    {
        Dictionary<string, ICallProcessorStrategy<string>> WebApiStrategies { get; }
    }
}
