using ENSE707_AppointmentBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ENSE707_AppointmentBooking
{
public class AppointmentBookingService
{
    public bool BookAppointment(AppointmentRequest request)
    {
        if (request.Doctor.AvailableSlots <= 0)
            return false;
        request.Doctor.AvailableSlots--;
        return true;
    }
}
}
