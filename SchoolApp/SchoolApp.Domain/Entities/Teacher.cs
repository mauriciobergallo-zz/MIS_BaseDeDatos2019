using System;

namespace SchoolApp.Domain.Entities
{
    public class Teacher : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string TeacherIdentification { get; set; }
    }
}