using Cache.Models;
using System;
using System.Collections.Generic;

namespace Cache.Service
{
    public interface ICacheService
    {
        void AddToCache(string key, IEnumerable<object> values);
        void DeleteFromCache(string key);
        CacheResultModel RetrieveFromCache(string key);
    }
}