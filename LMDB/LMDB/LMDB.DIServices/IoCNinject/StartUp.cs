using LMDB.ApiServices;
using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.Strategies;
using LMDB.Core.Core.Providers;
using LMDB.DIServices.IoCNinject;
using LMDB.WebServices;
using Newtonsoft.Json.Linq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //initializes a kernal instance/
            IKernel kernel = new StandardKernel(new MovieCatalogModule());

            //loading strategies
            var strLoader = kernel.Get<StrategyLoader>();
            strLoader.LoadStrategies();
            
            //inital data collection
            var dataGetter = kernel.Get<InitialDataGetter>();
            dataGetter.GetData();

            //Starting the application
            var engine = kernel.Get<Engine>();
            engine.DisplayStartScreen();
            engine.Start();
        }
    }
}
