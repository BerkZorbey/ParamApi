using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Base;
using Application.Interfaces.Services;
using Application.Services.Base;
using AutoMapper;
using Domain.Aggregates;
using Domain.ValueObject;
using Domain.ValueObject.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AllergyService : BaseService<AllergyDto, Allergy>, IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AllergyService(IAllergyRepository allergyRepository, IPatientRepository patientRepository, IGenericRepository<Allergy> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _allergyRepository = allergyRepository;
            _patientRepository = patientRepository;
        }

        public async Task<ResponseModel<PatientDto>> InsertPatientAllergyAsync(PatientDto dto)
        {
            var alergies = await _allergyRepository.GetAll();
            foreach (var item in dto.Allergies)
            {
                var allergy = alergies.Model.Where(x => x.Name == item.Name).FirstOrDefault();
                if (allergy == null)
                {
                    var entityAllergy = _mapper.Map<Allergy>(item);
                    await _allergyRepository.InsertAsync(entityAllergy);
                }


            }
            await _unitOfWork.CompleteAsync();
            return new ResponseModel<PatientDto>(dto);
        }
        public async Task<ResponseModel<PatientDto>> DeletePatientAllergyAsync(int id,PatientDto dto)
        {
            var patientAllergies = await _patientRepository.GetAllergiesIds(id);
            var alergies = await _allergyRepository.GetAll();
            List<AllergyPatient> removeAllergies = new();
            
            
            if (patientAllergies != null)
            {
                foreach (var item in patientAllergies)
                {
                    var getAllergiesWithId = alergies.Model.Where(x => x.Id == item.AllergiyId);
                    foreach (var allergy in getAllergiesWithId)
                    {
                        var newAllergies = dto.Allergies.Where(x => x.Name == allergy.Name).FirstOrDefault();
                        if(newAllergies == null)
                        {
                            removeAllergies.Add(new AllergyPatient
                            {
                                AllergiyId = allergy.Id,
                                PatientId = id
                            });
                        }
                    }
                }
            }

            _patientRepository.DeleteAllergiesIds(removeAllergies);
            await _unitOfWork.CompleteAsync();
            return new ResponseModel<PatientDto>(dto);
        }
    }
}
