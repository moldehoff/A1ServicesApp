using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceMaterials;
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

            var jobServiceMaterialLinks = _ctx.JobServiceMaterialLinks.Include(js => js.MaterialLists).ThenInclude(ml => ml.MaterialListItems).ToList();
            var jobs = request.Jobs;

            foreach (var job in jobs)
            {
                var invoiceItems = job.Invoice.Items.Where(i => i.Active == true).ToList();
                var serviceInvoiceItems = invoiceItems.Where(s => s.Sku.Type == "Service").ToList();
                var materialInvoiceItems = invoiceItems.Where(s => s.Sku.Type == "Material").ToList();

                foreach (var item in serviceInvoiceItems)
                {

                    var link = jobServiceMaterialLinks.Where(l => l.ServiceId == item.Sku.Id).FirstOrDefault();

                    if (link != null)
                    {
                        foreach (MaterialList ml in link.MaterialLists.AsQueryable().Include(l=>l.MaterialListItems).ToList())
                        {
                            var mlItems = ml.MaterialListItems.AsQueryable().Include(i => i.JobMaterial).ToList();

                            if (ml.Type == "Any") //(!materialInvoiceItems.Any(m => mlItems.Any(i => i.MaterialId == m.Sku.Id))))
                            {
                                var anyMatch = false;
                                foreach (var listItem in ml.MaterialListItems.AsQueryable().Include(m=>m.JobMaterial).ToList())  
                                {
                                    if (materialInvoiceItems.Any(m=>m.Sku.Id == listItem.MaterialId))
                                    {
                                        anyMatch = true;
                                    }
                                }

                                if (anyMatch == false)
                                {
                                    var jobAssignment = job.JobAssignments.AsQueryable().Include(j=>j.Technician).Where(j=>j.Active == true).FirstOrDefault();

                                    result.Add(new FlaggedJobServiceMaterialsDto()
                                    {
                                        FlaggedJobId = Convert.ToInt32(job.JobNumber),
                                        FlaggedMaterialCode = ml.Name,
                                        JobCompletedDate = job.CompletedOn,
                                        TechnicianName = jobAssignment.Technician.Name,
                                        TechnicianId = jobAssignment.Technician.Id
                                        //FlaggedJob = job,
                                        //FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),
                                        //FlaggedMaterialList = ml,
                                        //FlaggedMaterialListItem = listItem
                                    });
                                    link = null;
                                    goto outer_loop;
                                }


                                //if (!mlItems.Any(m => materialInvoiceItems.Any(i => i.Sku.Id == m.MaterialId)))
                                //{
                                //    result.Add(new FlaggedJobServiceMaterialsDto()
                                //    {
                                //        FlaggedJob = job,
                                //        FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),
                                //        FlaggedMaterialList = ml
                                //    });
                                //    link = null;
                                //    goto outer_loop;
                                //}

                            }
                            else if (ml.Type == "All") //&& !mlItems.Any(m => materialInvoiceItems.Any(mio => mio.Sku.Id == m.MaterialId)))
                            {
                                foreach (var listItem in ml.MaterialListItems.AsQueryable().Include(m=>m.JobMaterial).ToList())
                                {
                                    if (!materialInvoiceItems.Any(m=>m.Sku.Id == listItem.MaterialId))
                                    {
                                        var jobAssignment = job.JobAssignments.AsQueryable().Include(j => j.Technician).Where(j => j.Active == true).FirstOrDefault();
                                        if (jobAssignment == null)
                                        {
                                            continue;
                                        }
                                        result.Add(new FlaggedJobServiceMaterialsDto()
                                        {
                                            FlaggedJobId = Convert.ToInt32(job.JobNumber),
                                            FlaggedMaterialCode = ml.Name,
                                            JobCompletedDate = job.CompletedOn,
                                            TechnicianName = jobAssignment.Technician.Name,
                                            TechnicianId = jobAssignment.Technician.Id
                                            //FlaggedJob = job,
                                            //FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),
                                            //FlaggedMaterialList = ml,
                                            //FlaggedMaterialListItem = listItem
                                        });
                                        link = null;
                                        goto outer_loop;
                                    }
                                    
                                }
                                
                            }
                        }


                    }
                    link = null;
                }
                outer_loop:;
                
            }

            return Task.FromResult(result.OrderBy(r => r.TechnicianId).ThenBy(r => r.JobCompletedDate).ToList());
        }
    }
}
