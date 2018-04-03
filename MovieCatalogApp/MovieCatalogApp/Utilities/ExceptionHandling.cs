using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp.Utilities
{
    public static class ExceptionHandling
    {
        private const string invalidCommand = "Invalid Command.Type '/help' for details";
        public static string InvalidCommand { get; set; }
    }
}
