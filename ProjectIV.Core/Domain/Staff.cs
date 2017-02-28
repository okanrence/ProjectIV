using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Domain
{
   public class Staff : baseDomain
    {
        public Staff()
        {
            AssignedCases = new List<Case>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FullName  { get; set; }
        [MaxLength(20)]
        public string StaffNumber { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public string Designation { get; set; }
        public decimal BillingRate { get; set; }
        public string Password { get; set; }
        [MaxLength(1)]
        public string ProfileStatus { get; set; }
        [MaxLength(1)]
        public string ProfileType { get; set; }
        public virtual ICollection<Case> AssignedCases { get; set; }
        public virtual StaffGroup StaffGroup { get; set; }


    }
}
