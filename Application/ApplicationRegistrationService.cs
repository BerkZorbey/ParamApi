using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mapper;
using Application.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationRegistrationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            // Add services to the container.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDrugService, DrugService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<INurseService, NurseService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddSingleton(mapper);
            
            return services;
        }
    }
}
