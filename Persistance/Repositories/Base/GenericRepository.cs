using Application.Interfaces.Repositories.Base;
using Domain.Base;
using Domain.ValueObject.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Persistance.EFCoreDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly HospitalDbContext _dbContext;
        private DbSet<TEntity> _entities;
        public GenericRepository(HospitalDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._entities = _dbContext.Set<TEntity>();
        }

        public async Task<ResponseModel<IEnumerable<TEntity>>> GetAll()
        {
            var entity = await _entities.AsNoTracking().ToListAsync();
            return new ResponseModel<IEnumerable<TEntity>>(entity);
        }

        public virtual async Task<ResponseModel<TEntity>> GetById(int id)
        {
            var entity = await _entities.FindAsync(id);
            return new ResponseModel<TEntity>(entity);
        }

        public async Task<ResponseModel> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
           
            return new ResponseModel(201,$"Successfully {typeof(TEntity).Name} Added.");
        }

        public async Task<ResponseModel> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            return new ResponseModel(200,$"Successfully {typeof(TEntity).Name} Updated.");
        }
        public async Task<ResponseModel> DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
            return new ResponseModel(200,$"Successfully {typeof(TEntity).Name} Removed.");
        }
    }
}
