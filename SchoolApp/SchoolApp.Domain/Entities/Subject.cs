using System;

namespace SchoolApp.Domain.Entities
{
    public class Subject : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}