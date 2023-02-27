using Application.Interfaces.Repositories;
using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Persistance.EFCoreDbContext;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CertificationRepository : GenericRepository<Certification>, ICertificationRepository
    {
        private readonly HospitalDbContext _dbContext;
        public CertificationRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<Certification>> GetDoctorCertificationById(int doctorId)
        {
            var getCertification = await _dbContext.Certifications.Where(x => x.DoctorId == doctorId).ToListAsync();
            return getCertification;
        }
        
    }
}
