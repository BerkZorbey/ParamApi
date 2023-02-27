using Application.Interfaces.Repositories;
using Domain.Aggregates;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Persistance.EFCoreDbContext;
using Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
