using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSE707_AppointmentBooking
{
    public class Doctor
    {
        public const int MaxDailyAppointments = 8;

        public string Id { get; }
        public string FullName { get; }
        public int AvailableSlots { get; private set; }
        public int AppointmentsBookedToday { get; private set; }

        public Doctor(string id, string fullName, int availableSlots)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Doctor ID is required.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Doctor name is required.");

            if (availableSlots < 0)
                throw new ArgumentException("Available slots cannot be negative.");

            Id = id;
            FullName = fullName;
            AvailableSlots = availableSlots;
            AppointmentsBookedToday = 0;
        }

        public bool HasAvailableSlot()
        {
            return AvailableSlots > 0;
        }

        public bool HasReachedDailyLimit()
        {
            return AppointmentsBookedToday >= MaxDailyAppointments;
        }

        public void ReserveSlot()
        {
            if (!HasAvailableSlot())
                throw new InvalidOperationException("No appointment slots are available.");

            if (HasReachedDailyLimit())
                throw new InvalidOperationException("Maximum daily appointments reached.");

            AvailableSlots--;
            AppointmentsBookedToday++;
        }
        public void ReleaseSlot()
        {
            // Releasing a slot gives one back to the doctor's availability,
            // used when an appointment is cancelled.
            AvailableSlots++;
        }
    }
}