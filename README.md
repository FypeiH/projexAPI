<img align="center" src="public/projex_white.svg" width="400" height="400"/>

# 🗃 ProjeX - Project Manager Tool

## License: MIT

### Technologies Used:
- **Frontend**: Angular, TypeScript
- **Backend**: C#, .NET Core
- **Database**: SQL Server (SSMS)
- **Containerization**: (none)
- **Web Server**: (none)
- **Documentation**: Swagger (for API documentation)

---

## 📖 Table of Contents
1. [📢 Introduction](#introduction)
2. [✨ Features](#features)
3. [🎯 Milestones](#milestones)
4. [💿 Installation](#installation)
5. [😎 Usage](#usage)
6. [🛠️ Contributing](#contributing)
7. [🎖️ License](#license)

---

## 📢 Introduction

ProjeX is an open-source application designed to help teams plan, track, and collaborate on projects. It provides a comprehensive set of features, including task management, team collaboration, and project tracking through an intuitive dashboard.

---

## ✨ Features
- **Dashboard**: Comprehensive view of all projects and tasks.
- **User Authentication**: Secure login and registration system.
- **Project Management**: Create, update, delete, and view projects.
- **Task Management**: Create, update, delete, and assign tasks.
- **Team Collaboration**: Add team members, assign roles, and collaborate.
- **Real-Time Updates**: Use WebSockets for real-time updates and notifications.
- **Customizable Workflows**: Create and manage custom workflows for different project types.
- **Reporting**: Generate reports on project progress and team performance.

---

## 🎯 Milestones
### User Authentication
- Register user
- Login
- Password reset
- Token-based authentication (JWT)
- User roles and permissions

### Project Management
- Create project
- Delete project
- Update project details
- View project dashboard

### Task Management
- Create task
- Delete task
- Update task
- Assign task to team members
- Track task progress

### Team Collaboration
- Add/remove team members
- Assign roles
- Real-time chat
- Notifications

### Reporting
- Generate project reports
- Team performance analytics

### Performance improvements
- Codebase refactoring

---

## 💿 Installation

### Prerequisites
- **Node.js** and **npm**
- **Angular CLI**
- **.NET Core SDK**
- **SQL Server and SSMS**

### Frontend Setup (Angular)
1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/projex.git
    ```

2. **Install dependencies**:
    ```bash
    npm install
    ```

3. **Run the Angular app**:
    ```bash
    ng serve
    ```

### Backend Setup (C# and ASP.NET Core)
1. **Navigate to the backend directory**:
    ```bash
    git clone https://github.com/yourusername/projex-api.git
    ```

2. **Install dependencies**:
    ```bash
    dotnet restore
    ```

3. **Set up the database**:
   - Open SQL Server Management Studio (SSMS).
   - Create a new database named `ProjexDB`.
   - Run the SQL scripts located in `(TODO)` to create the necessary tables.

4. **Set up environment variables**:
    Create an `appsettings.json` file in the backend root with the following:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ProjexDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
      },
      "JwtSettings": {
        "Secret": "your_jwt_secret",
        "Issuer": "your_issuer",
        "Audience": "your_audience"
      }
    }
    ```

5. **Run the server**:
    ```bash
    dotnet run
    ```

---

## 😎 Usage

1. **Access the Application**:
   Open your browser and navigate to `http://localhost:4200` for the frontend and `http://localhost:5000/swagger` for the backend API documentation.

2. **Register and Login**:
   Create a new account or login with your credentials.

3. **Create Projects and Tasks**:
   Start by creating a new project, then add tasks and assign them to team members.

4. **Collaborate**:
   Add team members, assign roles, and start collaborating on tasks. Use the chat feature for real-time communication.

---

## 🛠️ Contributing

We welcome contributions from the community. To contribute, follow these steps:

1. **Fork the repository**.
2. **Create a new branch** for your feature or bug fix:
   ```bash
   git checkout -b feature/(feature-name)
   ```
3. **Commit your changes**:
```bash
git commit -m "Add feature"
```
4. **Push to your branch**:
```bash
git push origin feature/(feature-name)
```
5. **Create a pull request**.
Please ensure your code follows the project's coding standards and passes all tests.

---

## 🎖️ License
This project is licensed under the MIT License. See the LICENSE file for details.


---

