using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Infrastructure;
using ProjectIV.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{
    public class ClientServices_Fake : BaseService, IClientServices
    {
        private readonly IRepository<Client> _clientRepo;
        IMappingHelper _mappingHelper;
        public ClientServices_Fake()
        {
            _clientRepo = new CacheRepository<Client>();
            _mappingHelper = new MappingHelper();
        }
        public int Add(Client oClientVM)
        {
            var oClientProfile = _mappingHelper.Map<Client>(oClientVM);
            _clientRepo.Add(oClientProfile, GetType().Name);
            return 1;

        }

        public Client Get(string clientNumber, int companyId)
        {
            //  ClientVM oClientProfileModel = null;

            var oClientProfile = _clientRepo.All(GetType().Name).Where(x => x.ClientNumber == clientNumber && x.CompanyId == companyId).FirstOrDefault();
            //  oClientProfileModel = _mappingHelper.Map<ClientVM>(oClientProfile);
            return oClientProfile;
        }

        public List<Client> GetList(int companyId)
        {
            List<Client> oClientProfileList = null;
            try
            {
                oClientProfileList = _clientRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
                //oClientVMList = _mappingHelper.Map<List<ClientVM>>(oClientProfileList);

            }
            catch (Exception)
            {

            }

            return oClientProfileList;

        }

        public int Update(Client oClient)
        {
            throw new NotImplementedException();
        }
    }
}
