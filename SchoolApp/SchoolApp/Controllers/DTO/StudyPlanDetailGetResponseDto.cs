using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name="studyPlanDetail")]
    public class StudyPlanDetailGetResponseDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "subject")]
        public string Subject { get; set; }
        
    }
}