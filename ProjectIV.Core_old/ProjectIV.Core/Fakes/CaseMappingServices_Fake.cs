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
using Byaxiom.Logger;

namespace ProjectIV.Core.Services
{
    public class CaseMappingServices_Fake : ICaseMappingServices
    {

        private readonly IRepository<CaseMapping> _caseMappingRepo;
        IMappingHelper _mappingHelper;
        public CaseMappingServices_Fake()
        {
            _caseMappingRepo = new CacheRepository<CaseMapping>();
            _mappingHelper = new MappingHelper();
        }


        public int Add(CaseMappingVM oCaseMappingVM)
        {
            var oCaseMapping = _mappingHelper.Map<CaseMapping>(oCaseMappingVM);
            _caseMappingRepo.Add(oCaseMapping, GetType().Name);
            return 1;
        }

        public List<CaseMappingVM> GetList(int companyId)
        {
            List<CaseMappingVM> oClientVMList = null;
            try
            {
                var oCaseMappingList = _caseMappingRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
                oClientVMList = _mappingHelper.Map<List<CaseMappingVM>>(oCaseMappingList);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
            }
            return oClientVMList;
        }

     
       
        //public CaseVM Get(string caseNumber, int companyId)
        //{
        //    CaseVM oClientProfileModel = null;
        //    try
        //    {
        //        var oClientProfile = _caseMappingRepo.GetAll(GetType().Name).Where(x => x.CaseNumber == caseNumber && x.CompanyId == companyId).FirstOrDefault();
        //        oClientProfileModel = _mappingHelper.Map<CaseVM>(oClientProfile);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return oClientProfileModel;
        //}

        public List<StaffVM> GetAssignedStaff(int caseId)
        {
            List<StaffVM> oStaffVMList = null;
            try
            {
                var oAssignedStaffList = _caseMappingRepo.All(GetType().Name).Where(x => x.CaseId == caseId).ToList();
                oStaffVMList = _mappingHelper.Map<List<StaffVM>>(oAssignedStaffList);
            }
            catch (Exception)
            {

            }
            return oStaffVMList;
        }

        public List<CaseMappingVM> GetListByCase(int caseId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetListbyStaff(int staffId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
