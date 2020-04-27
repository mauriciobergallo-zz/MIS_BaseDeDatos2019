using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "studyPlanRequest")]
    public class StudyPlanPostRequestDto
    {
        [DataMember(Name = "id", IsRequired = false)]
        public Guid Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
    }
}