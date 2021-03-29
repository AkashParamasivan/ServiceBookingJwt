using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceBookingJwt.Models
{
    public partial class SpecificationTable
    {
        public SpecificationTable()
        {
            UserServiceInfos = new HashSet<UserServiceInfo>();
        }

        public string Name { get; set; }
        public string SpecializationName { get; set; }

        public virtual SpecializationTable SpecializationNameNavigation { get; set; }
        public virtual ICollection<UserServiceInfo> UserServiceInfos { get; set; }
    }
}
