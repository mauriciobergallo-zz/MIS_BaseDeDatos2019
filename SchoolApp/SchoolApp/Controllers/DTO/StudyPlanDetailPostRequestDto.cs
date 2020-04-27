using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "studyPlanDetailRequest")]
    public class StudyPlanDetailPostRequestDto
    {
        [DataMember(Name = "id", IsRequired = false)]
        public Guid Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "subjectId")]
        public Guid SubjectId { get; set; }
    }
}