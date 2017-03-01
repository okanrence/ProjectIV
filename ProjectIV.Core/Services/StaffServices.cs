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
    public interface IStaffServices
    {
        int Add(StaffVM oStaffVM);
        int Update(StaffVM oStaffVM);
        StaffVM Get(string staffNumber, string companyId);
        StaffVM GetByDesignation(string designation, string companyId);
        List<StaffVM> GetList(string companyId);
        List<AssignStaffVM> GetListForAssignment(string companyId);
        StaffVM Authenticate(string emailaddress, string password);
    }
    public class StaffServices : BaseService, IStaffServices
    {
        private readonly IRepository<Staff> _staffRepo;
        IMappingHelper _mappingHelper;
        public StaffServices()
        {
            _staffRepo = new BaseRepository<Staff>(this.unitOfWork);
            _mappingHelper = new MappingHelper();
        }

        public int Add(StaffVM oStaffModel)
        {
            var oStaffProfile = _mappingHelper.Map<Staff>(oStaffModel);
            _staffRepo.Add(oStaffProfile, GetType().Name);
          return  this.unitOfWork.SaveChanges();
        }

        public StaffVM Authenticate(string emailaddress, string password)
        {
            
            var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.EmailAddress == emailaddress).FirstOrDefault();
            var oStaffModel = _mappingHelper.Map<StaffVM>(oStaffProfile);
            return oStaffModel;
        }

        public StaffVM Get(string staffNumber, string companyId)
        {
            var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.StaffNumber == staffNumber && x.CompanyId == companyId).FirstOrDefault();
            var oStaffModel = _mappingHelper.Map<StaffVM>(oStaffProfile);
            return oStaffModel;
        }

        public StaffVM GetByDesignation(string designation, string companyId)
        {
            var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.Designation == designation && x.CompanyId == companyId).FirstOrDefault();
            var oStaffModel = _mappingHelper.Map<StaffVM>(oStaffProfile);

            return oStaffModel;
        }


        public List<StaffVM> GetList(string companyId)
        {
            var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
            var oStaffModel = _mappingHelper.Map<List<StaffVM>>(oStaffProfile);
            return oStaffModel;
        }

        public List<AssignStaffVM> GetListForAssignment(string companyId)
        {
            var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
            var oStaffModel = _mappingHelper.Map<List<AssignStaffVM>>(oStaffProfile);
            return oStaffModel;
        }

        public int Update(StaffVM oStaffVM)
        {
            var modifiedStaff = _mappingHelper.Map<Staff>(oStaffVM);
            var originalStaff = _staffRepo.Find(modifiedStaff.StaffId);
            originalStaff.Designation = modifiedStaff.Designation;
            originalStaff.EmailAddress = modifiedStaff.EmailAddress;
            originalStaff.FirstName = modifiedStaff.FirstName;
            originalStaff.FullName = modifiedStaff.FullName;
            originalStaff.LastName = modifiedStaff.LastName;
            originalStaff.PhoneNumber = modifiedStaff.PhoneNumber;
            originalStaff.StaffId = modifiedStaff.StaffId;
            originalStaff.StaffNumber = modifiedStaff.StaffNumber;

            _staffRepo.Edit(originalStaff, GetType().Name);

            return unitOfWork.SaveChanges();
        }
    }
}
