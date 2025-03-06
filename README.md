# .NetCSharpBlazorBackFrontTodoTest

<p align="center">
  <img width="790" alt="image" src="https://github.com/user-attachments/assets/7c2a3553-1750-49da-8298-e84b0e73ad7e" />
</p>

# Blazor Todo App

This is a simple Todo application built with **Blazor** for the frontend and **ASP.NET Core** with **MongoDB** for the backend. The application allows you to create, read, update, and delete tasks. The frontend communicates with the backend API to manage the todo items.

## Features
- **CRUD Operations**: Create, Read, Update, and Delete Todo items.
- **MongoDB Integration**: Data is stored in a MongoDB database.
- **Blazor Frontend**: A responsive and interactive frontend built using Blazor components.

## Technologies Used
- **Frontend**: Blazor (C# and Razor components)
- **Backend**: ASP.NET Core Web API (TodoApp)
- **Database**: MongoDB
- **HTTP Client**: Blazor communicates with the API using HttpClient to perform CRUD operations.
- **Dependency Injection**: For better separation of concerns and service management.

## Project Structure

- **TodoApp**: Backend ASP.NET Core project with MongoDB integration.
- **BlazorApp**: Frontend Blazor project.

## Setup

### Backend Setup (ASP.NET Core with MongoDB - TodoApp)

1. Clone the repository:
    ```bash
    git clone https://github.com/ocean2024D/.NetCSharpBlazorBackFrontTodoTest.git
    ```

2. Navigate to the `TodoApp` folder:
    ```bash
    cd TodoApp
    ```

3. Install MongoDB driver by running:
    ```bash
    dotnet add package MongoDB.Driver
    ```

4. Add your MongoDB connection string to the `appsettings.json` file:
    ```json
    {
      "MongoDbConnection": "mongodb://localhost:27017"
    }
    ```

5. Run the API:
    ```bash
    dotnet run
    ```

   The backend API will be running on `http://localhost:5172`.

### Frontend Setup (Blazor - BlazorApp)

1. Navigate to the `BlazorApp` folder:
    ```bash
    cd BlazorApp
    ```

2. Install the necessary dependencies:
    ```bash
    dotnet restore
    ```

3. Run the Blazor app:
    ```bash
    dotnet run
    ```

   The Blazor app will be running on `http://localhost:5172`.

## API Endpoints

Here are the API routes available for performing CRUD operations on Todo items:

- **GET `/api/todos`**: Retrieves all Todo items.
  
- **GET `/api/todos/{id}`**: Retrieves a specific Todo item by its `id`.
  
- **POST `/api/todos`**: Creates a new Todo item.
  
- **PUT `/api/todos/{id}`**: Updates an existing Todo item by its `id`.
  
- **DELETE `/api/todos/{id}`**: Deletes a Todo item by its `id`.

## .gitignore

For both the frontend and backend, the `.gitignore` files are configured to ignore unnecessary files such as build artifacts and sensitive data like connection strings.

## Contributing

Feel free to fork this project, create a pull request, or open an issue if you encounter any bugs or have suggestions for improvements.

---

### Note:
Replace the URLs and sensitive information as needed, especially MongoDB connection strings.
