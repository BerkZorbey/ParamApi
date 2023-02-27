using Application.DTOs;
using Application.Interfaces.Services.Base;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ILanguageService : IBaseService<LanguageDto,Language>
    {
    }
}
