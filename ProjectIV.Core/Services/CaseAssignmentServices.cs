using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Infrastructure;
using ProjectIV.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{

    public interface ICaseAssignmentServices
    {
        int Add(CaseAssignmentVM oCaseAssignmentVM);
        int Update(CaseAssignmentVM oCaseAssignmentVM);
        bool Delete(int CaseAssignmentID);
        List<CaseAssignmentVM> GetListByGroup(StaffGroup oStaffGroup, string companyId);
        List<CaseAssignmentVM> GetListbyStaff(Staff oStaff, string companyId);
        List<CaseAssignmentVM> GetListbyCase(Case oCase, string companyId);
        List<CaseAssignmentVM> GetList(string companyId);
    }
    public class CaseAssignmentServices : BaseService, ICaseAssignmentServices
    {
        private readonly IRepository<CaseAssignment> _caseAssignmentRepo;
        IMappingHelper _mappingHelper;
        public CaseAssignmentServices()
        {
            _caseAssignmentRepo = new BaseRepository<CaseAssignment>(this.unitOfWork);
            _mappingHelper = new MappingHelper();
        }
        public int Add(CaseAssignmentVM oCaseAssignmentVM)
        {
            var oCaseAssignment = _mappingHelper.Map<CaseAssignment>(oCaseAssignmentVM);
            _caseAssignmentRepo.Add(oCaseAssignment, GetType().Name);

            return this.unitOfWork.SaveChanges();
        }

        public bool Delete(int CaseAssignmentID)
        {
            throw new NotImplementedException();
        }

        public List<CaseAssignmentVM> GetListbyCase(Case oCase, string companyId)
        {
            var oCaseAssignmentList = _caseAssignmentRepo.All(GetType().Name).Where(x => x.CompanyId == companyId && x.CasesAssigned == oCase).ToList();
            //foreach (var o in oCaseAssignmentList)
            //{
            //    o.AssignedStaff = new sta { CaseStatusId = o.CaseStatus.CaseStatusId, CaseStatusName = ((Enums.CaseStatus)o.CaseStatus.CaseStatusId).ToString() };
            //    o.CaseType = new CaseType { CaseTypeId = o.CaseType.CaseTypeId, CaseTypeName = ((Enums.CaseTypes)o.CaseType.CaseTypeId).ToString() };
            //}
            var ocaVMList = _mappingHelper.Map<List<CaseAssignmentVM>>(oCaseAssignmentList);
            //foreach (var o in oClientVMList)
            //{
            //    o.CaseTypeName = ((Enums.CaseTypes)o.CaseTypeId).ToString();
            //    o.CaseStatusName = ((Enums.CaseStatus)o.CaseStatusId).ToString();
            //}
            return ocaVMList;
        }

      

        public List<CaseAssignmentVM> GetListByGroup(StaffGroup oStaffGroup, string companyId)
        {
            var oCaseAssignmentList = _caseAssignmentRepo.All(GetType().Name).Where(x => x.CompanyId == companyId && x.AssignedStaffGroup == oStaffGroup).ToList();
            var ocaVMList = _mappingHelper.Map<List<CaseAssignmentVM>>(oCaseAssignmentList);
            return ocaVMList;

        }

        public int Update(CaseAssignmentVM oCaseAssignmentVM)
        {
            var modifiedCa = _mappingHelper.Map<CaseAssignment>(oCaseAssignmentVM);
            var originalCa = _caseAssignmentRepo.Find(modifiedCa.CaseAssignmentId);
            originalCa.AssignedStaff = modifiedCa.AssignedStaff;
            originalCa.AssignedStaffGroup = modifiedCa.AssignedStaffGroup;
            originalCa.AssignmentType = modifiedCa.AssignmentType;
            originalCa.CasesAssigned = modifiedCa.CasesAssigned;
            originalCa.DateLastUpdated = modifiedCa.DateLastUpdated;

            _caseAssignmentRepo.Edit(originalCa, GetType().Name);

            return unitOfWork.SaveChanges();
        }

        //List<CaseAssignmentVM> ICaseAssignmentServices.GetList(string companyId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<CaseAssignmentVM> GetList(string companyId)
        {
            var oCaseAssignmentList = _caseAssignmentRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
            var ocaVMList = _mappingHelper.Map<List<CaseAssignmentVM>>(oCaseAssignmentList);
            return ocaVMList;
        }

        //List<CaseAssignmentVM> GetListbyStaff(Staff oStaff, string companyId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<CaseAssignmentVM> GetListbyStaff(Staff oStaff, string companyId)
        {
            var oCaseAssignmentList = _caseAssignmentRepo.All(GetType().Name).Where(x => x.CompanyId == companyId && x.AssignedStaff == oStaff).ToList();
            var ocaVMList = _mappingHelper.Map<List<CaseAssignmentVM>>(oCaseAssignmentList);
            return ocaVMList;
        }
    }

}
