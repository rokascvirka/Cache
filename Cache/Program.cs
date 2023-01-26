using Cache.Models;
using Cache.Service;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Cache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _cacheServise = new CacheService();
            var cities = new List<object>() { "Vilnius", "Kaunas", "Jonava"};

            _cacheServise.AddToCache("cities", cities);
            var results = _cacheServise.RetrieveFromCache("cities");
            WriteRes(results);
            Thread.Sleep(TimeSpan.FromSeconds(4));
            _cacheServise.DeleteFromCache("cities");
            var res = _cacheServise.RetrieveFromCache("cities");


            Console.WriteLine("Your still here wow");
            WriteRes(res);
        }

        public static void WriteRes(CacheResultModel results)
        {
            if(results == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                foreach (var c in results.Values)
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
