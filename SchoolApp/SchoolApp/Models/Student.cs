using System;

namespace SchoolApp.Models
{
    public class Student : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
    }
}