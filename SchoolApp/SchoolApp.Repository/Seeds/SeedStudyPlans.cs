using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public static class SeedStudyPlans
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.StudyPlans.Any(x => x.id == entity.id)) continue;

                context.StudyPlans.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<StudyPlanDto> GetEntities()
        {
            var entities = new List<StudyPlanDto>();
            entities.Add(new StudyPlanDto()
            {
                id = Guid.Parse("896346aa-a578-4cea-9ea6-b1c143dca929"),
                name = "Plan I 2019",
                year = 2019,
                schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
            });
            entities.Add(new StudyPlanDto()
            {
                id = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0"),
                name = "Plan II 2019",
                year = 2019,
                schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
            });

            return entities;
        }
    }
}