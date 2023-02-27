using Application.DTOs;
using Application.Interfaces.Services.Base;
using Domain.Aggregates;
using Domain.ValueObject.Paging;
using Domain.ValueObject.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IPatientService : IBaseService<PatientDto,Patient>
    {

        Task<PagingResponseModel<PatientDto>> GetPatientWithPaging(PagingQuery query);
        Task<List<AllergyDto>> GetPatientAllergiesById(int patientId);
        Task<ResponseModel> UpdatePhoneAsync(int id, PatientPhoneDto phoneDto);
    }
}
