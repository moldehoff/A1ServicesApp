using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Features.JobMaterials.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A1ServicesApp.Data
{
    public static class A1ServicesAppDbContextExtensions
    {

        public static void EnsureSeedData(this A1ServicesAppDbContext ctx)
        {
            var jobMaterialLinks = ProcessServiceMaterialsLinkFile("D:\\Projects\\A1ServicesApp\\A1ServicesApp\\Features\\JobServiceMaterialLinks\\ServiceMaterialsLinks.csv");
            var servicesList = ProcessServicesFile("D:\\Projects\\A1ServicesApp\\A1ServicesApp\\Features\\JobServiceMaterialLinks\\ServicesBook.csv");
            var materialsList = ProcessMaterialsFile("D:\\Projects\\A1ServicesApp\\A1ServicesApp\\Features\\JobServiceMaterialLinks\\MaterialsBook.csv");

            var jobServiceMaterialLinks = new List<JobServiceMaterialLink>();

            if (ctx.JobServiceMaterialLinks.Any())
            {
                return;
            }

            ctx.JobMaterials.AddRange(materialsList);
            ctx.JobServices.AddRange(servicesList);
            ctx.SaveChanges();

            var jobMaterialLinksGroups = jobMaterialLinks.GroupBy(j => j.ServiceId).ToList();



            foreach (var link in jobMaterialLinksGroups)
            {
                var service = ctx.JobServices.Where(s => s.ServiceId == link.Key).FirstOrDefault();

                var newJobServiceMaterialLink = new JobServiceMaterialLink()
                {
                    ServiceId = service.ServiceId,
                    ServiceCode = service.Code,
                    Active = 1,
                    MaterialLists = new List<MaterialList>()
                };

                foreach (var matList in link)
                {     
                    var newMaterialList = new MaterialList()
                    {
                        Type = "All",
                        Name = matList.MaterialCode + " - " + link.Key + " - " + "Links"
                    };

                    var material = ctx.JobMaterials.Where(j => j.MaterialId == matList.MaterialId).FirstOrDefault();
                    var materialListItem = new MaterialListItem()
                    {
                        JobMaterialId = material.MaterialId,
                        JobMaterial = material
                    };
                    newMaterialList.MaterialListItems.Add(materialListItem);

                    newJobServiceMaterialLink.MaterialLists.Add(newMaterialList);
                }

                jobServiceMaterialLinks.Add(newJobServiceMaterialLink);
            }

            ctx.JobServiceMaterialLinks.AddRange(jobServiceMaterialLinks);
            ctx.SaveChanges();
        }

        private static List<JobMaterial> ProcessMaterialsFile(string path)
        {
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line => TransformToMaterial(line))
                .ToList();

            return result;
        }

        private static JobMaterial TransformToMaterial(string line)
        {
            var columns = line.Split(',');

            int parsedCatId;
            int.TryParse(columns[0], out parsedCatId);

            return new JobMaterial
            {
                //CategoryId = Convert.ToInt32(columns[0]),
                //CategoryName = columns[1],
                MaterialId = Convert.ToInt32(columns[0]),
                Code = columns[1],
                Name = columns[2],
                Description = columns[3],
                Cost = Convert.ToDouble(columns[4]),
                Active = Convert.ToInt32(columns[5])
            };
        }

        private static List<JobService> ProcessServicesFile(string path)
        {
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line => TransformToService(line))
                .ToList();

            return result;
        }

        private static JobService TransformToService(string line)
        {
            var columns = line.Split(',');
            //int parsedCatId;
            //int.TryParse(columns[0], out parsedCatId);

            return new JobService
            {
                //CategoryId = parsedCatId,
                //CategoryName = columns[1],
                ServiceId = Convert.ToInt32(columns[0]),
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

        private static List<ServiceMaterialsLinksDto> ProcessServiceMaterialsLinkFile(string path)
        {

            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line => TransformToServiceMaterialsLink(line))
                .ToList();

            return result;
        }

        private static ServiceMaterialsLinksDto TransformToServiceMaterialsLink(string line)
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
