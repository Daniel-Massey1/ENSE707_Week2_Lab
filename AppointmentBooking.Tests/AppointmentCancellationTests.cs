using AppointmentBooking;
using ENSE707_AppointmentBooking;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ENSE707_AppointmentBooking.Tests;

[TestClass]
public class AppointmentCancellationTests
{
    [TestMethod]
    public void CancelAppointment_ExistingAppointment_MarksAppointmentAsCancelled()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var appointment = new Appointment("A001", doctor, patient, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        service.CancelAppointment(appointment);

        Assert.IsTrue(appointment.IsCancelled);
    }

    [TestMethod]
    public void CancelAppointment_ExistingAppointment_ReleasesDoctorSlot()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var appointment = new Appointment("A001", doctor, patient, DateTime.Today.AddDays(1));
        doctor.ReserveSlot(); // simulate the slot having been reserved at booking time

        var service = new AppointmentBookingService();
        service.CancelAppointment(appointment);

        Assert.AreEqual(2, doctor.AvailableSlots);
    }

    [TestMethod]
    public void CancelAppointment_NullAppointment_ThrowsException()
    {
        var service = new AppointmentBookingService();

        Assert.ThrowsExactly<ArgumentNullException>(() =>
            service.CancelAppointment(null));
    }

    [TestMethod]
    public void CancelAppointment_AlreadyCancelledAppointment_ThrowsException()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var appointment = new Appointment("A001", doctor, patient, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        service.CancelAppointment(appointment);

        Assert.ThrowsExactly<InvalidOperationException>(() =>
            service.CancelAppointment(appointment));
    }

    [TestMethod]
    public void BookAppointment_Success_ReturnsAppointmentWithCorrectDetails()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        Assert.IsNotNull(result.Appointment);
        Assert.AreEqual(doctor, result.Appointment.Doctor);
        Assert.AreEqual(patient, result.Appointment.Patient);
        Assert.AreEqual(request.RequestedDate, result.Appointment.AppointmentDate);
    }
}