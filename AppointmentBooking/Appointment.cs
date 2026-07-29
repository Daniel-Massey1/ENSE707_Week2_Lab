using System;

namespace ENSE707_AppointmentBooking
{
    public class Appointment
    {
        public string Id { get; }
        public Doctor Doctor { get; }
        public Patient Patient { get; }
        public DateTime AppointmentDate { get; }
        public bool IsCancelled { get; private set; }

        public Appointment(string id, Doctor doctor, Patient patient, DateTime appointmentDate)
        {
            // Validate that the appointment has a valid ID before anything else.
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Appointment ID is required.");

            // Doctor and Patient must exist - an appointment can't be created without both.
            Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));

            Id = id;
            AppointmentDate = appointmentDate;
            IsCancelled = false;
        }

        public void Cancel()
        {
            // Prevent cancelling an appointment that has already been cancelled,
            // which would otherwise silently do nothing or corrupt slot counts
            // if Cancel() were called twice.
            if (IsCancelled)
                throw new InvalidOperationException("Appointment has already been cancelled.");

            IsCancelled = true;
        }
    }
}