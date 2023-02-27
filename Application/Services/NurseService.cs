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
    public class NurseService : BaseService<NurseDto, Nurse>, INurseService
    {
        public NurseService(IGenericRepository<Nurse> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
