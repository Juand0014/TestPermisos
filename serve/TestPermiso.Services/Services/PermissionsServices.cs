using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Validations;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;

namespace GenericApi.Services.Services
{
    public interface IPermissionsService : IBaseService<Permissions, PermissionsDto>
    {

    }
    public class PermissionsServices : BaseService<Permissions, PermissionsDto>, IPermissionsService
    {
        public PermissionsServices(
            IPermissionsRepository repository,
            IMapper mapper,
            IValidator<PermissionsDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}

