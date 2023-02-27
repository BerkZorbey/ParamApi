using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILoggerService
    {
        IEnumerable<Log> LogRead();
        public Task LogWrite(List<Log> logList);
    }
}
