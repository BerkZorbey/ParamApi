using Application.Interfaces.Repositories;
using Domain.Aggregates;
using Persistance.EFCoreDbContext;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class NurseRepository : GenericRepository<Nurse>, INurseRepository
    {
        public NurseRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
