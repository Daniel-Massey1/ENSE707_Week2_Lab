# Test Summary Report

## 1. Summary
Testing was carried out on the Appointment Booking System, covering the 
existing booking functionality from Week 2 and the new appointment 
cancellation feature added in Week 3. All planned test cases were executed 
using MSTest via Visual Studio Test Explorer.

## 2. Features Tested
- Doctor, Patient, AppointmentRequest, and BookingResult validation logic
- Appointment booking (success and all rejection paths)
- Appointment cancellation (REQ-CAN-01, REQ-CAN-02, REQ-CAN-03)
- Doctor slot reservation and release

## 3. Features Not Tested
- UI (none exists — this is a class library/console-level system)
- Persistence/database storage (not implemented)
- Concurrent/multi-user booking scenarios

## 4. Test Environment
Visual Studio 2026, .NET 8.0 SDK, MSTest framework, run locally via Test 
Explorer.

## 5. Test Results

| Test Area | Number of Tests | Passed | Failed | Notes |
|---|---|---|---|---|
| Booking tests | 19 | 19 | 0 | Existing tests passed |
| Cancellation tests | 5 | 5 | 0 | New feature passed |
| **Total** | **24** | **24** | **0** | |

## 6. Defects Found
None. All tests passed successfully, including edge cases for cancellation

## 7. Defects Fixed
None. No defects were found during testing.

## 8. Known Issues
- Namespace inconsistency: BookingResult sits in the `AppointmentBooking` 
  namespace while other classes sit in `ENSE707_AppointmentBooking`. This is 
  not a functional defect but should be cleaned up for consistency.

## 9. Release Recommendation
Recommended for demonstration.

## 10. Lessons Learned
No defects were found, which shows that planning the test cases before 
writing the cancellation feature helped prevent problems rather than fix 
them afterwards. Keeping BookingResult backward compatible also meant the 
existing tests kept passing without changes. Writing tests before the code 
is something worth doing again in future labs.