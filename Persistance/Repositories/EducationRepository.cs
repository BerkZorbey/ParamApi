using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistance.EFCoreDbContext;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        public EducationRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
