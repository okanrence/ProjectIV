using ProjectIV.Core.Domain;
//using ProjectIV.Core.Helpers;
using ProjectIV.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{

    public interface ICaseMappingServices
    {
        int Add(CaseMappingVM oCaseMappingVM);
        List<CaseMappingVM> GetListByCase(int caseId, int companyId);
        List<CaseMappingVM> GetListbyStaff(int staffId, int companyId);
        List<CaseMappingVM> GetList();
    }
    public class CaseMappingServices : BaseService, ICaseMappingServices
    {
        public int Add(CaseMappingVM oCaseMappingVM)
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetList()
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetListByCase(int caseId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<CaseMappingVM> GetListbyStaff(int staffId, int companyId)
        {
            throw new NotImplementedException();
        }
    }

}
