using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public class SeedCourseStudentsEnrolled
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.StudentEnrolledInCourseDto.Any(x => x.id == entity.id)) continue;

                context.StudentEnrolledInCourseDto.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<StudentEnrolledInCourseDto> GetEntities()
        {
            var entities = new List<StudentEnrolledInCourseDto>()
            {
                new StudentEnrolledInCourseDto()
                {
                    id = Guid.Parse("320edcbd-8aed-4a9d-8d49-cd50e4a0a979"),
                    courseId = Guid.Parse("2fa3fee3-1cc0-41be-b42f-7f3ee2fda059"),
                    studentEnrolledId = Guid.Parse("3b5dd087-9da6-4742-b26a-4a64830ee5d5")
                }
            };

            return entities;
        }
    }
}