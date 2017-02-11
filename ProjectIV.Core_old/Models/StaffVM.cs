using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Models
{
 //   [Serializable]
    public class StaffVM : BaseVM
    {
        public int StaffId { get; set; }
        public string StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
