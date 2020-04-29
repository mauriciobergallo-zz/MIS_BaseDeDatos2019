using System;
using AutoMapper;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Repository.Models.Mappers
{
    public class EntitiesToDto : Profile
    {
        public EntitiesToDto()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.id,
                    cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.schoolId,
                    cfg => cfg.MapFrom(src => src.School.Id))
                .ForMember(dest => dest.subjectId,
                    cfg => cfg.MapFrom(src => src.Subject.Id))
                .ForMember(dest => dest.subject,
                    cfg => cfg.Ignore())
                .ForMember(dest => dest.headerTeacherId,
                    cfg => cfg.MapFrom(src => src.HeadTeacher.Id))
                .ForMember(dest => dest.headerTeacher,
                    cfg => cfg.Ignore())
                ;
            
            CreateMap<CourseDto, Course>()
                .ForMember(dest => dest.Id,
                    cfg => cfg.MapFrom(src => src.id))
                .ForMember(dest => dest.Subject,
                    cfg => cfg.MapFrom(src => src.subject))
                .ForMember(dest => dest.HeadTeacher,
                    cfg => cfg.MapFrom(src => src.headerTeacher))
                .ForMember(dest => dest.StudentsEnrolled,
                    cfg => cfg.MapFrom(src => src.enrollments))
                ;

            CreateMap<StudentEnrolledInCourse, StudentEnrolledInCourseDto>()
                .ForMember(dest => dest.id,
                    cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.courseId,
                    cfg => cfg.MapFrom(src => src.Course.Id))
                .ForMember(dest => dest.course,
                    cfg => cfg.Ignore())
                .ForMember(dest => dest.studentEnrolledId,
                    cfg => cfg.MapFrom(src => src.Enrollment.Id))
                .ForMember(dest => dest.studentEnrolled,
                    cfg => cfg.Ignore())
                ;
            
            CreateMap<StudentEnrolledInCourseDto, StudentEnrolledInCourse>()
                .ForMember(dest => dest.Id,
                    cfg => cfg.MapFrom(src => src.id))
                .ForMember(dest => dest.Course,
                    cfg => cfg.MapFrom(src => src.course))
                .ForMember(dest => dest.Enrollment,
                    cfg => cfg.MapFrom(src => src.studentEnrolled))
                ;

            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dest => dest.id,
                    cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.student,
                    cfg => cfg.Ignore())
                .ForMember(dest => dest.studentId,
                    cfg => cfg.MapFrom(src => src.Student.Id))
                .ForMember(dest => dest.studyPlan,
                    cfg => cfg.Ignore())
                .ForMember(dest => dest.studyPlanId,
                    cfg => cfg.MapFrom(src => src.StudyPlan.Id))
                ;
            
            CreateMap<EnrollmentDto, Enrollment>()
                .ForMember(dest => dest.Id,
                    cfg => cfg.MapFrom(src => src.id))
                .ForMember(dest => dest.Student,
                    cfg => cfg.MapFrom(src => src.student))
                .ForMember(dest => dest.StudyPlan,
                    cfg => cfg.MapFrom(src => src.studyPlan))
                ;
            
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.id, 
                    act => act.MapFrom(x => x.Id))
                .ForMember(dest => dest.firstName, 
                    act => act.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.lastName, 
                    act => act.MapFrom(x => x.LastName))
                .ForMember(dest => dest.identificationNumber, 
                    act => act.MapFrom(x => x.IdentificationNumber));
            
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.Id, 
                    act => act.MapFrom(x => x.id))
                .ForMember(dest => dest.FirstName, 
                    act => act.MapFrom(x => x.firstName))
                .ForMember(dest => dest.LastName, 
                    act => act.MapFrom(x => x.lastName))
                .ForMember(dest => dest.IdentificationNumber, 
                    act => act.MapFrom(x => x.identificationNumber));


            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.id, 
                    act => act.MapFrom(x => x.Id))
                .ForMember(dest => dest.firstName, 
                    act => act.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.lastName, 
                    act => act.MapFrom(x => x.LastName))
                .ForMember(dest => dest.identificationNumber, 
                    act => act.MapFrom(x => x.IdentificationNumber))
                .ForMember(dest => dest.teacherIdentification, 
                    act => act.MapFrom(x => x.TeacherIdentification));

            CreateMap<TeacherDto, Teacher>()
                .ForMember(dest => dest.Id, 
                    act => act.MapFrom(x => x.id))
                .ForMember(dest => dest.FirstName, 
                    act => act.MapFrom(x => x.firstName))
                .ForMember(dest => dest.LastName, 
                    act => act.MapFrom(x => x.lastName))
                .ForMember(dest => dest.IdentificationNumber, 
                    act => act.MapFrom(x => x.identificationNumber))
                .ForMember(dest => dest.TeacherIdentification, 
                    act => act.MapFrom(x => x.teacherIdentification));

            CreateMap<Subject, SubjectDto>()
                .ForMember(dest => dest.id, 
                    act => act.MapFrom(x => x.Id))
                .ForMember(dest => dest.name, 
                    act => act.MapFrom(x => x.Name));
            
            CreateMap<SubjectDto, Subject>()
                .ForMember(dest => dest.Id, 
                    act => act.MapFrom(x => x.id))
                .ForMember(dest => dest.Name, 
                    act => act.MapFrom(x => x.name));

            CreateMap<StudyPlanDetail, StudyPlanDetailDto>()
                .ForMember(dest => dest.id, 
                    act => act.MapFrom(x => x.Id))
                .ForMember(dest => dest.name, 
                    act => act.MapFrom(x => x.Name))
                .ForMember(dest => dest.subject, 
                    act => act.Ignore())
                .ForMember(dest => dest.subjectId, 
                    act => act.MapFrom(x => x.Subject.Id))
                .ForMember(dest => dest.studyPlanId, 
                    act => act.MapFrom(x => x.StudyPlan.Id))
                .ForMember(dest => dest.studyPlan, 
                    act => act.Ignore())
                ;
            
            CreateMap<StudyPlanDetailDto, StudyPlanDetail>()
                .ForMember(dest => dest.Id, 
                    act => act.MapFrom(x => x.id))
                .ForMember(dest => dest.Name, 
                    act => act.MapFrom(x => x.name))
                .ForMember(dest => dest.Subject, 
                    act => act.MapFrom(x => x.subject))
                ;
            
            CreateMap<StudyPlan, StudyPlanDto>()
                .ForMember(dest => dest.id, 
                    act => act.MapFrom(x => x.Id))
                .ForMember(dest => dest.name, 
                    act => act.MapFrom(x => x.Name))
                .ForMember(dest => dest.year, 
                    act => act.MapFrom(x => x.Year))
                ;
            
            CreateMap<StudyPlanDto, StudyPlan>()
                .ForMember(dest => dest.Id, 
                    act => act.MapFrom(x => x.id))
                .ForMember(dest => dest.Year, 
                    act => act.MapFrom(x => x.year))
                .ForMember(dest => dest.Name, 
                    act => act.MapFrom(x => x.name))
                ;
        }
    }
}