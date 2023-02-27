using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services.Base;
using Domain.Aggregates;
using Domain.ValueObject;
using Domain.ValueObject.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAllergyService : IBaseService<AllergyDto, Allergy>
    {
        Task<ResponseModel<PatientDto>> InsertPatientAllergyAsync(PatientDto dto);
        Task<ResponseModel<PatientDto>> DeletePatientAllergyAsync(int id, PatientDto dto);
    }
}
