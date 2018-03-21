using MovieCatalogApp.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Core.Providers
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;

        public Engine(IWriter writer)
        {
            this.writer = writer;
        }

        public void Start()
        {
            string startScreen = @"███╗   ███╗ ██████╗ ██╗   ██╗██╗███████╗     ██████╗ █████╗ ████████╗ █████╗ ██╗      ██████╗  ██████╗ 
████╗ ████║██╔═══██╗██║   ██║██║██╔════╝    ██╔════╝██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔═══██╗██╔════╝ 
██╔████╔██║██║   ██║██║   ██║██║█████╗      ██║     ███████║   ██║   ███████║██║     ██║   ██║██║  ███╗
██║╚██╔╝██║██║   ██║╚██╗ ██╔╝██║██╔══╝      ██║     ██╔══██║   ██║   ██╔══██║██║     ██║   ██║██║   ██║
██║ ╚═╝ ██║╚██████╔╝ ╚████╔╝ ██║███████╗    ╚██████╗██║  ██║   ██║   ██║  ██║███████╗╚██████╔╝╚██████╔╝
╚═╝     ╚═╝ ╚═════╝   ╚═══╝  ╚═╝╚══════╝     ╚═════╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝ ╚═════╝  ╚═════╝ 
                                                                                                       ";


            writer.WriteLine(startScreen);
        }
    }
}
