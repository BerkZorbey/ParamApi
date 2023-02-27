using Application.DTOs;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AllergyDto, Allergy>();
            CreateMap<Allergy, AllergyDto>();

            CreateMap<DrugDto, Drug>();
            CreateMap<Drug, DrugDto>();
            
            CreateMap<LanguageDto, Language>();
            CreateMap<Language, LanguageDto>();
            
            CreateMap<SpecialtyDto, Specialty>();
            CreateMap<Specialty, SpecialtyDto>();

            CreateMap<Education, EducationDto>();
            CreateMap<EducationDto, Education>();

            CreateMap<Certification, CertificationDto>();
            CreateMap<CertificationDto, Certification>();

            CreateMap<Prescription, PrescriptionDto>();
            CreateMap<PrescriptionDto, Prescription>();

        CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Accepted, opt => opt.MapFrom(src => src.Accepted))
                .ForMember(dest => dest.Sickness, opt => opt.MapFrom(src => src.Sickness));

            CreateMap<PatientDto, Patient>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Accepted, opt => opt.MapFrom(src => src.Accepted))
                .ForMember(dest => dest.Sickness, opt => opt.MapFrom(src => src.Sickness));

            CreateMap<Nurse, NurseDto>();
            CreateMap<NurseDto, Nurse>();

            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
        }
    }
}
