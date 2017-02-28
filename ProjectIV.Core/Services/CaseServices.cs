using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Infrastructure;
//using ProjectIV.Core.Helpers;
using ProjectIV.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{

    public interface ICaseServices
    {
        int Add(CaseVM oCaseVM);
        CaseVM Get(string caseNumber, string companyId);
        List<CaseVM> GetList(string companyId);
        List<CaseVM> GetList(int clientId, string companyId);
        List<StaffVM> GetAssignedStaff(int caseId);
    }
    public class CaseServices : BaseService, ICaseServices
    {
        private readonly IRepository<Case> _caseRepo;
       // private readonly IRepository<CaseMapping> _caseMappingRepo;
        IMappingHelper _mappingHelper;
        public CaseServices()
        {
            _caseRepo = new BaseRepository<Case>(this.unitOfWork);
         //   _caseMappingRepo = new BaseRepository<CaseMapping>(this.unitOfWork);
            _mappingHelper = new MappingHelper();
        }

        public int Add(CaseVM oCaseVM)
        {
            var oClientProfile = _mappingHelper.Map<Case>(oCaseVM);
            _caseRepo.Add(oClientProfile, GetType().Name);
            return this.unitOfWork.SaveChanges();
        }

        public CaseVM Get(string caseNumber, string companyId)
        {
            var oClientProfile = _caseRepo.All(GetType().Name).Where(x => x.CaseNumber == caseNumber && x.CompanyId == companyId).FirstOrDefault();
            var oClientProfileModel = _mappingHelper.Map<CaseVM>(oClientProfile);
            return oClientProfileModel;
        }

        public List<StaffVM> GetAssignedStaff(int caseId)
        {
            throw new NotImplementedException();
        }

        public List<CaseVM> GetList(string companyId)
        {
            var oClientProfileList = _caseRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
            foreach (var o in oClientProfileList)
            {
                o.CaseStatus = new CaseStatus { CaseStatusId = o.CaseStatus.CaseStatusId, CaseStatusName = ((Enums.CaseStatus)o.CaseStatus.CaseStatusId).ToString() };
                o.CaseType = new CaseType { CaseTypeId = o.CaseType.CaseTypeId, CaseTypeName = ((Enums.CaseTypes)o.CaseType.CaseTypeId).ToString() };
            }
            var oClientVMList = _mappingHelper.Map<List<CaseVM>>(oClientProfileList);
            foreach (var o in oClientVMList)
            {
                o.CaseTypeName = ((Enums.CaseTypes)o.CaseTypeId).ToString();
                o.CaseStatusName = ((Enums.CaseStatus)o.CaseStatusId).ToString();
            }
            return oClientVMList;
        }
        public List<CaseVM> GetList(int clientId, string companyId)
        {
            var oClientProfileList = _caseRepo.All(GetType().Name).Where(x => x.ClientId == clientId && x.CompanyId == companyId).ToList();
            var oClientVMList = _mappingHelper.Map<List<CaseVM>>(oClientProfileList);
            return oClientVMList;
        }
    }

}
