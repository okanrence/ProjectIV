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
            AddedStaff = new List<Staff>();
            AssignedCases = new List<Case>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffGroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Staff> AddedStaff { get; set; }
        public virtual ICollection<Case> AssignedCases { get; set; }


    }
}
