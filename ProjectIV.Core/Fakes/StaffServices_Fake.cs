using MyAppTools.Helpers;
using ProjectIV.Core.Domain;
using ProjectIV.Core.Infrastructure;
using ProjectIV.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{

    public class StaffServices_Fake : IStaffServices
    {
        private readonly IRepository<Staff> _staffRepo;
        IMappingHelper _mappingHelper;
        public StaffServices_Fake()
        {
            _staffRepo = new CacheRepository<Staff>();
            _mappingHelper = new MappingHelper();
        }

        public int Add(StaffVM oStaffModel)
        {
            var oStaffProfile = _mappingHelper.Map<Staff>(oStaffModel);
            _staffRepo.Add(oStaffProfile, GetType().Name);
            return 1;
        }

        public StaffVM Authenticate(string emailaddress, string password)
        {
            StaffVM oStaffModel = null;
            try
            {
                var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.EmailAddress == emailaddress).FirstOrDefault();
                oStaffModel = _mappingHelper.Map<StaffVM>(oStaffProfile);
            }
            catch (Exception)
            {

            }
            return oStaffModel;
        }

        public StaffVM Get(string staffNumber, int companyId)
        {
            StaffVM oStaffModel = null;

            try
            {
                var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.StaffNumber == staffNumber && x.CompanyId == companyId).FirstOrDefault();
                oStaffModel = _mappingHelper.Map<StaffVM>(oStaffProfile);
            }
            catch (Exception)
            {

            }

            return oStaffModel;
        }

        public StaffVM GetByDesignation(string designation, int companyId)
        {
            StaffVM oStaffModel = null;
            try
            {
                var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.Designation == designation && x.CompanyId == companyId).FirstOrDefault();
                oStaffModel = _mappingHelper.Map<StaffVM>(oStaffProfile);
            }
            catch (Exception )
            {

            }

            return oStaffModel;
        }


        public List<StaffVM> GetList(int companyId)
        {
            List<StaffVM> oStaffModel = null;
            try
            {
                var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
                oStaffModel = _mappingHelper.Map<List<StaffVM>>(oStaffProfile);
            }
            catch (Exception)
            {

            }

            return oStaffModel;
        }

        public List<AssignStaffVM> GetListForAssignment(int companyId)
        {
            List<AssignStaffVM> oStaffModel = null;

            try
            {
                var oStaffProfile = _staffRepo.All(GetType().Name).Where(x => x.CompanyId == companyId).ToList();
                oStaffModel = _mappingHelper.Map<List<AssignStaffVM>>(oStaffProfile);
            }
            catch (Exception)
            {

            }
            return oStaffModel;
        }
    }
}
