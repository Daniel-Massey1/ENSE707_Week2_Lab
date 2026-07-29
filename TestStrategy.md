# Test Strategy

## 1. Purpose
This document outlines the testingf stratergt for the Appointment booking system to ensure all features work as intended and meet the requirements.

## 2. Scope of Testing
- Doctor and patient validation (e.g. required fields, valid data formats)
- Appointment request validation (e.g. date/time, doctor availability, patient eligibility)
- Successful message when booking (either success ful or not)
- Booking logic including all invalid possibilities


## 3. Out of Scope
- UI/front-end testing 
- Performance/load testing
- Database 

## 4. Test Levels
- Unit tests: testing individual methods in Doctor, Patient, and Appointment classes
- Integration tests: AppointmentBookingService working together with Doctor, Patient, and AppointmentRequest objects
- System tests: testing the entire booking workflow end-to-end, including validation and business rules


## 5. Test Types
- Unit testing
- Integration testing
- System testing
- Regression testing (re-running existing tests after changes)
- Usability testing (basic — e.g. clarity of result messages)
- Validation testing (confirming business rules like notice period and daily limits are enforced)

## 6. Test Environment
- Local development machine running Visual Studio 2026
- .NET 8.0 SDK
- MSTest framework 

## 7. Tools
- Visual Studio Test Explorer
- MSTest 
- Git/GitHub for version control 
- GitHub Copilot (With all suggestions reviewd and understood/altered if need be before use)

## 8. Defect Management Approach
Defects found during testing are recorded in a defect log (see QualityGovernance.md) with a description, severity, status, where they were found, and how/where they were fixed. Defects are fixed and re-tested before being marked as closed.

## 9. Entry Criteria
- Code compiles with no build errors
- Requirements for the feature are documented (with requirement IDs)
- Test cases have been written for the new feature

## 10. Exit Criteria
- All planned test cases have been executed
- All high-severity defects are fixed and verified
- All MSTests pass 

## 11. Risks and Mitigation
| Risk | Mitigation |
|---|---|
| Incomplete requirements lead to missed test cases | Review requirements before writing tests |
| New features could break existing booking logic | Run full regression suite after every change |
| Over-reliance on AI-generated code/tests | Manually review and understand all Copilot suggestions before accepting |