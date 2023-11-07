using AutoMapper;

using ePreschool.Core;
using ePreschool.Core.Dto;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Infrastructure.UnitOfWork;

using Microsoft.EntityFrameworkCore;

namespace ePreschool.Service
{
    public class BaseService<TEntity, TEntityDto> : IBaseService<TEntityDto> where TEntityDto : BaseDto where TEntity : IBaseEntity
    {
        protected readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        protected IBaseRepository<TEntity, int> _currentRepository { get; set; } 

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {   
            _mapper = mapper;
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<TEntityDto> AddAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
             await _currentRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TEntityDto>(entity);            
        }

        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var result = await _currentRepository.GetAllAsync();
            return _mapper.Map<List<TEntityDto>>(result);
        }

        public async Task<TEntityDto> GetByIdAsync(int id)
        {
           return _mapper.Map<TEntityDto>(await _currentRepository.GetByIdAsync(id));
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _currentRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(TEntityDto entityDto)
        {
            _currentRepository.Update(_mapper.Map<TEntity>(entityDto));
            await _unitOfWork.SaveChangesAsync();
        }

        protected Task<List<T>> ProjectToListAsync<T>(IQueryable source) => _mapper.ProjectTo<T>(source).ToListAsync();
        protected Task<T> ProjectToFirstAsync<T>(IQueryable source) => _mapper.ProjectTo<T>(source).FirstAsync();
        protected Task<T> ProjectToFirstOrDefaultAsync<T>(IQueryable source) => _mapper.ProjectTo<T>(source).FirstOrDefaultAsync();
        protected Task<T> ProjectToSingleAsync<T>(IQueryable source) => _mapper.ProjectTo<T>(source).SingleAsync();
        protected Task<T> ProjectToSingleOrDefaultAsync<T>(IQueryable source) => _mapper.ProjectTo<T>(source).SingleOrDefaultAsync();
    }
}
