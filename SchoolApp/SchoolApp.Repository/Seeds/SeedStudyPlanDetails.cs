using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public static class SeedStudyPlanDetails
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.StudyPlanDetails.Any(x => x.id == entity.id)) continue;

                context.StudyPlanDetails.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<StudyPlanDetailDto> GetEntities()
        {
            var entities = new List<StudyPlanDetailDto>();
            entities.Add(new StudyPlanDetailDto()
            {
                id = Guid.Parse("b14f2842-8a71-4719-bae8-4c7ad55e0314"),
                name = "Matemáticas 2019",
                subjectId = Guid.Parse("407a1a0e-d864-4abf-a996-08272b743495"),
                studyPlanId = Guid.Parse("896346aa-a578-4cea-9ea6-b1c143dca929")
            });
            entities.Add(new StudyPlanDetailDto()
            {
                id = Guid.Parse("369e531a-c834-4417-8502-909abfd83d3d"),
                name = "Historia 2019",
                subjectId = Guid.Parse("30c810ee-12b8-4469-b70e-484a6bd8f7c0"),
                studyPlanId = Guid.Parse("896346aa-a578-4cea-9ea6-b1c143dca929")
            });
            entities.Add(new StudyPlanDetailDto()
            {
                id = Guid.Parse("86a05539-c2bb-4f8c-aa0a-4cac4c80e632"),
                name = "Lengua y Literatura 2019",
                subjectId = Guid.Parse("89563e7e-ff50-49f1-bb05-9a37cc6c8d9c"),
                studyPlanId = Guid.Parse("896346aa-a578-4cea-9ea6-b1c143dca929")
            });
            
            entities.Add(new StudyPlanDetailDto()
            {
                id = Guid.Parse("a19fcfa1-6cee-41c2-8ef1-f9f20deebd5a"),
                name = "Ciencias Biológicas 2019",
                subjectId = Guid.Parse("3376aacf-3a10-443c-93fb-16bc01e54238"),
                studyPlanId = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0")
            });
            entities.Add(new StudyPlanDetailDto()
            {
                id = Guid.Parse("24b507e4-4c63-4bc7-a83f-b69707a62e58"),
                name = "Ciencias Sociales 2019",
                subjectId = Guid.Parse("e1585fbc-6092-4ffb-905e-1f5996783a49"),
                studyPlanId = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0")
            });
            entities.Add(new StudyPlanDetailDto()
            {
                id = Guid.Parse("246096a8-ef9d-4b6d-a025-60158220389c"),
                name = "Lengua y Literatura 2019",
                subjectId = Guid.Parse("89563e7e-ff50-49f1-bb05-9a37cc6c8d9c"),
                studyPlanId = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0")
            });

            return entities;
        }
    }
}