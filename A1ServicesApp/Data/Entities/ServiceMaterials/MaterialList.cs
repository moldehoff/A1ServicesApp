using A1ServicesApp.Features.JobMaterials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceMaterials
{
    public class MaterialList
    {

        public MaterialList()
        {

        }

        public MaterialList(MaterialList list)
        {
            Id = list.Id;
            Type = list.Type;
            Name = list.Name;
            MaterialListItems = list.MaterialListItems;
        }

        public int Id { get; set; }
        public string Type { get; set; } // "All" Materials Required or "Any" Material Required 
        public string Name { get; set; }

        public ICollection<MaterialListItem> MaterialListItems { get; set; } = new List<MaterialListItem>();



    }
}
