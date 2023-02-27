using Application.Interfaces;
using Application.Interfaces.Repositories.Base;
using Domain.Aggregates;
using Domain.Entities;
using Persistance.EFCoreDbContext;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalDbContext _dbContext;
        //private bool disposed;
        public IGenericRepository<Allergy> AllergyRepository { get; private set; }
        public IGenericRepository<Certification> CertificationRepository { get; private set; }
        public IGenericRepository<Doctor> DoctorRepository { get; private set; }
        public IGenericRepository<Drug> DrugRepository { get; private set; }
        public IGenericRepository<Education> EducationRepository { get; private set; }
        public IGenericRepository<Language> LanguageRepository { get; private set; }
        public IGenericRepository<Nurse> NurseRepository { get; private set; }
        public IGenericRepository<Patient> PatientRepository { get; private set; }
        public IGenericRepository<Prescription> PrescriptionRepository { get; private set; }
        public IGenericRepository<Specialty> SpecialtyRepository { get; private set; }
        public UnitOfWork(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
            AllergyRepository = new GenericRepository<Allergy>(_dbContext);
            CertificationRepository = new GenericRepository<Certification>(_dbContext);
            DoctorRepository = new GenericRepository<Doctor>(_dbContext);
            DrugRepository = new GenericRepository<Drug>(_dbContext);
            EducationRepository = new GenericRepository<Education>(_dbContext);
            LanguageRepository = new GenericRepository<Language>(_dbContext);
            NurseRepository = new GenericRepository<Nurse>(_dbContext);
            PatientRepository = new GenericRepository<Patient>(_dbContext);
            PrescriptionRepository = new GenericRepository<Prescription>(_dbContext);
            SpecialtyRepository = new GenericRepository<Specialty>(_dbContext);
        }
        //protected virtual void Clean(bool disposing)
        //{
        //    if (!disposed)
        //    {
        //        if (disposing)
        //        {
        //            Dispose();
        //        }
        //    }
        //    disposed = true;
        //}

        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        //public void Dispose()
        //{
        //    Clean(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
