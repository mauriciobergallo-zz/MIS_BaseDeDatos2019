using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class StudentDto : IEntityDto
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string identificationNumber { get; set; }
        [ForeignKey("schoolId")]
        public Guid schoolId { get; set; }
    }
}