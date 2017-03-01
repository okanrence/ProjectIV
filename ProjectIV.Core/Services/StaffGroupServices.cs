using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Infrastructure;
using ProjectIV.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{
    public interface IStaffGroupServices
    {
        int Add(StaffGroupVM oStaffGroupVM);
        int Update(StaffGroupVM oStaffGroupVM);
        StaffGroupVM Get(int StaffGroupId, string companyId);
        List<StaffGroupVM> GetList(string companyId);
    }
    public class StaffGroupServices : BaseService, IStaffGroupServices
    {
        private readonly IRepository<StaffGroup> _StaffGroupRepo;
        IMappingHelper _mappingHelper;
        public StaffGroupServices()
        {
            _StaffGroupRepo = new BaseRepository<StaffGroup>(this.unitOfWork);
            _mappingHelper = new MappingHelper();
        }

        public int Add(StaffGroupVM oStaffGroupModel)
        {
            var oStaffGroupProfile = _mappingHelper.Map<StaffGroup>(oStaffGroupModel);
            _StaffGroupRepo.Add(oStaffGroupProfile, GetType().Name);
          return  this.unitOfWork.SaveChanges();
        }

      
        public StaffGroupVM Get(int StaffGroupId, string companyId)
        {
            var oStaffGroupProfile = _StaffGroupRepo.All(GetType().Name).Where(x => x.StaffGroupId == StaffGroupId && x.CompanyId == companyId).FirstOrDefault();
            var oStaffGroupModel = _mappingHelper.Map<StaffGroupVM>(oStaffGroupProfile);
            return oStaffGroupModel;
        }


        public List<StaffGroupVM> GetList(string companyId)
        {
            var oStaffGroupProfile = _StaffGroupRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
            var oStaffGroupModel = _mappingHelper.Map<List<StaffGroupVM>>(oStaffGroupProfile);
            return oStaffGroupModel;
        }


        public int Update(StaffGroupVM oStaffGroupVM)
        {
            var modifiedStaffGroup = _mappingHelper.Map<StaffGroup>(oStaffGroupVM);
            var originalStaffGroup = _StaffGroupRepo.Find(modifiedStaffGroup.StaffGroupId);
            originalStaffGroup.AssignedCases = modifiedStaffGroup.AssignedCases;
            originalStaffGroup.AssignedStaff = modifiedStaffGroup.AssignedStaff;
            originalStaffGroup.DateLastUpdated = modifiedStaffGroup.DateLastUpdated;
            originalStaffGroup.GroupName = modifiedStaffGroup.GroupName;

            _StaffGroupRepo.Edit(originalStaffGroup, GetType().Name);

            return unitOfWork.SaveChanges();
        }
    }
}
