using Application.Interfaces;
using Application.Interfaces.Repositories.Base;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Base;
using AutoMapper;
using Domain.Base;
using Domain.ValueObject.ResponseModels;

namespace Application.Services.Base
{
    public abstract class BaseService<Dto, TEntity> : IBaseService<Dto, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BaseService(IGenericRepository<TEntity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseModel<IEnumerable<Dto>>> GetAll()
        {
            var entity = await _genericRepository.GetAll();
            var result = _mapper.Map<IEnumerable<Dto>>(entity.Model);
            return new ResponseModel<IEnumerable<Dto>>(200,result);
        }

        public async virtual Task<ResponseModel<Dto>> GetById(int id)
        {
            try
            {
                var entity = await _genericRepository.GetById(id);
                if (entity is null)
                {
                    throw new Exception("Data is not found");
                }
                var result = _mapper.Map<Dto>(entity.Model);
                return new ResponseModel<Dto>(200,result);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Dto>(404,ex);
            }

        }

        public virtual async Task<ResponseModel> InsertAsync(Dto dto)
        
        {
            try
            {
                if (dto is null)
                {
                    throw new Exception("Model is not valid.");
                }
                var entity = _mapper.Map<TEntity>(dto);

                var result = await _genericRepository.InsertAsync(entity);
                await _unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(400,ex);
            }

        }

        public virtual async Task<ResponseModel> UpdateAsync(int id, Dto dto)
        {
            try
            {
                var tempEntity = await _genericRepository.GetById(id);
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                var entity = _mapper.Map(dto, tempEntity.Model);
                var result = await _genericRepository.UpdateAsync(entity);
                await _unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404,ex);
            }

        }
        public async Task<ResponseModel> DeleteAsync(int id)
        {

            try
            {
                var tempEntity = await _genericRepository.GetById(id);
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                var result = await _genericRepository.DeleteAsync(tempEntity.Model);
                await _unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404,ex);
            }

        }
    }
}
