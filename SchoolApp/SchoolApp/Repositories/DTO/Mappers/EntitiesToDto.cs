using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SchoolApp.Models;

namespace SchoolApp.Repositories.DTO.Mappers
{
    public class EntitiesToDto : Profile
    {
        public EntitiesToDto()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.id, act => act.MapFrom(x => x.Id))
                .ForMember(dest => dest.firstName, act => act.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.lastName, act => act.MapFrom(x => x.LastName))
                .ForMember(dest => dest.identificationNumber, act => act.MapFrom(x => x.IdentificationNumber));
            
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.Id, act => act.MapFrom(x => x.id))
                .ForMember(dest => dest.FirstName, act => act.MapFrom(x => x.firstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(x => x.lastName))
                .ForMember(dest => dest.IdentificationNumber, act => act.MapFrom(x => x.identificationNumber));
        }
    }
}