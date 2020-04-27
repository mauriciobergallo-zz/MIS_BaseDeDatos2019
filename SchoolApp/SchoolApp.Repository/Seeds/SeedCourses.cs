using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public class SeedCourses
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.Courses.Any(x => x.id == entity.id)) continue;

                context.Courses.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<CourseDto> GetEntities()
        {
            var entities = new List<CourseDto>()
            {
                new CourseDto()
                {
                    id = Guid.Parse("2fa3fee3-1cc0-41be-b42f-7f3ee2fda059"),
                    headerTeacherId = Guid.Parse("b7a29c1e-fc04-44ae-b43e-d4bbb8d360b6"),
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea"),
                    subjectId = Guid.Parse("407a1a0e-d864-4abf-a996-08272b743495")
                },
                new CourseDto()
                {
                    id = Guid.Parse("e593cdfa-dc84-45c9-bf51-5768b2d579c5"),
                    headerTeacherId = Guid.Parse("f20ab41c-79d4-438b-a3ff-4031372c80af"),
                    schoolId = Guid.Parse("eae2acee-5b9c-4f4b-a477-8668fee43fea"),
                    subjectId = Guid.Parse("407a1a0e-d864-4abf-a996-08272b743495")
                }
            };

            return entities;
        }
    }
}