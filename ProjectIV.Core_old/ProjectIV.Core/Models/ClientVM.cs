using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Models
{
    public class ClientVM :BaseVM
    {
        public int ClientId { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientDisplayName { get { return $"{this.ClientNumber}-{this.ClientName}"; } }
        public string ClientAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string ClientEmailAddress { get; set; }
        public string OfficeEmailAddress { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string ClientType { get; set; }
        public string PaymentCurrency { get; set; }
        public string OtherDetails { get; set; }
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }
        public virtual List<ClientContactVM> ClientContacts { get; set; }

    }
}
