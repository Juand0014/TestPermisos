using GenericApi.Core;
using GenericApi.Model.Entities;
using System;
using TestPermiso.Model.Entities;

namespace Dallas.Services.Tests.Data
{
    public class ServicesTestsData
    {
        public readonly Permissions _permissions = new Permissions
        {
            Name = "Juan",
            LastName = "Matos",
            DatePermission = DateTime.Now,
            
        };

        public readonly Permissions _permissions2 = new Permissions
        {
            Name = "Pedro",
            LastName = "Martinez",
            DatePermission = DateTime.Now
        };
    }
}