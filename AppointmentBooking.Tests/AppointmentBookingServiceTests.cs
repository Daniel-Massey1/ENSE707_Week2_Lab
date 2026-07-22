using AppointmentBooking;
using ENSE707_AppointmentBooking;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ENSE707_AppointmentBooking.Tests;

[TestClass]
public class AppointmentBookingServiceTests
{
    [TestMethod]
    public void BookAppointment_WhenDoctorHasAvailableSlots_ReturnsSuccess()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        Assert.IsTrue(result.Success);
    }

    [TestMethod]
    public void BookAppointment_WhenDoctorHasNoAvailableSlots_ReturnsFailure()
    {
        var doctor = new Doctor("D001", "Dr Mark", 0);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    public void BookAppointment_WhenSuccessful_DecreasesAvailableSlots()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        service.BookAppointment(request);

        Assert.AreEqual(1, doctor.AvailableSlots);
    }

    [TestMethod]
    public void BookAppointment_WhenFailed_DoesNotDecreaseAvailableSlots()
    {
        var doctor = new Doctor("D001", "Dr Mark", 0);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        service.BookAppointment(request);

        Assert.AreEqual(0, doctor.AvailableSlots);
    }

    [TestMethod]
    public void Doctor_WhenIdIsEmpty_ThrowsException()
    {
        Assert.ThrowsExactly<ArgumentException>(() =>
            new Doctor("", "Dr Mark", 2));
    }

    [TestMethod]
    public void Doctor_WhenAvailableSlotsIsNegative_ThrowsException()
    {
        Assert.ThrowsExactly<ArgumentException>(() =>
            new Doctor("D001", "Dr Mark", -1));
    }

    [TestMethod]
    public void Patient_WhenIdIsEmpty_ThrowsException()
    {
        Assert.ThrowsExactly<ArgumentException>(() =>
            new Patient("", "Diana William"));
    }

    [TestMethod]
    public void Patient_WhenPreferredNameExists_DisplayNameUsesPreferredName()
    {
        var patient = new Patient("P001", "Diana William", "Aroha");
        Assert.AreEqual("Aroha", patient.DisplayName);
    }

    [TestMethod]
    public void Patient_WhenPreferredNameMissing_DisplayNameUsesLegalName()
    {
        var patient = new Patient("P001", "Diana William");
        Assert.AreEqual("Diana William", patient.DisplayName);
    }

    [TestMethod]
    public void AppointmentRequest_WhenRequestedDateIsInPast_ThrowsException()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");

        Assert.ThrowsExactly<ArgumentException>(() =>
            new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(-1)));
    }

    [TestMethod]
    public void BookAppointment_WhenSuccessful_ReturnsHelpfulMessage()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William", "Aroha");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        StringAssert.Contains(result.Message, "Appointment booked successfully");
        StringAssert.Contains(result.Message, "Aroha");
    }

    [TestMethod]
    public void BookAppointment_WhenNoSlots_ReturnsHelpfulMessage()
    {
        var doctor = new Doctor("D001", "Dr Mark", 0);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        StringAssert.Contains(result.Message, "no available slots");
    }
    [TestMethod]
    public void BookAppointment_ForToday_IsRejected()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today);

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        Assert.IsFalse(result.Success);
        StringAssert.Contains(result.Message, "one day's notice");
    }

    [TestMethod]
    public void BookAppointment_ForTomorrow_IsAccepted()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        Assert.IsTrue(result.Success);
    }

    [TestMethod]
    public void BookAppointment_WhenDailyLimitReached_IsRejected()
    {
        var doctor = new Doctor("D001", "Dr Mark", 20);
        var patient = new Patient("P001", "Diana William");
        var service = new AppointmentBookingService();

        // Book up to the daily limit first
        for (int i = 0; i < Doctor.MaxDailyAppointments; i++)
        {
            var fillerRequest = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));
            service.BookAppointment(fillerRequest);
        }

        // This next booking should be rejected because the limit is reached
        var finalRequest = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));
        BookingResult result = service.BookAppointment(finalRequest);

        Assert.IsFalse(result.Success);
        StringAssert.Contains(result.Message, "maximum number of appointments");
    }

    [TestMethod]
    public void BookAppointment_Message_IncludesDoctorName()
    {
        var doctor = new Doctor("D001", "Dr Mark", 0);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        StringAssert.Contains(result.Message, "Dr Mark");
    }

    [TestMethod]
    public void BookAppointment_Message_IncludesPatientDisplayName()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William", "Aroha");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));

        var service = new AppointmentBookingService();
        BookingResult result = service.BookAppointment(request);

        StringAssert.Contains(result.Message, "Aroha");
    }

    [TestMethod]
    public void BookAppointment_ForToday_DoesNotDecreaseAvailableSlots()
    {
        var doctor = new Doctor("D001", "Dr Mark", 2);
        var patient = new Patient("P001", "Diana William");
        var request = new AppointmentRequest(patient, doctor, DateTime.Today);

        var service = new AppointmentBookingService();
        service.BookAppointment(request);

        Assert.AreEqual(2, doctor.AvailableSlots);
    }

    [TestMethod]
    public void BookAppointment_WhenDailyLimitReached_DoesNotDecreaseAvailableSlots()
    {
        var doctor = new Doctor("D001", "Dr Mark", 20);
        var patient = new Patient("P001", "Diana William");
        var service = new AppointmentBookingService();

        for (int i = 0; i < Doctor.MaxDailyAppointments; i++)
        {
            var fillerRequest = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));
            service.BookAppointment(fillerRequest);
        }

        int slotsBeforeRejectedBooking = doctor.AvailableSlots;

        var finalRequest = new AppointmentRequest(patient, doctor, DateTime.Today.AddDays(1));
        service.BookAppointment(finalRequest);

        Assert.AreEqual(slotsBeforeRejectedBooking, doctor.AvailableSlots);
    }
}