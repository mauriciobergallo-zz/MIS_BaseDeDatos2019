using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name="studyPlan")]
    public class StudyPlanGetResponseDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "name    ")]
        public string Name { get; set; }
        [DataMember(Name = "details")]
        public IEnumerable<StudyPlanDetailGetResponseDto> Details { get; set; }
    }
}