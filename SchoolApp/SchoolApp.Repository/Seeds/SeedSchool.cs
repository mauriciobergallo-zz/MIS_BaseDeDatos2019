using System;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public static class SeedSchool
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entity = new SchoolDto()
            {
                id = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea"),
                name = "Seeded School, For Testing"
            };
            
            if (context.Schools.Any(x => x.id == entity.id)) return;
            context.Schools.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}