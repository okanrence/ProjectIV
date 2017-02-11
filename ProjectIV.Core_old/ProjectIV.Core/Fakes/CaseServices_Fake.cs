using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIV.Core.Models;
using ProjectIV.Core.Domain;
using MyAppTools.Helpers;
using ProjectIV.Core.Infrastructure;

namespace ProjectIV.Core.Services
{
    public class CaseServices_Fake : ICaseServices
    {

        private readonly IRepository<Case> _caseRepo;
        private readonly IRepository<CaseMapping> _caseMappingRepo;
        IMappingHelper _mappingHelper;
        public CaseServices_Fake()
        {
            _caseRepo = new CacheRepository<Case>();
            _caseMappingRepo = new CacheRepository<CaseMapping>();
            _mappingHelper = new MappingHelper();
        }

        public int Add(CaseVM oCaseVM)
        {
            var oClientProfile = _mappingHelper.Map<Case>(oCaseVM);
            _caseRepo.Add(oClientProfile, GetType().Name);
            return 1;
        }

        public CaseVM Get(string caseNumber, int companyId)
        {
            CaseVM oClientProfileModel = null;
            try
            {
                var oClientProfile = _caseRepo.All(GetType().Name).Where(x => x.CaseNumber == caseNumber && x.CompanyId == companyId).FirstOrDefault();
                oClientProfileModel = _mappingHelper.Map<CaseVM>(oClientProfile);
            }
            catch (Exception)
            {

            }
            return oClientProfileModel;
        }

        public List<StaffVM> GetAssignedStaff(int caseId)
        {
            List<StaffVM> oStaffVMList = null;
            try
            {
                var oAssignedStaffList = _caseMappingRepo.All(GetType().Name).Where(x => x.CaseId == caseId).ToList();
                oStaffVMList = _mappingHelper.Map<List<StaffVM>>(oAssignedStaffList);
            }
            catch (Exception )
            {

            }
            return oStaffVMList;
        }

        public List<CaseVM> GetList(int companyId)
        {
            List<CaseVM> oClientVMList = null;
            try
            {
                var oClientProfileList = _caseRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
                foreach (var o in oClientProfileList)
                {
                    o.CaseStatus = new CaseStatus { CaseStatusId = o.CaseStatusId, CaseStatusName = ((Enums.CaseStatus)o.CaseStatusId).ToString() };
                    o.CaseType = new CaseType { CaseTypeId = o.CaseTypeId, CaseTypeName = ((Enums.CaseTypes)o.CaseTypeId).ToString() };
                }
                oClientVMList = _mappingHelper.Map<List<CaseVM>>(oClientProfileList);
                foreach (var o in oClientVMList)
                {
                    o.CaseTypeName = ((Enums.CaseTypes)o.CaseTypeId).ToString();
                    o.CaseStatusName = ((Enums.CaseStatus)o.CaseStatusId).ToString();
                }
            }
            catch (Exception )
            {

            }
            return oClientVMList;
        }
        public List<CaseVM> GetList(int clientId, int companyId)
        {
            List<CaseVM> oClientVMList = null;
            try
            {
                var oClientProfileList = _caseRepo.All(GetType().Name).Where(x => x.ClientId == clientId && x.CompanyId == companyId).ToList();
                oClientVMList = _mappingHelper.Map<List<CaseVM>>(oClientProfileList);
            }
            catch (Exception )
            {

            }
            return oClientVMList;
        }
    }
}
