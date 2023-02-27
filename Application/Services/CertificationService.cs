using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Base;
using Application.Interfaces.Services;
using Application.Services.Base;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CertificationService : BaseService<CertificationDto, Certification>, ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;
        private readonly IMapper _mapper;

        public CertificationService(ICertificationRepository certificationRepository, IGenericRepository<Certification> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            _certificationRepository = certificationRepository;
            _mapper = mapper;
        }

        public async Task<List<CertificationDto>> GetDoctorCertificationById(int doctorId)
        {          
                var entity = await _certificationRepository.GetDoctorCertificationById(doctorId);
                var result = _mapper.Map<List<CertificationDto>>(entity);
                return result;     
        }
    }
}
