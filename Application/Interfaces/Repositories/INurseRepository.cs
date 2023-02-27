﻿using Application.Interfaces.Repositories.Base;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface INurseRepository : IGenericRepository<Nurse>
    {
    }
}
