using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Infrastructure;
using ProjectIV.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{

    public interface IClientServices
    {
        int Add(ClientVM oClientProfileModel);
        ClientVM Get(string clientNumber, string companyId);
        List<ClientVM> GetList(string companyId);
        int Update(ClientVM oClient);
    }
    public class ClientServices : BaseService, IClientServices
    {

        private readonly IRepository<Client> _clientRepo;
        IMappingHelper _mappingHelper;

        public ClientServices()
        {
            _clientRepo = new BaseRepository<Client>(this.unitOfWork);
            _mappingHelper = new MappingHelper();
        }
        public int Add(ClientVM oClientVM)
        {
            var oClient = _mappingHelper.Map<Client>(oClientVM);
            _clientRepo.Add(oClient, GetType().Name);
            unitOfWork.SaveChanges();
            return oClient.ClientId;
        }

        public int Update(ClientVM oClientVM)
        {
            var modifiedClient = _mappingHelper.Map<Client>(oClientVM);
            var originalProfile = _clientRepo.Find(modifiedClient.ClientId);
            originalProfile.ClientAddress = modifiedClient.ClientAddress;
            originalProfile.ClientEmailAddress = modifiedClient.ClientEmailAddress;
            originalProfile.ClientName = modifiedClient.ClientName;
            originalProfile.ClientNumber = modifiedClient.ClientNumber;
            originalProfile.ClientPhoneNumber = modifiedClient.ClientPhoneNumber;
            originalProfile.ClientType = modifiedClient.ClientType;
            originalProfile.CompanyId = modifiedClient.CompanyId;
            originalProfile.DateLastUpdated = DateTime.Now;
            originalProfile.FirstName = modifiedClient.FirstName;
            originalProfile.FullName = modifiedClient.FullName;
            originalProfile.LastName = modifiedClient.LastName;
            originalProfile.MiddleName = modifiedClient.MiddleName;
            originalProfile.OfficeEmailAddress = modifiedClient.OfficeEmailAddress;
            originalProfile.OfficePhoneNumber = modifiedClient.OfficePhoneNumber;
            originalProfile.OtherDetails = modifiedClient.OtherDetails;
            originalProfile.PaymentCurrency = modifiedClient.PaymentCurrency;
            var modifiedClientContactsList = new List<ClientContact>();
            foreach (var modifiedClientContact in modifiedClient.ClientContacts)
            {
                var originalClientContact = originalProfile.ClientContacts.Where(x => x.ContactId == modifiedClientContact.ContactId).FirstOrDefault();
                originalClientContact.Client = modifiedClientContact.Client;
               // originalClientContact.ClientId = modifiedClientContact.ClientId;
                originalClientContact.ContactId = modifiedClientContact.ContactId;
                originalClientContact.EmailAddress = modifiedClientContact.EmailAddress;
                originalClientContact.HomeAddress = modifiedClientContact.HomeAddress;
                originalClientContact.Name = modifiedClientContact.Name;
                originalClientContact.PhoneNumber = modifiedClientContact.PhoneNumber;

                modifiedClientContactsList.Add(originalClientContact);
            }
            originalProfile.ClientContacts = modifiedClientContactsList;

            _clientRepo.Edit(originalProfile, GetType().Name);

            return unitOfWork.SaveChanges();
        }

        public ClientVM Get(string clientNumber, string companyId)
        {
            ClientVM oClientVM = null;
            var oClient = _clientRepo.All(GetType().Name).Where(x => x.ClientNumber == clientNumber && x.CompanyId == companyId).FirstOrDefault();
            oClientVM = _mappingHelper.Map<ClientVM>(oClient);
            return oClientVM;
        }

        public List<ClientVM> GetList(string companyId)
        {
            var oClientList = _clientRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
            var oClientVMList = _mappingHelper.Map<List<ClientVM>>(oClientList);
            return oClientVMList;
        }

    }
}