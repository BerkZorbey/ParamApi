using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoggerService : ILoggerService
    {

        private string FileName => "Logger\\Log_Message.json";

        public IEnumerable<Log> LogRead()
        {
            var FileReader = File.ReadAllText(FileName);

            return JsonSerializer.Deserialize<Log[]>(FileReader, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
        public async Task LogWrite(List<Log> logList)
        {
            var outputStream = File.OpenWrite(FileName);
            await JsonSerializer.SerializeAsync(outputStream, logList, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            outputStream.Close();
        }
    }
}
