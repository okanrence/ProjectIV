using ProjectIV.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Models
{
    
    public class ClientContactVM
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

    }
}
