# Practice_Project
#### Simple practice project for MedicalScan Kft.
This repository contains an ASP.NET 6 application with an integrated Angular frontend.
## Initial task:
Create a small web application that displays a list of products fetched from a local JSON file and allows users to perform basic CRUD (Create, Read, Update, Delete) operations on these products. The application should be built using .NET Core for the backend and Angular for the frontend.

Requirements:

- Backend (Using .NET Core):
        Set up a RESTful API using ASP.NET Core.
        Implement endpoints to perform CRUD operations on products (GET all products, GET a single product by ID, POST a new product, PUT to update a product, DELETE a product).
        Use in-memory storage or a simple JSON file to store and retrieve product data.
- Frontend (Using Angular):
        Create a single-page application (SPA) using Angular.
        Implement a component to display a list of products fetched from the backend API.
        Include functionality to add a new product.
        Implement a feature to edit existing products.
        Allow users to delete products.
- User Interface:
        Design a simple and responsive user interface using Angular Material or Bootstrap.
        Display a list of products with basic information (e.g., name, price).
        Include forms for adding/editing products with basic input fields (name, price).
        Provide basic error messages for validation and error scenarios.
- Additional Requirements:
        Use proper error handling.
        Write basic unit tests for at least one backend endpoint and one frontend component.

Submission Guidelines:

Create a repository and commit your code to the repository.
Provide a README.md file with brief instructions on how to build and run the application.

Note:

Focus on implementing core functionality and basic CRUD operations.
You may simplify the UI and skip advanced features like authentication and pagination.
The emphasis is on demonstrating your ability to work with .NET Core and Angular to build a functional web application.

## Build and run
Make sure you have the following installed on your machine:

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (Least version: 14.x)
- [Angular CLI](https://angular.io/cli)
- Git

1. Clone the repository:
   ```bash
   git clone https://github.com/nopizzaa/PracticeProjectMedicalScan.git
2. Navigate to the project directory.
3. Restore NuGet packages
   ```bash
   dotnet restore 
4. Run the server side application with:
   ```bash
   dotnet run --launch-profile PracticeProject
5. Navigate to the ClientApp directory.
6. Install the dependencies of frontend application
   ```bash
   npm install
7. After you can start it by simply run the following command:
   ```bash
   npm start
## Accessing Swagger

You can access the Swagger documentation for the API by navigating to the following URL:

- [Swagger (https://localhost:7015/swagger)](https://localhost:7015/swagger)
## Accessing Angular Frontend

To access the Angular frontend, open your web browser and navigate to the following URL:

- [Angular Frontend (https://localhost:44477)](https://localhost:44477)