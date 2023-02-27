using Application.Interfaces.Repositories.Base;
using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork /*: IDisposable*/
    {
        Task CompleteAsync();
        public IGenericRepository<Allergy> AllergyRepository { get; }
        public IGenericRepository<Certification> CertificationRepository { get; }
        public IGenericRepository<Doctor> DoctorRepository { get; }
        public IGenericRepository<Drug> DrugRepository { get; }
        public IGenericRepository<Education> EducationRepository { get; }
        public IGenericRepository<Language> LanguageRepository { get; }
        public IGenericRepository<Nurse> NurseRepository { get; }
        public IGenericRepository<Patient> PatientRepository { get; }
        public IGenericRepository<Prescription> PrescriptionRepository { get; }
        public IGenericRepository<Specialty> SpecialtyRepository { get; }
    }
}
