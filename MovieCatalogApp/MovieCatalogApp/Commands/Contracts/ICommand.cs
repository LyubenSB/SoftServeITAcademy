using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Commands.Contracts
{
    public interface ICommand
    {
        void CollectData();
        string Execute();
    }
}
