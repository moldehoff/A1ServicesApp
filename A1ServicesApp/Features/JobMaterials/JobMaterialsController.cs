﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials
{
    [Route("api/[controller]")]
    public class JobMaterialsController : Controller
    {
        public JobMaterialsController(IMediator mediator)
        {

        }


    }
}
