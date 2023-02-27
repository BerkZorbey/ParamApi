using Application.DTOs;
using Application.DTOs.FluentValidation;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Base;
using Application.Interfaces.Services;
using Application.Services.Base;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObject;
using Domain.ValueObject.Paging;
using Domain.ValueObject.ResponseModels;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PatientService : BaseService<PatientDto, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAllergyService _allergyService;
        private readonly IAllergyRepository _allergyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IAllergyService allergyService, IAllergyRepository allergyRepository, IPatientRepository patientRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(patientRepository, mapper, unitOfWork)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _allergyService = allergyService;
            _allergyRepository = allergyRepository;
        }
        public async Task<PagingResponseModel<PatientDto>> GetPatientWithPaging(PagingQuery query)
        {
            PagingResponseModel<PatientDto> patientsPaging = new PagingResponseModel<PatientDto>(query);
            var patients = await _patientRepository.GetAll();
            var patientDto = _mapper.Map<IEnumerable<PatientDto>>(patients.Model);
            var result = patientDto.AsQueryable();
            patientsPaging.GetData(result);
            return patientsPaging;
        }
        public async Task<List<AllergyDto>> GetPatientAllergiesById(int patientId)
        {
            var entity = await _patientRepository.GetPatientAllergiesById(patientId);
            var result = _mapper.Map<List<AllergyDto>>(entity);
            return result;
        }
        public async override Task<ResponseModel> InsertAsync(PatientDto dto)
        {
            try
            {
                if (dto is null)
                {
                    throw new Exception("Model is not valid.");
                }
                PatientValidator validator = new();
                await validator.ValidateAndThrowAsync(dto);

                var entity = _mapper.Map<Patient>(dto);
                var alergies = await _allergyRepository.GetAll();
                
                if(dto.Allergies != null)
                {
                    await _allergyService.InsertPatientAllergyAsync(dto);

                    foreach (var item in dto.Allergies)
                    {
                        var allergy = alergies.Model?.Where(x => x.Name == item.Name).FirstOrDefault();
                        entity.AllergyPatients ??= new List<AllergyPatient>();
                            entity.AllergyPatients.Add(new AllergyPatient
                            {
                                AllergiyId = allergy.Id
                            });
                    }
                
                }
                var result = await _patientRepository.InsertAsync(entity);
                await _unitOfWork.CompleteAsync();
                return result;

            }
            catch (Exception ex)
            {
                return new ResponseModel(400,ex.Message);
            }
        }
        public async override Task<ResponseModel> UpdateAsync(int id, PatientDto dto)
        {
            try
            {
                PatientValidator validator = new();
                await validator.ValidateAndThrowAsync(dto);

                var tempEntity = await _patientRepository.GetById(id);

                tempEntity.Model.FirstName = dto.FirstName != default ? dto.FirstName : tempEntity.Model.FirstName;
                tempEntity.Model.LastName = dto.LastName != default ? dto.LastName : tempEntity.Model.LastName;
                tempEntity.Model.Phone = dto.Phone != default ? dto.Phone : tempEntity.Model.Phone;
                tempEntity.Model.Sickness = dto.Sickness != default ? dto.Sickness : tempEntity.Model.Sickness;
                tempEntity.Model.Address = dto.Address != default ? dto.Address : tempEntity.Model.Address;
                tempEntity.Model.Accepted = dto.Accepted != default ? dto.Accepted : tempEntity.Model.Accepted;
                tempEntity.Model.BirthDate = dto.BirthDate != default ? dto.BirthDate : tempEntity.Model.BirthDate;
                tempEntity.Model.Gender = dto.Gender != default ? dto.Gender : tempEntity.Model.Gender;

                tempEntity.Model.AllergyPatients ??= new List<AllergyPatient>();
                
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                
                if (dto.Allergies != null)
                {
                    await _allergyService.InsertPatientAllergyAsync(dto);
                    await _allergyService.DeletePatientAllergyAsync(id,dto);
                }
                await _patientRepository.InsertPatientAllergies(id,tempEntity,dto);
                tempEntity.Model.AllergyPatients = null;
                var entity = _mapper.Map(dto, tempEntity.Model);
                var result = await _patientRepository.UpdateAsync(entity);
                await _unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404,ex.Message);
            }
        }
        public async Task<ResponseModel> UpdatePhoneAsync(int id, PatientPhoneDto phoneDto)
        {
            try
            {
                PatientPhoneValidator validator = new();
                await validator.ValidateAndThrowAsync(phoneDto);
                var patient = await _patientRepository.GetById(id);
                if(patient is null)
                {
                    throw new Exception("Data is not found");
                }

                patient.Model.Phone = phoneDto.Phone != default ? phoneDto.Phone : patient.Model.Phone;
                var response = await _patientRepository.UpdateAsync(patient.Model);
                await _unitOfWork.CompleteAsync();
                return response;
            }
            catch(Exception ex)
            {
                return new ResponseModel(400,ex.Message);
            }
        }
    }
}
