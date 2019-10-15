using System;

namespace SchoolApp.Models
{
    public class Subject : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}