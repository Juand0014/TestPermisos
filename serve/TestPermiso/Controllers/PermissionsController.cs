using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;

namespace GenericApi.Controllers
{
    public class PermissionsController : BaseController<Permissions, PermissionsDto>
    {
        public PermissionsController(IPermissionsService service) : base(service)
        {
        }
    }
}
