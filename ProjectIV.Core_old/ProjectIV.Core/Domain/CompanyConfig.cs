using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Domain
{
  public  class CompanyConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyConfigId { get; set; }
        public int CompanyId { get; set; }
        public string ConfigValues { get; set; }
        private DateTime DateCreated { get { return DateTime.Now; }  }
    }
}
