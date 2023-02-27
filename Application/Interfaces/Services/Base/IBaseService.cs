using Domain.ValueObject.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Base
{
    public interface IBaseService<Dto, TEntity>
    {
        public Task<ResponseModel<IEnumerable<Dto>>> GetAll();
        public Task<ResponseModel<Dto>> GetById(int id);
        public Task<ResponseModel> InsertAsync(Dto dto);
        public Task<ResponseModel> UpdateAsync(int id, Dto dto);
        public Task<ResponseModel> DeleteAsync(int id);
    }
}
