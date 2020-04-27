using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Seeds
{
    public class SeedEnrollments
    {
        public static async Task Seed(ISchoolAppDbContext context)
        {
            var entities = GetEntities();
            foreach (var entity in entities)
            {
                if (context.Enrollments.Any(x => x.id == entity.id)) continue;

                context.Enrollments.Add(entity);
            }

            await context.SaveChangesAsync();
        }

        private static IEnumerable<EnrollmentDto> GetEntities()
        {
            var entities = new List<EnrollmentDto>()
            {
                new EnrollmentDto()
                {
                    id = Guid.Parse("3b5dd087-9da6-4742-b26a-4a64830ee5d5"),
                    studentId = Guid.Parse("6a5cae68-37d7-4655-a78d-1a83148ed449"),
                    studyPlanId = Guid.Parse("896346aa-a578-4cea-9ea6-b1c143dca929")
                },
                new EnrollmentDto()
                {
                    id = Guid.Parse("006ec7c5-1a49-4078-bc7a-949b74ab707c"),
                    studentId = Guid.Parse("a64836c8-2082-4bc4-9330-8e42936707fc"),
                    studyPlanId = Guid.Parse("896346aa-a578-4cea-9ea6-b1c143dca929")
                },
                new EnrollmentDto()
                {
                    id = Guid.Parse("98dd4874-1edf-40df-99b6-3a2ae2ce33ef"),
                    studentId = Guid.Parse("61cf95bf-1b7d-46c0-99f4-185bcd363ec9"),
                    studyPlanId = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0")
                },
                new EnrollmentDto()
                {
                    id = Guid.Parse("604de191-99da-474c-8d81-41c196065307"),
                    studentId = Guid.Parse("935c167d-bbcd-4017-90d9-0fbb156d6c40"),
                    studyPlanId = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0")
                },
                new EnrollmentDto()
                {
                    id = Guid.Parse("aa5955bf-ca1a-43f1-8d62-116c20eb4a31"),
                    studentId = Guid.Parse("35db12a5-2d41-4c3b-8f48-4360951b2d73"),
                    studyPlanId = Guid.Parse("7059821e-3039-4899-a104-bbd8133f97b0")
                }
            };

            return entities;
        }
    }
}