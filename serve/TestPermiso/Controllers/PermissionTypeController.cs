using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using TestPermiso.Model.Entities;

namespace GenericApi.Controllers
{
    public class PermissionTypeController : BaseController<PermissionType, PermissionTypeDto>
    {
        public PermissionTypeController(IPermissionTypeService service) : base(service)
        {
        }
    }
}
