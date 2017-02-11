using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Domain
{
  public class Billable : baseDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillableId { get; set; }
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public int StaffId { get; set; }
        public bool IsInvoiced { get; set; }
        public int Hrs { get; set; }
        public decimal TotalAmount { get; set; }
      
    }
}
