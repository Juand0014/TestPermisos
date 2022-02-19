using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Validations;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using TestPermiso.Model.Entities;

namespace GenericApi.Services.Services
{
    public interface IPermissionTypeService : IBaseService<PermissionType, PermissionTypeDto>
    {

    }
    public class PermissionTypeServices : BaseService<PermissionType, PermissionTypeDto>, IPermissionTypeService
    {
        public PermissionTypeServices(
            IPermissionTypeRepository repository,
            IMapper mapper,
            IValidator<PermissionTypeDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}

