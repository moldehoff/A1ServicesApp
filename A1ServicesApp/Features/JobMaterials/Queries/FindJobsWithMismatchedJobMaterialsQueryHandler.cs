using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.JobMaterials.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Queries
{
    public class FindJobsWithMismatchedJobMaterialsQueryHandler : IRequestHandler<FindJobsWithMismatchedJobMaterialsQuery, JobsListDto>
    {

        public Task<JobsListDto> Handle(FindJobsWithMismatchedJobMaterialsQuery request, CancellationToken cancellationToken)
        {
            var result = new JobsListDto();
            var jobMaterialLinks = ProcessServiceMaterialsLinkFile("D:\\Projects\\A1ServicesApp\\A1ServicesApp\\Features\\JobMaterials\\ServiceMaterialsLinks.csv");
            var servicesList = ProcessServicesFile("D:\\Projects\\A1ServicesApp\\A1ServicesApp\\Features\\JobMaterials\\ServicesBook.csv");
            var materialsList = ProcessMaterialsFile("D:\\Projects\\A1ServicesApp\\A1ServicesApp\\Features\\JobMaterials\\MaterialsBook.csv");


            var jobMissingMaterials = new List<ServiceTitanJobModel>();
            var flaggedItems = new List<ServiceTitanInvoiceItemModel>();
            var flaggedLinks = new List<ServiceMaterialsLinksDto>();
            var flaggedTorsionLinks = new List<ServiceToManyMaterialLinkModel>();

            var TOLinks = CreateTorsionOverhaulLinks(servicesList, materialsList);




            foreach (var job in request.Jobs)
            {
                var invoiceItems = job.Invoice.Items.Where(i => i.Active == true).ToList();
                var serviceInvoiceItems = invoiceItems.Where(s => s.Sku.Type == "Service").ToList();
                var materialInvoiceItems = invoiceItems.Where(s => s.Sku.Type == "Material").ToList();

                

                foreach (var item in serviceInvoiceItems)
                {
                    
                    var link = jobMaterialLinks.Where(j => j.ServiceId == item.Sku.Id).FirstOrDefault();
                    var torsionLinks = TOLinks.Where(t => t.ServiceId == item.Sku.Id).ToList();

                    if (link != null && !materialInvoiceItems.Any(m => m.Sku.Id == link.MaterialId))
                    {
                        flaggedItems.Add(item);
                        flaggedLinks.Add(link);
                        jobMissingMaterials.Add(job);
                        goto outer_loop;
                    }
                    else if (torsionLinks.Any(tl => tl.ServiceId == item.Sku.Id))
                    {
                        foreach (var tl in torsionLinks)
                        {
                            var tlItems = tl.Materials;

                            if (!materialInvoiceItems.Any(m => tlItems.Any(i => i.Id == m.Sku.Id )))
                            {
                                flaggedItems.Add(item);
                                flaggedTorsionLinks.Add(tl);
                                jobMissingMaterials.Add(job);
                                goto outer_loop;
                            }
                        }

                        
                    }
                    link = null;
                    torsionLinks = null;
                }

                outer_loop:;


            }

            result.Jobs = jobMissingMaterials;


            return Task.FromResult<JobsListDto>(result);
        }

        private List<ServiceToManyMaterialLinkModel> CreateTorsionOverhaulLinks(List<JobService> servicesList, List<JobMaterial> materialsList)
        {
            var maxLifeSprings = materialsList.Where(m => m.Code.StartsWith("STM"));
            var highCycleSprings = materialsList.Where(m => m.Code.StartsWith("STH"));
            var lowCycleSprings = materialsList.Where(m => m.Code.StartsWith("STL"));
            var endPlate = materialsList.Where(m => m.Id == 1730064).ToList();
            var centerBearing = materialsList.Where(m => m.Code.ToLower().StartsWith("ha-center") || m.Code.ToLower().StartsWith("ha-ext")).ToList();

            var result = new List<ServiceToManyMaterialLinkModel>()
            {
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1752495,
                    ServiceCode = "1CLife Torsion Conversion",
                    Materials = maxLifeSprings.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1752765,
                    ServiceCode = "2CLife Torsion Conversion",
                    Materials = maxLifeSprings.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1743772,
                    ServiceCode = "ML Overhaul Single Door",
                    Materials = maxLifeSprings.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1744029,
                    ServiceCode = "ML Overhaul Double Door",
                    Materials = maxLifeSprings.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1752495,
                    ServiceCode = "1CLife Torsion Conversion",
                    Materials = endPlate.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1752765,
                    ServiceCode = "2CLife Torsion Conversion",
                    Materials = endPlate.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1743772,
                    ServiceCode = "ML Overhaul Single Door",
                    Materials = endPlate.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1744029,
                    ServiceCode = "ML Overhaul Double Door",
                    Materials = endPlate.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1752495,
                    ServiceCode = "1CLife Torsion Conversion",
                    Materials = centerBearing.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1752765,
                    ServiceCode = "2CLife Torsion Conversion",
                    Materials = centerBearing.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1743772,
                    ServiceCode = "ML Overhaul Single Door",
                    Materials = centerBearing.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1744029,
                    ServiceCode = "ML Overhaul Double Door",
                    Materials = centerBearing.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1743771,
                    ServiceCode = "1C Max Life",
                    Materials = maxLifeSprings.ToList()
                },
                new ServiceToManyMaterialLinkModel
                {
                    ServiceId = 1743649,
                    ServiceCode = "2C Max Life",
                    Materials = maxLifeSprings.ToList()
                }
            };

            return result;
        }

        private List<JobMaterial> ProcessMaterialsFile(string path)
        {
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line => TransformToMaterial(line))
                .ToList();

            return result;
        }

        private JobMaterial TransformToMaterial(string line)
        {
            var columns = line.Split(',');

            int parsedCatId;
            int.TryParse(columns[0], out parsedCatId);

            return new JobMaterial
            {
                //CategoryId = Convert.ToInt32(columns[0]),
                //CategoryName = columns[1],
                Id = Convert.ToInt32(columns[0]),
                Code = columns[1],
                Name = columns[2],
                Description = columns[3],
                Cost = Convert.ToDouble(columns[4]),
                Active = Convert.ToInt32(columns[5])
            };
        }

        private List<JobService> ProcessServicesFile(string path)
        {
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line => TransformToService(line))
                .ToList();

            return result;
        }

        private JobService TransformToService(string line)
        {
            var columns = line.Split(',');
            //int parsedCatId;
            //int.TryParse(columns[0], out parsedCatId);

            return new JobService
            {
                //CategoryId = parsedCatId,
                //CategoryName = columns[1],
                Id = Convert.ToInt32(columns[0]),
                Code = columns[1],
                Name = columns[2],
                Description = columns[3],
                Price = Convert.ToDouble(columns[4]),
                MemberPrice = Convert.ToDouble(columns[5]),
                AddOnPrice = Convert.ToDouble(columns[6]),
                AddOnMemberPrice = Convert.ToDouble(columns[7]),
                Active = Convert.ToInt32(columns[8])
            };
        }

        private List<ServiceMaterialsLinksDto> ProcessServiceMaterialsLinkFile(string path)
        {

            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line => TransformToServiceMaterialsLink(line))
                .ToList();

            return result;
        }

        private ServiceMaterialsLinksDto TransformToServiceMaterialsLink(string line)
        {
            var columns = line.Split(',');
            
            return new ServiceMaterialsLinksDto
            {
                ServiceId = Convert.ToInt32(columns[0]),
                ServiceCode = columns[1],
                MaterialId = Convert.ToInt32(columns[2]),
                MaterialCode = columns[3],
                Quantity = Convert.ToInt32(columns[4]),
                Active = Convert.ToInt32(columns[5])
            };
        }

        
    }
}
