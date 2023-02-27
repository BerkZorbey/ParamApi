using Application.DTOs;
using Application.DTOs.FluentValidation;
using Application.Interfaces.Services;
using Domain.Aggregates;
using Domain.ValueObject.Paging;
using Domain.ValueObject.ResponseModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace ParamApi.Controllers.Patient
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<PagingResponseModel<PatientDto>> GetPatientWithPaging([FromQuery] PagingQuery query)
        {
            var patientList = await _patientService.GetPatientWithPaging(query);

            return patientList;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<PatientDto>> GetPatientById(int id)
        {
            var response = await _patientService.GetById(id);
            var getAllergies = await _patientService.GetPatientAllergiesById(id);
            response.Model.Allergies = getAllergies;
            return response;
        }
        [HttpPost]
        public async Task<ResponseModel> InsertPatient([FromBody] PatientDto patient)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    var response = await _patientService.InsertAsync(patient);
                    return response;             
                }
                return new ResponseModel(400, "Model is not valid");
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ResponseModel> UpdatePatient(int id, [FromBody] PatientDto patient)
        {
            try
            {
                var response = await _patientService.UpdateAsync(id, patient);
                return response;
            }
            catch(Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }
            
        }
        [HttpPatch]
        public async Task<ResponseModel> UpdatePatientPhone(int id, [FromBody] PatientPhoneDto phoneDto)
        {
            try
            {
                var response = await _patientService.UpdatePhoneAsync(id, phoneDto);
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel> HardDeletePatient(int id)
        {
            var response = await _patientService.DeleteAsync(id);
            return response;
        }
    }
}
