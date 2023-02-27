using Application.DTOs;
using Application.Interfaces.Repositories.Base;
using Domain.Aggregates;
using Domain.ValueObject;
using Domain.ValueObject.Paging;
using Domain.ValueObject.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<ResponseModel<List<AllergyPatient>>> InsertPatientAllergies(int id, ResponseModel<Patient> tempEntity, PatientDto dto);
        Task<List<Allergy>> GetPatientAllergiesById(int patientId);
        void DeleteAllergiesIds(List<AllergyPatient> allergyPatients);
        Task<List<AllergyPatient>> GetAllergiesIds(int patientId);
    }
}
