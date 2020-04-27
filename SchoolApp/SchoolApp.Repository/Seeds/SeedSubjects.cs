using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public static class SeedSubjects
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.Subjects.Any(x => x.id == entity.id)) continue;

                context.Subjects.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<SubjectDto> GetEntities()
        {
            var entities = new List<SubjectDto>()
            {
                new SubjectDto()
                {
                    id = Guid.Parse("407a1a0e-d864-4abf-a996-08272b743495"),
                    name = "Matemáticas"
                },
                new SubjectDto()
                {
                    id = Guid.Parse("30c810ee-12b8-4469-b70e-484a6bd8f7c0"),
                    name = "Historia"
                },
                new SubjectDto()
                {
                    id = Guid.Parse("3376aacf-3a10-443c-93fb-16bc01e54238"),
                    name = "Ciencias Biológicas"
                },
                new SubjectDto()
                {
                    id = Guid.Parse("e1585fbc-6092-4ffb-905e-1f5996783a49"),
                    name = "Ciencias Sociales"
                },
                new SubjectDto()
                {
                    id = Guid.Parse("89563e7e-ff50-49f1-bb05-9a37cc6c8d9c"),
                    name = "Lengua y Literatura"
                },
            };

            return entities;
        }
    }
}