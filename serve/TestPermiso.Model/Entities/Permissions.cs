using GenericApi.Core.BaseModel;
using System;
using TestPermiso.Model.Entities;

namespace GenericApi.Model.Entities
{
    public class Permissions : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public PermissionType PermissionType { get; set; }
        public DateTime DatePermission { get; set; }
    }
}
