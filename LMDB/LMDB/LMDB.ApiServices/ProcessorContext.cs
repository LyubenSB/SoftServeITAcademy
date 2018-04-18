using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class ProcessorContext : ICallProcessorContext
    {
        private WebApiStrategyContainer strContainer;

        public ProcessorContext(WebApiStrategyContainer strContainer)
        {
            this.strContainer = strContainer;
            this.Parameters = new List<string>();
        }

        public string Context { get; private set; }
        public List<string> Parameters { get; private set; }

        public void AddParameter(string parameter)
        {
            this.Parameters.Add(parameter);
        }

        public void ContextExecute(string context)
        {
            string executeParameter = Parameters[0];
            strContainer.WebApiStrategies[context].ExectuteStrategy(executeParameter);
        }

    }
}
