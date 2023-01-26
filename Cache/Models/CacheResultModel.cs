using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Models
{
    public class CacheResultModel
    {
        public IEnumerable<object> Values { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
