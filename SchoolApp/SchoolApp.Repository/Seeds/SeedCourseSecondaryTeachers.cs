using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public class SeedCourseSecondaryTeachers
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.CourseSecondaryTeachers.Any(x => x.id == entity.id)) continue;

                context.CourseSecondaryTeachers.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<CourseSecondaryTeacherDto> GetEntities()
        {
            var entities = new List<CourseSecondaryTeacherDto>()
            {
                new CourseSecondaryTeacherDto()
                {
                    id = Guid.Parse("7c1c801a-c629-477c-a775-84095e23704d"),
                    courseId = Guid.Parse("2fa3fee3-1cc0-41be-b42f-7f3ee2fda059"),
                    secondaryTeacherId = Guid.Parse("a17a2f0e-e806-482d-873e-77b55975fbe4")
                }
            };

            return entities;
        }
    }
}