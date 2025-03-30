# Nile & Spice - Restaurant Website

## Overview
Nile & Spice is a fully functional restaurant website designed to provide a seamless experience for both customers and administrators. It offers an elegant and user-friendly interface where customers can explore Egyptian and oriental dishes, while administrators can efficiently manage menu items and employee records. The platform is built using **ASP.NET Core MVC** with a **Microsoft SQL Server** database, ensuring reliability and performance.

## Features

### 1. Admin Panel
- Add, edit, and remove menu items.
- Manage employee accounts (add, edit, remove employees).
- Secure login system to restrict admin access.

### 2. Customer Interface
- View the top three best-selling menu items.
- Explore the full menu with descriptions and prices.
- Read restaurant details and background information.

### 3. User Authentication
- Secure login system to differentiate between Admins, Employees, and Customers.
- Personalized access based on user roles.

## Installation

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/your-username/nile-and-spice.git
   cd nile-and-spice
   ```
2. **Build the Project:**
   - Open the solution in **Visual Studio**.
   - Restore NuGet packages.
   - Build the project.

3. **Set Up the Database:**
   - Ensure **Microsoft SQL Server** is installed and running.
   - Update the connection string in `appsettings.json`.
   - Run Entity Framework migrations:
     ```sh
     dotnet ef database update
     ```

4. **Run the Application:**
   ```sh
   dotnet run
   ```

## Technologies Used
- **Frontend:** HTML, CSS, JavaScript, Razor Views
- **Backend:** ASP.NET Core MVC
- **Database:** Microsoft SQL Server
- **Authentication:** Identity-based authentication

## Demo Video
If you’d like to see the website in action, check out this demo video:
[Watch the Demo Video](https://drive.google.com/file/d/1tgqR_lEjobYCgfCrgAqpBIPNL-c1FABL/view?usp=sharing)

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss the changes.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

---

Feel free to customize it based on your needs! 🚀
