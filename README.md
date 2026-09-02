Help Desk Management System

Help Desk Management System is a complete web application designed to streamline the management of 
departments, employees, and support tickets within an organization. This system provides an intuitive 
interface for administrators to efficiently handle support requests, track employee assignments, 
and maintain department records.

The application is built using modern Microsoft technologies including ASP.NET Core Web API for 
the backend, Blazor Server for the frontend, Entity Framework Core for database operations, 
and SQL Server as the database. The system follows a clean architecture with proper separation 
of concerns, making it scalable and maintainable.

Screenshots


Dashboard
<img width="1920" height="902" alt="image" src="https://github.com/user-attachments/assets/0f44f6c4-f8c4-44b6-a641-f3d6b895a42a" />


Department Management

<img width="1913" height="918" alt="image" src="https://github.com/user-attachments/assets/3c8f9294-174a-4c6d-b697-338ee09a766e" />

Employee Management

<img width="1878" height="912" alt="image" src="https://github.com/user-attachments/assets/8e7dcbd3-4ee7-461b-9901-7e56c5bc9976" />

Ticket Management
<img width="1908" height="902" alt="image" src="https://github.com/user-attachments/assets/955ff938-e0de-45a9-8c44-f0e0bb453dc0" />


Reports View
<img width="1900" height="921" alt="image" src="https://github.com/user-attachments/assets/2c1564a2-07e8-46fe-8a1e-3bd3e2349940" />



Features

- Department Management (Add, Edit, Delete, View)
- Employee Management (Add, Edit, Delete, View)  
- Ticket Management (Add, Edit, Delete, View)
- Dashboard with Real-time Statistics
- Reports View
- Modern UI with Bootstrap 5
- Responsive Design



Tech Stack


Backend:
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core 8.0.18
- SQL Server
- AutoMapper 12.0.1
- Swagger/OpenAPI 6.6.2

Frontend:
- Blazor Server (.NET 8)
- Bootstrap 5.1.0
- CSS Isolation



Installation


1. Clone the repository
   
   git clone https://github.com/umairasim52/HelpDeskManagementSystem.git
   cd HelpDeskManagementSystem

2. Update Connection String
   
   Open HelpDeskAPI/appsettings.json and update:
   "DefaultConnection": "Server=YOUR_SERVER;Database=TaskManagementDB;Trusted_Connection=True;"

3. Apply Database Migrations
   
   cd HelpDeskAPI
   dotnet ef database update

4. Run the API
   
   dotnet run
   API URL: https://localhost:7135
   Swagger: https://localhost:7135/swagger

5. Run the Blazor App
   
   cd HelpDeskBlazor
   dotnet run
   App URL: https://localhost:7177



API Endpoints


Departments:
- GET    /api/Departments          Get all departments
- POST   /api/Departments          Add department
- PUT    /api/Departments/{id}     Update department
- DELETE /api/Departments/{id}     Delete department

Employees:
- GET    /api/Employees            Get all employees
- POST   /api/Employees            Add employee
- PUT    /api/Employees/{id}       Update employee
- DELETE /api/Employees/{id}       Delete employee

Tickets:
- GET    /api/Tickets              Get all tickets
- POST   /api/Tickets              Add ticket
- PUT    /api/Tickets/{id}         Update ticket
- DELETE /api/Tickets/{id}         Delete ticket



Database Schema


Departments:
- Id (Primary Key)
- DepartmentName

Employees:
- Id (Primary Key)
- FullName
- Email
- Phone
- DepartmentId (Foreign Key -> Departments)

Tickets:
- Id (Primary Key)
- Title
- Description
- Priority
- Status
- CreatedDate
- EmployeeId (Foreign Key -> Employees)



Contact


Umair Asim
GitHub: https://github.com/umairasim52
