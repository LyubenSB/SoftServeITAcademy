using LMDB.WebServices;
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
            HttpClientProvider cltpr = new HttpClientProvider();
            var msg = cltpr.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=81e01557d5026a137a95543112911069&query=terminator");

            //var msg = cltpr.GetAsync("https://www.google.com");
            
            Console.WriteLine(msg.Result);
        }
    }
}
