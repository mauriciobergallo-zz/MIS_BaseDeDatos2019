using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public static class SeedStudents
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.Students.Any(x => x.id == entity.id)) continue;

                context.Students.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<StudentDto> GetEntities()
        {
            var entities = new List<StudentDto>()
            {
                new StudentDto()
                {
                    id = Guid.Parse("6a5cae68-37d7-4655-a78d-1a83148ed449"),
                    firstName = "Nellie",
                    lastName = "Frazier",
                    identificationNumber = "91740628",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new StudentDto()
                {
                    id = Guid.Parse("61cf95bf-1b7d-46c0-99f4-185bcd363ec9"),
                    firstName = "Judy",
                    lastName = "Johnson",
                    identificationNumber = "33861308",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new StudentDto()
                {
                    id = Guid.Parse("a64836c8-2082-4bc4-9330-8e42936707fc"),
                    firstName = "Floyd",
                    lastName = "Newman",
                    identificationNumber = "90297891",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new StudentDto()
                {
                    id = Guid.Parse("935c167d-bbcd-4017-90d9-0fbb156d6c40"),
                    firstName = "Edith",
                    lastName = "Graves",
                    identificationNumber = "84659613",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new StudentDto()
                {
                    id = Guid.Parse("35db12a5-2d41-4c3b-8f48-4360951b2d73"),
                    firstName = "Luke",
                    lastName = "Vargas",
                    identificationNumber = "86644586",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
            };

            return entities;
        }
    }
}