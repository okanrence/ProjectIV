using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Models
{
    public class Enums
    {
        public enum Roles
        {
            SuperUser = 1,
            CompanyAdmin,
            Attorney,
            CompanyHead
        }

        public enum CaseStatus
        {
            Open = 1,
            Closed,
            Suspended
        }

        public enum CaseTypes
        {
            Litigation = 1,
            Criminal_Law
        }

    }
}
