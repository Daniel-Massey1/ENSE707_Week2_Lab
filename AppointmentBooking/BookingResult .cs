using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public class BookingResult
    {
        public bool Success { get; }
        public string Message { get; }
        public BookingResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
