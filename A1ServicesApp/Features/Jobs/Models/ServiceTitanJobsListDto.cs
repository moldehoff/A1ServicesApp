﻿using A1ServicesApp.Data.Entities.ServiceTitan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Jobs.Models
{
    public class ServiceTitanJobsListDto
    {
        public ICollection<ServiceTitanJobModel> ApiResults { get; set; } = new List<ServiceTitanJobModel>();

    }
}
