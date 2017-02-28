using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.ViewModels
{
    public class CaseAssignmentVM
    {
        public int CaseAssignmentId { get; set; }
        public int AssignmentType { get; set; }
        public virtual ICollection<StaffVM> AssignedStaff { get; set; }
        public virtual StaffGroupVM AssignedStaffGroup { get; set; }

    }
}
