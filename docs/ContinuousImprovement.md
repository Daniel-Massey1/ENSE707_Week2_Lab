# Continuous Improvement

## What Worked Well
Writing the test plan before implementing the cancellation feature made the 
edge cases (null appointments, double cancellation, slot release) clear 
before any code was written. Keeping BookingResult backward compatible, 
rather than changing its structure, meant all 19 existing tests kept passing 
without any changes needed.

## What Did Not Work Well
Early on, the solution was opened as a folder instead of through the .slnx 
file, which meant Visual Studio couldn't properly load project references 
and Test Explorer couldn't discover any tests. This wasted time before the 
actual cause (opening the wrong entry point) was identified.

## Root Cause of One Issue
The root cause of the test discovery failure was opening the repository as a 
plain folder rather than opening the .slnx solution file directly, combined 
with a missing .NET SDK version on a freshly set up machine. Both issues 
looked like the code itself was broken, when actually the environment/setup 
was the problem.

## Improvement Action
Always open the project through its .slnx (or .sln) file rather than the 
folder, and check that the required .NET SDK version is installed before 
assuming test or build failures are caused by the code.

## How We Will Check the Improvement
Confirm Test Explorer successfully discovers and runs all tests immediately 
after opening the solution on any machine, before making any code changes, 
as a quick environment sanity check.

## Quality Culture Reflection
Reviewing requirements and writing tests early helps prevent defects rather 
than catching them afterwards. Committing regularly keeps a clear record of 
how the project changed over time. Test results give real evidence for 
release decisions instead of assumptions. Even working alone, following a 
defined process reflects the same shared responsibility for quality a team 
would rely on. Going forward, writing test plans before implementation and 
keeping commits small and clear are the main improvements to carry on.

## Agile and DevOps Quality Practices for This Project

| Practice | How It Could Be Used in This Project |
|---|---|
| Sprint planning | Select a small set of features and quality tasks for the week, e.g. this week's sprint was the cancellation feature plus its documentation |
| Daily stand-up | Even working solo, a quick daily check-in on progress, blockers, and testing issues would help catch problems earlier |
| Definition of Done | A feature is only complete once it is coded, reviewed, tested, and documented — not just when the code compiles |	
| Continuous Integration | Automatically run the full test suite whenever code is pushed to GitHub, to catch regressions immediately |
| Regression testing | Re-run all existing tests after every change, as was done after adding the cancellation feature, to confirm nothing broke |
| Retrospective | Review what went well and what didn't at the end of each lab/sprint, such as the .slnx/SDK setup issue identified earlier |