# Test Plan

## Feature Under Test
Appointment Cancellation — allows staff to cancel an existing appointment

## Test Objective
To confirm that the appointment when cancled will be removed from the system, the doctors slot will be released and you cannot re cancel or cancel an non existing appointment.

## Requirements to be Tested
- REQ-CAN-01: The system should allow an existing appointment to be cancelled.
- REQ-CAN-02: When an appointment is cancelled, the doctor's available slot should open.
- REQ-CAN-03: The system should not allow cancellation of an already-cancelled appointment or a non-existing appointment, and should throw an appropriate exception.

## Test Items
- `Appointment` class (Cancel method, IsCancelled state)
- `AppointmentBookingService.CancelAppointment()` method
- `Doctor.ReleaseSlot()` method

## Test Approach
unit tests following the same approach from week 1-2, each requirment will be covered by at keast one test case to confirm no fuctionality breaks.

## Test Data
- A valid `Doctor` with available slots (e.g. "D001", "Dr Mark", 2 slots)
- A valid `Patient` (e.g. "P001", "Diana William")
- A confirmed `Appointment` created via a successful booking
- A `null` appointment reference (for invalid input testing)
- An already-cancelled `Appointment` (to test double-cancellation handling)

## Responsibilities
I am responsivle for writing the methods and test cases for the appointment class and cancel appointment method in the booking service class.

## Schedule
Cancellation feature and tests to be implemented and passing within the 
current lab session (Week 3), prior to the Test Summary Report being written.

## Pass and Fail Criteria
- **Pass**: All cancellation test cases execute successfully with the 
  expected outcome (e.g. `IsCancelled` becomes true, slot count increases by 
  one, exceptions are thrown for invalid input).
- **Fail**: Any test case produces an unexpected result, an unhandled 
  exception occurs on valid input, or slot counts become incorrect after 
  cancellation.

## Risks
| Risk | Mitigation |
|---|---|
| Cancelling an already-cancelled appointment could throw an unhandled or 
unclear exception | Explicitly test and handle this case (`InvalidOperationException` with a clear message) |
| Slot release logic could increase slots beyond the doctor's original 
capacity if called incorrectly | Add a test verifying slot count matches expected value, not just "increased" |
| Passing a `null` appointment could cause a `NullReferenceException` instead 
of a controlled error | Explicitly validate for null and throw `ArgumentNullException` |