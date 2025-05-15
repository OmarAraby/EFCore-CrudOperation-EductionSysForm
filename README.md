# EducationSysForm 📚

![.NET](https://img.shields.io/badge/.NET-Framework%209.0-blue)
![EF Core](https://img.shields.io/badge/Entity%20Framework-Core%209.3-brightgreen)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)


**A Dynamic Educational Management System Built with EF Core and Windows Forms**

Welcome to **EducationSysForm**, a robust desktop application designed to streamline the management of educational data with an intuitive and interactive user interface. Built using **Entity Framework Core** and **Windows Forms**, this project offers full CRUD operations for entities such as Students, Courses, Departments, and Course Sessions, all while adhering to modern software development practices.

This project was developed as part of my journey to create efficient and user-friendly applications, with a focus on integrating branding elements from the **Information Technology Institute (ITI)**

---

## 🌟 Features

- **Dynamic Form Generation**: Automatically generates input forms for any entity using reflection, minimizing repetitive code.
- **Full CRUD Operations**: Create, Read, Update, and Delete records seamlessly for Students, Courses, Departments, Instructors, Course Sessions, and more.
- **Interactive UI**: Custom-designed interface with:
    - Tabbed navigation for easy access to different entities.
    - Hover effects, tab animations, and a clean layout for a polished user experience.
- **Entity Framework Core Integration**: Efficient database operations with a code-first approach, supporting complex relationships like composite keys (e.g., `CourseStudent`).
- **Data Validation**: Ensures required fields are filled and validates specific rules (e.g., Course Session dates must be today or in the future).
- **Custom Styling**: Tailored DataGridView and controls with ITI’s branding for a professional look.

---

## 🛠️ Installation

### Prerequisites

- **.NET Framework** (version 9 or higher)
- **SQL Server** (or any database compatible with EF Core)
- **Visual Studio** (2022 or later recommended)

### Steps

1. **Clone the Repository**:
    
    ```bash
    git clone https://github.com/OmarAraby/EFCore-CrudOperation-EductionSysForm.git
    cd EFCore-CrudOperation-EductionSysForm
    ```
    
2. **Set Up the Database**:
    
    - Update the connection string in `appsettings.json` or your configuration file to point to your SQL Server instance.
    - Run the following commands in the Package Manager Console to apply migrations:
        
        ```bash
        Update-Database
        ```
        
3. **Build and Run**:
    
    - Open the solution (`EducationSysProject.sln`) in Visual Studio.
    - Build the project (Ctrl+Shift+B).
    - Run the application (F5).

---

## 🚀 Usage

1. **Launch the Application**:
    
    - Upon running, you’ll see the main interface with the ITI logo at the top and a tabbed layout for different entities (Students, Courses, etc.).
2. **Navigate Tabs**:
    
    - Click on a tab (e.g., "Courses") to view its records in the DataGridView.
    - The form on the left dynamically updates to show fields for the selected entity.
3. **Perform CRUD Operations**:
    
    - **Create**: Fill the form and click "Save" to add a new record.
    - **Read**: Select a record from the DataGridView to populate the form with its data.
    - **Update**: Edit the form fields and click "Save" to update the record.
    - **Delete**: Select a record and click "Delete" to remove it (disabled by default until a record is selected).
4. **Special Handling for CourseStudent**:
    
    - Due to the composite key (`CourseID`, `StudentID`), updating a `CourseStudent` record will delete the old record and create a new one with the updated values.

---

## 📸 Screenshots

### Main Interface
![image](https://github.com/user-attachments/assets/c38643e2-ec36-4253-8cfe-f63d687f3a97)
![image](https://github.com/user-attachments/assets/015ca0a8-41de-451f-9cb5-b493abd93d99)


_The main interface with  tabbed navigation._

### Course Tab
![image](https://github.com/user-attachments/assets/a24715f8-e690-46e6-8035-025c53fbf7fe)

_Dynamic form for managing courses with a styled DataGridView._



---

## 🧩 Project Structure

- **EducationSysProject.Data**: Contains the EF Core context, models, and migrations.
- **EducationSysProject.Services**: Includes the `DynamicFormService` for generating forms and handling form data.
- **EducationSysProject**: The main application with `MainForm.cs` for the UI and business logic.
- **UnitOfWork**: Implements the Unit of Work pattern for repository management.

---

## 🤝 Contributing

Contributions are welcome! If you’d like to improve this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Make your changes and commit (`git commit -m "Add your feature"`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a Pull Request.

---

## 📜 License

This project is licensed under the MIT License 

---

## 📬 Contact

Feel free to reach out if you have questions or suggestions!

- **GitHub**: [OmarAraby](https://github.com/OmarAraby)
- **LinkedIn**: [OmarAraby](https://linkedin.com/in/omar-araby)

---

**Built with ❤️ by Omar Araby**  
Let’s make educational management smarter and more intuitive! 🚀
