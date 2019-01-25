using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.AppCore
{
    public class Customer
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PhoneNumber PrimaryPhoneNumber { get; set; }
        public ICollection<PhoneNumber> SecondaryPhoneNumbers { get; set; } = new List<PhoneNumber>();
        public Email PrimaryEmailAddress { get; set; }
        public ICollection<Email> SecondaryEmailAddresses { get; set; } = new List<Email>();
    }
}
