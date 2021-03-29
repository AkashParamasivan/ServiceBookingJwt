using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceBookingJwt.Models
{
    public partial class Booking
    {
        public int Bookingid { get; set; }
        public string CustomerId { get; set; }
        public string ServiceProviderId { get; set; }
        public DateTime? Servicedate { get; set; }
        public TimeSpan? Starttime { get; set; }
        public TimeSpan? Endtime { get; set; }
        public int? Estimatedcost { get; set; }
        public bool? Bookingstatus { get; set; }
        public bool? Servicestatus { get; set; }
        public int? Rating { get; set; }

        public virtual UserServiceInfo Customer { get; set; }
        public virtual UserServiceInfo ServiceProvider { get; set; }
    }
}
