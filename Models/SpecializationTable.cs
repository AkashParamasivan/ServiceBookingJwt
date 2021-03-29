using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceBookingJwt.Models
{
    public partial class SpecializationTable
    {
        public SpecializationTable()
        {
            SpecificationTables = new HashSet<SpecificationTable>();
            UserServiceInfos = new HashSet<UserServiceInfo>();
        }

        public string Name { get; set; }

        public virtual ICollection<SpecificationTable> SpecificationTables { get; set; }
        public virtual ICollection<UserServiceInfo> UserServiceInfos { get; set; }
    }
}
