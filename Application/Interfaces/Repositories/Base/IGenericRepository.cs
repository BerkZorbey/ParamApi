using Domain.Base;
using Domain.ValueObject.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<ResponseModel<IEnumerable<TEntity>>> GetAll();
        public Task<ResponseModel<TEntity>> GetById(int id);
        public Task<ResponseModel> InsertAsync(TEntity entity);
        public Task<ResponseModel> UpdateAsync(TEntity entity);
        public Task<ResponseModel> DeleteAsync(TEntity entity);
    }
}
