using Application.DTOs;
using Application.Interfaces.Services.Base;
using Domain.Entities;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICertificationService : IBaseService<CertificationDto,Certification>
    {
        Task<List<CertificationDto>> GetDoctorCertificationById(int doctorId);
    }
}
