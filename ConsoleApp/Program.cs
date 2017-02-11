using AutoMapper;
using Byaxiom.Logger;
using MyAppTools.Helpers;
using MyAppTools.Services;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Models;
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
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<ClientVM, Client>()
                //  .ForMember(dest => dest.ClientContacts, opt => opt.MapFrom(src => src.ClientContacts))

                .IgnoreAllNonExisting()
                .ReverseMap();

                cfg.CreateMap<ClientContactVM, ClientContact>()
             .IgnoreAllNonExisting()
             .ReverseMap();

            });

            var oClientVM = new ClientVM()
            {
                ClientAddress = "Lagos",
                ClientContacts = new List<ClientContactVM> { new ClientContactVM {EmailAddress = "lanre@yahoos.com", HomeAddress= "Lagos, Nigeria", Name="Lanre" , PhoneNumber="08023147845"},
                                                            new ClientContactVM { EmailAddress = "lanre2@yahoos.com" } },
                FirstName = "Lanre",
                CompanyId = "1",
                ClientEmailAddress = "email@work.com",
                ClientId = 1,
                ClientName = "Olanrewaju Okanrende",
                ClientNumber = "12314131",
                ClientPhoneNumber = "08043192041",
                ClientType = "1",
                LastName = "Okanrende",
                MiddleName = "Ope",
                OfficeAddress = "Office@123.com",
                OfficeEmailAddress = "office@email.com",
                OfficePhoneNumber = "084024242242",
                OtherDetails = "None",
                PaymentCurrency = "NGN"
            };

            LogHelper.Info(SerializationServices.SerializeJson(oClientVM));
           // Console.ReadLine();
            //  var oclientVM = new MappingHelper().Map<ClientVM>(oClientVM);

            var _serv = new ClientServices();
            var respo = _serv.Add(oClientVM);
            ClientVM geti = _serv.Get("12314131", "1");

            geti.ClientName = "new name";
            geti.ClientContacts.ElementAt(0).Name = "New contact name";

            _serv.Update(geti);
        }
    }
}
