using AutoMapper;
using Byaxiom.Logger;
using MyAppTools.Helpers;
using MyAppTools.Services;
using ProjectIV.Core.Domain;
using ProjectIV.Core.ViewModels;
using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAutoMapperConfig();
            var _staffServ = new StaffServices();
            var _staffgroupServ = new StaffGroupServices();
            var _caseServ = new CaseServices();
            var _caServ = new CaseAssignmentServices();
            var staffGroup = new StaffGroupVM
            {
                GroupName = "CLuster 1",
              //  AssignedCases = new List
            };
            _staffgroupServ.Add(staffGroup);

            //var oClientVM = new ClientVM()
            //{
            //    ClientAddress = "Lagos",
            //    ClientContacts = new List<ClientContactVM> { new ClientContactVM {EmailAddress = "lanre@yahoos.com", HomeAddress= "Lagos, Nigeria", Name="Lanre" , PhoneNumber="08023147845"},
            //                                                new ClientContactVM { EmailAddress = "lanre2@yahoos.com" } },
            //    FirstName = "Lanre",
            //    CompanyId = "1",
            //    ClientEmailAddress = "email@work.com",
            //    ClientId = 1,
            //    ClientName = "Olanrewaju Okanrende",
            //    ClientNumber = "12314131",
            //    ClientPhoneNumber = "08043192041",
            //    ClientType = "1",
            //    LastName = "Okanrende",
            //    MiddleName = "Ope",
            //    OfficeAddress = "Office@123.com",
            //    OfficeEmailAddress = "office@email.com",
            //    OfficePhoneNumber = "084024242242",
            //    OtherDetails = "None",
            //    PaymentCurrency = "NGN"
            //};

            //LogHelper.Info(SerializationServices.SerializeJson(oClientVM));
            //// Console.ReadLine();
            ////  var oclientVM = new MappingHelper().Map<ClientVM>(oClientVM);

            //var _serv = new ClientServices();
            //var respo = _serv.Add(oClientVM);
            //ClientVM geti = _serv.Get("12314131", "1");

            //geti.ClientName = "new name";
            //geti.ClientContacts.ElementAt(0).Name = "New contact name";

            //_serv.Update(geti);
        }

        private static void RunAutoMapperConfig()
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

                cfg.CreateMap<StaffGroupVM, StaffGroup>()
               .IgnoreAllNonExisting()
               .ReverseMap();

                cfg.CreateMap<CaseAssignmentVM, CaseAssignment>()
              .IgnoreAllNonExisting()
              .ReverseMap();

            });
        }
    }
}
