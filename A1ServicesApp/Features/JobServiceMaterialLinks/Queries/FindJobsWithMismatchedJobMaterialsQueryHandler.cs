using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.JobMaterials.Models;
using A1ServicesApp.Features.JobServiceMaterialLinks.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Queries
{
    public class FindJobsWithMismatchedJobMaterialsQueryHandler : IRequestHandler<FindJobsWithMismatchedJobMaterialsQuery, List<FlaggedJobServiceMaterialsDto>>
    {
        private IMapper _mapper;
        private A1ServicesAppDbContext _ctx;

        public FindJobsWithMismatchedJobMaterialsQueryHandler(IMapper mapper, A1ServicesAppDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public Task<List<FlaggedJobServiceMaterialsDto>> Handle(FindJobsWithMismatchedJobMaterialsQuery request, CancellationToken cancellationToken)
        {
            var jobMissingMaterials = new List<ServiceTitanJobModel>();
            var result = new List<FlaggedJobServiceMaterialsDto>();

            var jobServiceMaterialLinks = _ctx.JobServiceMaterialLinks.Include(j=>j.MaterialLists).ThenInclude(list => list.MaterialListItems).ThenInclude(i => i.JobMaterial).ToList();
            var jobs = request.Jobs;


            foreach (var job in jobs)
            {
                var invoiceItems = job.Invoice.Items.Where(i => i.Active == true).ToList();
                var serviceInvoiceItems = invoiceItems.Where(s => s.Sku.Type == "Service").ToList();
                var materialInvoiceItems = invoiceItems.Where(s => s.Sku.Type == "Material").ToList();

                foreach (var item in serviceInvoiceItems)
                {

                    var link = _ctx.JobServiceMaterialLinks.Include(j => j.MaterialLists).ThenInclude(ml => ml.MaterialListItems).ThenInclude(i=>i.JobMaterial).Where(l => l.ServiceId == item.Sku.Id).FirstOrDefault();

                    if (link != null)
                    {
                        foreach (var ml in link.MaterialLists)
                        {
                            var mlItems = ml.MaterialListItems;
                            if (ml.Type == "Any" && (!materialInvoiceItems.Any(m => mlItems.Any(i => i.JobMaterial.MaterialId == m.Sku.Id))))
                            {
                                result.Add(new FlaggedJobServiceMaterialsDto()
                                {
                                    FlaggedJob = job,
                                    FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),
                                    FlaggedMaterialList = ml
                                });
                                link = null;
                                goto outer_loop;
                            }
                            else if (ml.Type == "All" && !mlItems.Any(m => materialInvoiceItems.Any(mio => mio.Sku.Id == m.JobMaterial.MaterialId)))
                            {
                                result.Add(new FlaggedJobServiceMaterialsDto()
                                {
                                    FlaggedJob = job,
                                    FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),
                                    FlaggedMaterialList = ml
                                });
                                link = null;
                                goto outer_loop;
                            }
                        }


                    }
                    link = null;
                }
                outer_loop:;
                
            }


            return Task.FromResult<List<FlaggedJobServiceMaterialsDto>>(result);
        }
    }
}
