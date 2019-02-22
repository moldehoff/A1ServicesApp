using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Specifications
{
    public interface ISpecificationRule<T>
    {
        int Id { get; set; }
        string Name { get; set; }
        Specification<T> Specification { get; set; }

        [JsonIgnore]
        string JsonSpecification { get; set; }
        
    }
}
