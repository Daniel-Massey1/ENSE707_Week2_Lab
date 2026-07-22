using AppointmentBooking;
using ENSE707_AppointmentBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;


namespace ENSE707_AppointmentBooking
{
    public class AppointmentBookingService
    {
        public BookingResult BookAppointment(AppointmentRequest request)
        {
            if (request == null)
                return new BookingResult(false, "Appointment request is missing.");

            if (string.IsNullOrWhiteSpace(request.Patient.Id))
                return new BookingResult(false, "A valid patient ID is required to book an appointment.");

            if (request.RequestedDate.Date == DateTime.Today)
                return new BookingResult(false, "Appointments require at least one day's notice and cannot be booked for today.");

            if (request.Doctor.HasReachedDailyLimit())
                return new BookingResult(false, $"{request.Doctor.FullName} has reached the maximum number of appointments for today.");

            if (!request.Doctor.HasAvailableSlot())
                return new BookingResult(false, $"Appointment cannot be booked because {request.Doctor.FullName} has no available slots.");

            request.Doctor.ReserveSlot();

            return new BookingResult(true, $"Appointment booked successfully for {request.Patient.DisplayName} with {request.Doctor.FullName}.");
        }
    }
}
