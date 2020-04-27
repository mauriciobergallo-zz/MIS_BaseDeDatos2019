using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public static class SeedTeachers
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.Teachers.Any(x => x.id == entity.id)) continue;

                context.Teachers.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<TeacherDto> GetEntities()
        {
            var entities = new List<TeacherDto>()
            {
                new TeacherDto()
                {
                    id = Guid.Parse("b7a29c1e-fc04-44ae-b43e-d4bbb8d360b6"),
                    firstName = "Rick",
                    lastName = "Riviera",
                    identificationNumber = "58951828",
                    teacherIdentification = "1828",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new TeacherDto()
                {
                    id = Guid.Parse("f20ab41c-79d4-438b-a3ff-4031372c80af"),
                    firstName = "Leroy",
                    lastName = "Jimenez",
                    identificationNumber = "88346538",
                    teacherIdentification = "6538",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new TeacherDto()
                {
                    id = Guid.Parse("a17a2f0e-e806-482d-873e-77b55975fbe4"),
                    firstName = "Ruben",
                    lastName = "Henderson",
                    identificationNumber = "25468761",
                    teacherIdentification = "8761",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new TeacherDto()
                {
                    id = Guid.Parse("87320233-3838-4ad8-bcab-031b6094ec6b"),
                    firstName = "Paul",
                    lastName = "Ellis",
                    identificationNumber = "50607552",
                    teacherIdentification = "7552",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                },
                new TeacherDto()
                {
                    id = Guid.Parse("c8bf73a7-c6cd-4726-846b-bdfd401491f8"),
                    firstName = "Jill",
                    lastName = "Marshall",
                    identificationNumber = "71100584",
                    teacherIdentification = "0584",
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea")
                }
            };

            return entities;
        }
    }
}