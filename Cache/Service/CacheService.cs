using Cache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Service
{
    public class CacheService : ICacheService
    {
        private readonly Dictionary<string, CacheResultModel> _cacheResults = new Dictionary<string, CacheResultModel>();
        public void AddToCache(string key, IEnumerable<object> values)
        {
            if (!_cacheResults.ContainsKey(key))
            {
                _cacheResults.Add(
                    key,
                    MapResult(values, DateTime.Now.AddSeconds(1)));
            }
            else
            {
                _cacheResults.Remove(key);
                _cacheResults.Add(
                    key,
                    MapResult(values, DateTime.Now.AddSeconds(1)));
            }
        }

        public CacheResultModel RetrieveFromCache(string key)
        {
            if (_cacheResults.ContainsKey(key) && _cacheResults[key].ExpirationDate > DateTime.Now)
            {
                return _cacheResults[key];
            }
            return null;
        }

        public void DeleteFromCache(string key)
        {
            if (_cacheResults[key].ExpirationDate < DateTime.Now)
            {
                _cacheResults.Remove(key);
            }
        }

        private CacheResultModel MapResult(IEnumerable<object> values, DateTime expirationDate)
        {
            return new CacheResultModel
            {
                ExpirationDate = expirationDate,
                Values = values
            };
        }
    }
}
