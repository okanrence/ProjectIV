using ProjectIV.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.ViewModels
{
    public class CaseVM : BaseVM
    {
        public int ClientId { get; set; }
        public int CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        public string CaseDescription { get; set; }
        public int CaseStatusId { get; set; }
        public string CaseStatusName { get; set; }
        public DateTime DateOpened { get; set; }
        public string CreatedBy { get; set; }

    }
}
