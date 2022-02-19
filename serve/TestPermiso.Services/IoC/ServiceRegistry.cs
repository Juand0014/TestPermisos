using GenericApi.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IPermissionsService, PermissionsServices>();
            services.AddScoped<IPermissionTypeService, PermissionTypeServices>();
        }
    }
}
