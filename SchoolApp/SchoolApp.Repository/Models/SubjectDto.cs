using System;

namespace SchoolApp.Repository.Models
{
    public class SubjectDto : IEntityDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}