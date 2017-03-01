using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Domain
{
    public class CaseAssignment : baseDomain
    {
        public CaseAssignment()
        {
            AssignedStaff = new List<Staff>();
            CasesAssigned = new List<Case>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseAssignmentId { get; set; }
        public int AssignmentType { get; set; }

        public virtual ICollection<Staff> AssignedStaff { get; set; }
        public virtual ICollection<Case> CasesAssigned { get; set; }
        public virtual StaffGroup AssignedStaffGroup { get; set; }


    }
}
