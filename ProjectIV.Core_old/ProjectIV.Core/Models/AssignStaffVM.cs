using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Models
{
    public class AssignStaffVM
    {
        public int staffId { get; set; }
        public string FullName { get; set; }
        public string StaffNumber { get; set; }
        public bool IsAssigned { get; set; }

    }
}
