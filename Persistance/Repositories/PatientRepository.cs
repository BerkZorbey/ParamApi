using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObject;
using Domain.ValueObject.Paging;
using Domain.ValueObject.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Persistance.EFCoreDbContext;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {

        private readonly HospitalDbContext _dbContext;
        private readonly IAllergyRepository _allergyRepository;

        public PatientRepository(IAllergyRepository allergyRepository, HospitalDbContext dbContext) : base(dbContext)
        {
            _allergyRepository = allergyRepository;
            this._dbContext = dbContext;

        }
       
        public async Task<ResponseModel<List<AllergyPatient>>> InsertPatientAllergies(int id,ResponseModel<Patient> tempEntity, PatientDto dto)
        {
            var patientAllergies = await GetAllergiesIds(id);
            var alergies = await _allergyRepository.GetAll();
            if(patientAllergies.Count()>=1)
            {
                foreach (var item in patientAllergies)
                {
                    foreach (var allergy in dto.Allergies)
                    {
                        var getAllergiesWithId = alergies.Model?.Where(x => x.Name == allergy.Name);
                        var tempAllergy = getAllergiesWithId?.Where(x => x.Id == item.AllergiyId).FirstOrDefault();
                        if (tempAllergy == null)
                        {
                            var addAllergy = alergies.Model?.Where(x => x.Name == allergy.Name).FirstOrDefault();
                            tempEntity.Model.AllergyPatients.Add(new AllergyPatient
                            {
                                AllergiyId = addAllergy.Id,
                                PatientId = id

                            });
                        }


                    }


                }
            }
            else
            {
                foreach (var allergy in dto.Allergies)
                {
                    var getAllergiesWithId = alergies.Model?.Where(x => x.Name == allergy.Name).FirstOrDefault();
                    tempEntity.Model.AllergyPatients.Add(new AllergyPatient
                    {
                        AllergiyId = getAllergiesWithId.Id,
                        PatientId = id

                    });         
                }
            }
            
            await _dbContext.AllergyPatients.AddRangeAsync(tempEntity.Model.AllergyPatients);
            return new ResponseModel<List<AllergyPatient>>(tempEntity.Model.AllergyPatients);
        }
        public async Task<List<Allergy>> GetPatientAllergiesById(int patientId)
        {
            
            var getAllergiesId = await _dbContext.AllergyPatients.Where(x => x.PatientId == patientId).ToListAsync();
            List<Allergy> allergies = new();
            foreach(var item in getAllergiesId)
            {
                allergies.Add(_dbContext.Allergies.Where(x => x.Id == item.AllergiyId).First());
            }
            return allergies;
        }
        public void DeleteAllergiesIds(List<AllergyPatient> allergyPatients)
        {
            
            foreach (var item in allergyPatients)
            {
                var entity = _dbContext.AllergyPatients.Where(x => x.PatientId == item.PatientId && x.AllergiyId == item.AllergiyId).FirstOrDefault();
                _dbContext.AllergyPatients.Remove(entity);
                
            }
            

        }
        public async Task<List<AllergyPatient>> GetAllergiesIds(int patientId)
        {
            return await _dbContext.AllergyPatients.Where(x => x.PatientId == patientId).ToListAsync();
        }

    }
}
