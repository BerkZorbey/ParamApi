using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories.Base;
using Application.Interfaces.Services;
using Application.Services.Base;
using AutoMapper;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PrescriptionService : BaseService<PrescriptionDto, Prescription>, IPrescriptionService
    {
        public PrescriptionService(IGenericRepository<Prescription> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
