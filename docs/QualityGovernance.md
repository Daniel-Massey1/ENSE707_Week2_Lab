## Quality Governance Rules

| Governance Area | Rule | Evidence |
|---|---|---|
| Requirements | Each new feature must have at least one requirement ID | Requirements list |
| Testing | Each requirement must have at least one test case | Traceability matrix |
| Code quality | Code must pass all unit tests before commit | Test results |
| GitHub | Each student must commit meaningful work regularly | Git history |
| AI use | Copilot suggestions must be reviewed and tested | AI reflection notes |
| Defects | Defects must be recorded with status and severity | Defect log |
| Release | A feature can only be released if exit criteria are met | Test summary report |

These rules support quality governance by making sure that decisions about 
the project — like whether a feature is "done" or "ready to release" — are 
based on evidence rather than assumptions. Requiring requirement IDs and 
matching test cases means nothing gets built without a clear reason and a 
way to check it works. Requiring tests to pass before committing, and 
recording defects with severity, keeps the codebase in a known, trustworthy 
state at every point in its history rather than only at the end.

## Defect Log

| Defect ID | Description | Severity | Status | Found In | Fixed In |
|---|---|---|---|---|---|
| DEF-001 (sample) | Example: Slot count did not increase after cancellation | High | Fixed | Cancellation test | Updated CancelAppointment method |