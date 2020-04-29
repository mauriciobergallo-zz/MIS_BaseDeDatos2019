using System.Linq;
using AutoMapper;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Controllers.DTO.Mappers
{
    public class EntitiesToWebDtos : Profile
    {
        public EntitiesToWebDtos()
        {
            CreateMap<Course, CourseGetResponseDto>()
                .ForMember(dest => dest.Subject,
                    cfg => cfg.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.Teacher,
                    cfg => cfg.MapFrom(src => $"{src.HeadTeacher.FirstName} {src.HeadTeacher.LastName}"))
                .ForMember(dest => dest.StudentsEnrolled,
                    cfg => cfg.MapFrom(src => src.StudentsEnrolled.ToList().Count))
                ;

            CreateMap<StudyPlanDetail, StudyPlanDetailGetResponseDto>()
                .ForMember(cfg => cfg.Subject,
                    cfg => cfg.MapFrom(src => src.Subject.Name))
                ;
            
            CreateMap<StudyPlanPostRequestDto, StudyPlan>()
                .ForMember(dest => dest.Id, 
                    cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, 
                    cfg => cfg.MapFrom(src => src.Name))
                .ForMember(dest => dest.Year, 
                    cfg => cfg.MapFrom(src => src.Year))
                ;

            CreateMap<Enrollment, EnrollmentGetResponseDto>()
                .ForMember(dest => dest.Student, 
                    cfg => cfg.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
                .ForMember(dest => dest.StudyPlan, 
                    cfg => cfg.MapFrom(src => src.StudyPlan.Name))
                ;

            CreateMap<StudentEnrolledInCourse, CourseEnrollmentGetResponseDto>()
                .ForMember(dest => dest.Id, 
                    cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentId, 
                    cfg => cfg.MapFrom(src => src.Enrollment.Student.Id))
                .ForMember(dest => dest.StudentName, 
                    cfg => cfg.MapFrom(src => $"{src.Enrollment.Student.FirstName} {src.Enrollment.Student.LastName}"))
                .ForMember(dest => dest.EnrollmentId, 
                    cfg => cfg.MapFrom(src => src.Enrollment.Id))
                ;

            CreateMap<StudentEnrolledInCourse, StudentEnrolledInCourseGetResponseDto>()
                .ForMember(dest => dest.Course,
                    cfg => cfg.MapFrom(src => src.Course))
                ;
        }
    }
}