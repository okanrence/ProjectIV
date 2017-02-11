using AutoMapper;
using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIV.WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMap()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<ClientVM, Client>()
                .IgnoreAllNonExisting()
                .ReverseMap();

                cfg.CreateMap<ClientContactVM, ClientContact>()
                .IgnoreAllNonExisting()
                .ReverseMap();

                cfg.CreateMap<StaffVM, Staff>()
                .IgnoreAllNonExisting()
                .ReverseMap();

                cfg.CreateMap<Case, CaseVM>()
                .ForMember(dest => dest.CaseStatusName, opt => opt.MapFrom(src => src.CaseStatus.CaseStatusName))
               .IgnoreAllNonExisting()
               .ReverseMap();

                cfg.CreateMap<Staff, AssignStaffVM>()
                .IgnoreAllNonExisting()
                .ReverseMap();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}