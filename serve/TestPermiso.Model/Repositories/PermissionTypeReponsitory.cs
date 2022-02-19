using GenericApi.Core.BaseModel;
using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestPermiso.Model.Entities;

namespace GenericApi.Model.Repositories
{
    public interface IPermissionTypeRepository : IBaseRepository<PermissionType> { }
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(GenericDbContext context) : base(context)
        {
        }
    }
}
