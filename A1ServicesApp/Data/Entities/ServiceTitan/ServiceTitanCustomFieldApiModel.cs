﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanCustomFieldApiModel
    {
        public int? Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
