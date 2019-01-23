using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanEntityCollectionResult<T> where T : class
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? TotalCount { get; set; }
        public bool HasMore { get; set; }
        public ICollection<T> Data { get; set; } = new List<T>();

    }
}
