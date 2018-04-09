# CRM Metrics

You are developing CRM Metrics system for software development company ThreeTrees. They need have UI to add their users and their metrics to the system. Afterwards they want to get statistic for best employees and worst ones that they will fire.

## Technology Stack

- ASP.NET Core
- Saritasa.Tools
- Bootstrap 4
- Microsoft SQL Server/PostgreSQL

## Domain Model

Here are main entites of application.

Employee
- Name
- Birthday
- Branch (Russia, USA, Kazahstan, Vietnam)

Employee Statistic
- Year (from 2000 till now)
- Month
- Employee (FK)
- Total tasks done
- Total hours billed
- Total coffee cups drunk
- Total Mortal Combat games played

## Business Requirements

1. For now no authorization required.
2. Users should be able to add/edit/remove employees.
3. Users should be able to add/edit/remove employee statistic.
4. For an employee only one year-month record should exists.
5. There should be special page with statistic to show (per selected year):
    - Best/worst employee by tasks done
    - Best/worst employee by hours billed
    - Total coffees drunk
    - Total Mortal Combat games played
6. If user tries to remove employee show alert. Remove his correspond data.

## UI Requirements

There are several screen should be available:

1. Screen where user can see the list of all employees. User can edit/remove there.
2. Screen to add/edit employee.
3. Screen to show the list of all statistic items. User can edit/remove there.
4. Screen to add new statistic item.
5. Screen to show overall statistic by year.

Other requirements:

1. Whole UI should be implemented using standard Bootstrap components with default theme.
2. Implement client side and server side validation.
3. All fields are required.

## Technical Requirements

1. The project must conform [general project structure](/docs/ProjectStructure.html).
2. Use Saritasa.Tools project and CQS architecture.

## Step 1

## Step 2

## Step 3
