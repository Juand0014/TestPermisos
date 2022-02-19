using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Dto
{
    public class PermissionsDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public PermissionTypeDto PermissionType { get; set; }
        public DateTime DatePermission { get; set; }
    }
}
