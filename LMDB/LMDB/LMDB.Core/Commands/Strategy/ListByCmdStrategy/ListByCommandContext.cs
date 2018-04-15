using LMDB.Commands.Contracts.Strategy;
using LMDB.Commands.Strategy.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.Commands.Strategy.ListByCmdStrategy
{
    public class ListByCommandContext : IContext
    {
        private IStrategy strategy;

        public ListByCommandContext(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextExecute()
        {
            strategy.ExectuteStrategy();
        }
    }
}
