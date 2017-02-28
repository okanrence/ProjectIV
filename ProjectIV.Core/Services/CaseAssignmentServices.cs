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
        bool Update(CaseAssignmentVM oCaseAssignmentVM);
        bool Delete(int CaseAssignmentID);
        List<CaseAssignmentVM> GetListByGroup(int StaffGroupID, int companyId);
        List<CaseAssignmentVM> GetListbyStaff(int staffId, int companyId);
        List<CaseAssignmentVM> GetListbyCase(int CaseId, int companyId);
        List<CaseAssignmentVM> GetList();
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


        public List<CaseAssignmentVM> GetListbyCase(int CaseId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetListByCase(int caseId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<CaseAssignmentVM> GetListByGroup(int StaffGroupID, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetListbyStaff(int staffId, int companyId)
        {
            throw new NotImplementedException();
        }

        public bool Update(CaseAssignmentVM oCaseAssignmentVM)
        {
            throw new NotImplementedException();
        }

        List<CaseAssignmentVM> ICaseAssignmentServices.GetList()
        {
            throw new NotImplementedException();
        }

        List<CaseAssignmentVM> ICaseAssignmentServices.GetListbyStaff(int staffId, int companyId)
        {
            throw new NotImplementedException();
        }
    }

}
