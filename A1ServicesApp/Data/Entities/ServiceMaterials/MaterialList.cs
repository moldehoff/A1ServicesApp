﻿using A1ServicesApp.Features.JobMaterials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceMaterials
{
    public class MaterialList
    {
        public int Id { get; set; }
        public string Type { get; set; } // "All" Materials Requuired or "Any" Material Required 
        public string Name { get; set; }
        public ICollection<JobMaterial> Materials { get; set; } = new List<JobMaterial>();

    }
}