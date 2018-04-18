using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.Strategies;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices
{
    public class PrintingContext 
    {
        private LocalApiStrategyContainer strContainer;

        public PrintingContext(LocalApiStrategyContainer strContainer)
        {
            this.strContainer = strContainer;
        }

        public void ContextExecute(string context, ICollection<IMotionPictureData> collectionToPrint)
        {
            strContainer.LocalApiStrategies[context].ExectuteStrategy(context, collectionToPrint);
        }

    }
}
