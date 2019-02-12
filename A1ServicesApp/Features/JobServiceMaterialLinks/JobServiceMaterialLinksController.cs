using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using A1ServicesApp.Features.JobMaterials.Models;
using A1ServicesApp.Features.JobMaterials.Queries;
using A1ServicesApp.Features.Jobs.Models;
using A1ServicesApp.Features.Jobs.Queries;
using A1ServicesApp.Features.JobServiceMaterialLinks.Commands;
using A1ServicesApp.Features.JobServiceMaterialLinks.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks
{
    [Route("api/[controller]")]
    public class JobServiceMaterialLinksController : Controller
    {
        private IMediator _mediator;

        public JobServiceMaterialLinksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllJobMaterialLinks()
        {
            var result = _mediator.Send(new GetAllJobMaterialLinksQuery()).Result;


            return Ok(result);
        }

        [HttpGet("{linkId}")]
        public IActionResult GetJobMaterialLinkById(int linkId)
        {
            var result = _mediator.Send(new GetJobServiceMaterialLinkByIdQuery() { Id = linkId }).Result;


            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateNewJobServiceMaterialLink([FromBody] NewJobServiceMaterialLinkDto model)
        {
            var result = _mediator.Send(new CreateNewJobServiceMaterialLinkCommand(model)).Result;

            return Created(result.Id.ToString(), result);
        }

        [HttpGet("findmissinglinks")]
        public IActionResult GetJobsWithMissingJobMaterials()
        {
            var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,0,0,0);

            var queryStringModel = new GetJobsQueryStringModel()
            {
                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",
                CompletedBefore = new FilterCompletedBefore() { FilterValue = todaysDate},
                CompletedAfter = new FilterCompletedAfter() { FilterValue = todaysDate.AddDays(-1)}
            };
   
            var getJobsFromST = _mediator.Send(new GetJobsFromServiceTitanQuery(queryStringModel)).Result;

            var result = _mediator.Send(new FindJobsWithMismatchedJobMaterialsQuery() {Jobs = getJobsFromST.ApiResults }).Result;

            var groupedByItem = result.GroupBy(r => r.FlaggedMaterialCode.Count()).ToList();
            var groups = result.GroupBy(r => r.TechnicianId).ToList();

            var groupedByTechnicianList = new List<TechnicianMissingItemGroupModel>();
            foreach (var g in groups)
            {
                var valueList = g.Select(x => x).ToList();
                groupedByTechnicianList.Add(new TechnicianMissingItemGroupModel
                {
                    TechnicianName = g.Select(x=>x.TechnicianName).FirstOrDefault(),
                    TechnicianId = g.Key,
                    TechFlaggedJobCount = valueList.Count,

                    MaterialId = new List<int>(g.Select(x=>x.FlaggedMaterialId).ToList()),
                    MaterialCode = new List<string>(g.Select(x => x.FlaggedMaterialCode).ToList()),
                    MaterialLinks = new List<FlaggedJobServiceMaterialsDto>(g)
 
                });
            }


            var groupedByMissingItem = new List<MissingItemGroupModel>();


            foreach (var g in groupedByItem)
            {
                var valueList = g.Select(x => x).ToList();
                groupedByMissingItem.Add(new MissingItemGroupModel
                {
                    MaterialId = g.Key,
                    MaterialCode = g.Select(x=>x.FlaggedMaterialCode).FirstOrDefault(),
                    TechnicianId = new List<int>(g.Select(x=>x.TechnicianId)),
                    TechnicianName = new List<string>(g.Select(x=>x.TechnicianName)),
                    MaterialLinks = new List<FlaggedJobServiceMaterialsDto>(g),
                    MissingMaterialCount = valueList.Count
                });
            }

            return Ok(result);
        }
    }
}
