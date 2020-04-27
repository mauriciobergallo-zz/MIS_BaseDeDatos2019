using System;
using System.Collections.Generic;

namespace SchoolApp.Repository.Models
{
    public class SchoolDto : IEntityDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}