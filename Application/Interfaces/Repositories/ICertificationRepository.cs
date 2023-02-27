using Application.Interfaces.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICertificationRepository : IGenericRepository<Certification>
    {
        Task<List<Certification>> GetDoctorCertificationById(int doctorId);
    }
}
