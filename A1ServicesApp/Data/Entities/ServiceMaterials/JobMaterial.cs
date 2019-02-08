using A1ServicesApp.Data.Entities.ServiceMaterials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Models
{
    public class JobMaterial
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Cost { get; set; }
        public int Active { get; set; }

        public ICollection<MaterialListItem> MaterialListItems { get; set; } = new List<MaterialListItem>();


        public JobMaterial(JobMaterial model)
        {
            MaterialId = model.MaterialId;
            Code = model.Code;
            Name = model.Name;
            Description = model.Description;
            CategoryId = model.CategoryId;
            CategoryName = model.CategoryName;
            Cost = model.Cost;
            Active = model.Active;
            Id = model.Id;
        }

        public JobMaterial()
        {

        }
    }
}
