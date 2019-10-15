using System;

namespace SchoolApp.Repositories.DTO
{
    public class StudentDto : IEntityDto
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string identificationNumber { get; set; }
    }
}