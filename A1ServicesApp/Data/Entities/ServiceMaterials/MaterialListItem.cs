using A1ServicesApp.Features.JobMaterials.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceMaterials
{
    public class MaterialListItem
    {
        public int Id { get; set; }
        public int? MaterialId { get; set; }


        [ForeignKey("JobMaterialId")]
        public JobMaterial JobMaterial { get; set; }
        public int JobMaterialId { get; set; }
        
        [ForeignKey("MaterialListId")]
        public MaterialList MaterialList { get; set; }
        public int MaterialListId { get; set; }
        


    }
}
