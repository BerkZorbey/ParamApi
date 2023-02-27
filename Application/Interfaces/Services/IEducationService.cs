using Application.DTOs;
using Application.Interfaces.Services.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IEducationService : IBaseService<EducationDto,Education>
    {
    }
}
