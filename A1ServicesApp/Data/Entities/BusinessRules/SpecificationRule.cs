using A1ServicesApp.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.BusinessRules
{
    public class SpecificationRule : ISpecificationRule<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Specification<T> Specification { get; set; }

        [JsonIgnore]
        public string JsonSpecification
        {
            get { return JsonConvert.SerializeObject(Specification); }
            set { Specification = JsonConvert.DeserializeObject<Specification<T>>(value); }
        }
    }
}
