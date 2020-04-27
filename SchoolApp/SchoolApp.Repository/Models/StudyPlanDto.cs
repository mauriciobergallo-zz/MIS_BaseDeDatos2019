using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class StudyPlanDto : IEntityDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        
        public virtual IEnumerable<StudyPlanDetailDto> details { get; set; }
        [ForeignKey("schoolId")]
        public Guid schoolId { get; set; }
    }
}