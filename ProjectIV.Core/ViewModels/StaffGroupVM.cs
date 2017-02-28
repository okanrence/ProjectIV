using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.ViewModels
{
    public class StaffGroupVM
    {
        public int StaffGroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<StaffVM> AssignedStaff { get; set; }
        public virtual ICollection<CaseVM> AssignedCases { get; set; }

    }
}
