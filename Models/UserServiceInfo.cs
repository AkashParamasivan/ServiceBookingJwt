using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceBookingJwt.Models
{
    public partial class UserServiceInfo
    {
        public UserServiceInfo()
        {
            BookingCustomers = new HashSet<Booking>();
            BookingServiceProviders = new HashSet<Booking>();
        }

        public string Usid { get; set; }
        public string Username { get; set; }
        public string Phoneno { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Specialization { get; set; }
        public string Specification { get; set; }
        public string ServiceCity { get; set; }
        public string Address { get; set; }
        public string Aadhaarno { get; set; }
        public string Role { get; set; }
        public int? Experience { get; set; }
        public int? Costperhour { get; set; }
        public int? Rating { get; set; }

        public virtual SpecializationTable SpecializationNavigation { get; set; }
        public virtual SpecificationTable SpecificationNavigation { get; set; }
        public virtual ICollection<Booking> BookingCustomers { get; set; }
        public virtual ICollection<Booking> BookingServiceProviders { get; set; }
    }
}
