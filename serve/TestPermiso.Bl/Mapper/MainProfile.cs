using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TestPermiso.Model.Entities;

namespace GenericApi.Bl.Mapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Permissions, PermissionsDto>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();
        }
    }
}
