using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSE707_AppointmentBooking
{
    public class AppointmentRequest
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}
