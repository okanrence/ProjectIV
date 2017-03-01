using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Domain
{
    public class StaffGroup : baseDomain
    {
        public StaffGroup()
        {
            AssignedStaff = new List<Staff>();
            AssignedCases = new List<Case>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffGroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Staff> AssignedStaff { get; set; }
        public virtual ICollection<Case> AssignedCases { get; set; }


    }
}
