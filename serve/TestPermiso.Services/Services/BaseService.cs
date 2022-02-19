using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using GenericApi.Bl.Extensions;
using GenericApi.Core.Abstract;
using GenericApi.Core.BaseModel;
using GenericApi.Model.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Services.Services
{
    public interface IBaseService<TEntity, TDto>
    {
        Task<IEntityOperationResult<TDto>> AddAsync(TDto dto);
    }
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IBase
        where TDto : class, IBaseDto
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IValidator<TDto> _validator;
        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper, IValidator<TDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public virtual async Task<IEntityOperationResult<TDto>> AddAsync(TDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (validationResult.IsValid is false)
                return validationResult.ToOperationResult<TDto>();

            TEntity entity = _mapper.Map<TEntity>(dto);
            var entityResult = await _repository.Add(entity);

            _mapper.Map(entityResult, dto);

            var result = dto.ToOperationResult();
            return result;
        }
    }
}
