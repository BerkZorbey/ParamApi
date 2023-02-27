
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Base;
using Domain.Aggregates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EFCoreDbContext;
using Persistance.Repositories;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceServiceRegistration
    {
        
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<HospitalDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("SQL"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGenericRepository<Allergy>, GenericRepository<Allergy>>();
            services.AddScoped<IGenericRepository<Certification>, GenericRepository<Certification>>();
            services.AddScoped<IGenericRepository<Doctor>, GenericRepository<Doctor>>();
            services.AddScoped<IGenericRepository<Drug>, GenericRepository<Drug>>();
            services.AddScoped<IGenericRepository<Education>, GenericRepository<Education>>();
            services.AddScoped<IGenericRepository<Language>, GenericRepository<Language>>();
            services.AddScoped<IGenericRepository<Nurse>, GenericRepository<Nurse>>();
            services.AddScoped<IGenericRepository<Patient>, GenericRepository<Patient>>();
            services.AddScoped<IGenericRepository<Prescription>, GenericRepository<Prescription>>();
            services.AddScoped<IGenericRepository<Specialty>, GenericRepository<Specialty>>();

            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<INurseRepository, NurseRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();

            


            return services;
        }
    }
}
