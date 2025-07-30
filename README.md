# EHotel Management System

A desktop-based hotel management system built using C# and ASP.NET Web Forms, designed to streamline room booking, check-in/out, and administrative operations. This system features secure login, role-based access control, and real-time room management via SQL Server integration.

---

## ✨ Features

- 🔐 **User Authentication:** Secure login system with role-based redirection (Admin & Staff)
- 🏨 **Room Management:** Add, edit, delete, and view room details using SQL-connected GridView
- 📋 **Guest Check-In/Out:** Manage customer records and reservation status (future extension)
- 🧩 **Modular UI:** ASP.NET Web Forms with validation and feedback
- 🛠 **Error Handling:** Robust exception handling for database operations

---

## 🛠 Tech Stack

- **Frontend:** ASP.NET Web Forms (ASPX)
- **Backend:** C# (.NET Framework)
- **Database:** SQL Server
- **IDE:** Visual Studio

---

## 🚀 How to Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/AnneHank520/EHotel-Management-System.git
   ```

2. **Open the solution:**
   - Open `EHotel_project.sln` with **Visual Studio**

3. **Set up database:**
   - Create a local SQL Server database
   - Update connection strings in `web.config` accordingly
   - Execute the SQL schema (if provided) to create necessary tables

4. **Run the project:**
   - Press `F5` or click “Start” in Visual Studio to launch the app

---

## 📁 Project Structure

```
EHotel-Management-System/
├── App_Data/                      # Local database files
├── Assets/                       # Static resources
│   ├── CSS/                      # Custom styles
│   ├── Images/                   # Image assets
│   └── Libraries/Bootstrap/      # Frontend framework
├── Models/
│   └── Functions.cs              # Utility functions and data operations
├── View/
│   ├── Admin/
│   │   ├── AdminMaster.Master    # Admin layout
│   │   ├── Categories.aspx       # Manage room categories
│   │   ├── Rooms.aspx            # Room CRUD interface
│   │   └── Users.aspx            # User account management
│   ├── Users/
│   │   ├── Booking.aspx          # Booking form
│   │   └── UserMaster.Master     # User layout
│   └── Login.aspx                # Login form + authentication logic
├── Global.asax                   # App lifecycle config
├── Web.config                    # App and DB configuration
├── packages.config               # NuGet dependencies
└── EHotel_project.sln            # Visual Studio solution file
```

---

## 📌 Notes

- This is a practice project for demonstrating desktop system design using ASP.NET.
- Extendable to support guest check-in/out, report generation, and payment systems.


