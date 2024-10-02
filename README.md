# Product Management Application

## Overview
This is a **Product Management Application** built using the **ASP.NET MVC** architecture. The app allows users to perform CRUD (Create, Read, Update, Delete) operations on products and manage product images. It leverages **Entity Framework** for database management and **SQL Server** for data storage.

## Features
- **CRUD Operations**: Users can add, edit, view, and delete products.
- **Image Upload**: Upload and store product images in the `wwwroot` directory.
- **Entity Framework Integration**: Simplified database interactions using Entity Framework with SQL Server.
- **MVC Architecture**: Separation of concerns with Models, Views, and Controllers.

## Technologies Used
- **ASP.NET Core MVC**: For building the web application.
- **Entity Framework Core**: ORM for interacting with the SQL Server database.
- **SQL Server**: Used as the relational database for managing product data.
- **Bootstrap**: For responsive UI design.
- **HTML5/CSS3/JavaScript**: For front-end development.
  
## Prerequisites
- **.NET SDK** (6.0 or later)
- **SQL Server** or **SQL Server Express**
- **Visual Studio** (2022 or later)
- **Entity Framework Core**

## Installation & Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/nadim0330/Dot-net-MVC-Product-Management.git
   ```

2. **Navigate to the project folder**:
   ```bash
   cd DotNetMVC-ProductManagement
   ```

3. **Restore NuGet packages**:
   Open the solution in Visual Studio, and it will automatically restore the necessary NuGet packages.

4. **Update the database connection string**:
   - Go to `appsettings.json` and update the connection string to point to your local SQL Server instance:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server-name;Database=ProductManagementDb;Trusted_Connection=True;"
     }
     ```

5. **Run Entity Framework Migrations**:
   To create the database and apply the initial schema, run the following commands in the Package Manager Console:
   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```

6. **Run the Application**:
   - Hit **F5** in Visual Studio or run the following in the terminal:
     ```bash
     dotnet run
     ```

7. **Access the Application**:
   The app will be available at `https://localhost:5001` (or a similar port).

## CRUD Operations
- **Create Product**: Add new products with details such as name, description, price, and upload a product image.
- **Read Products**: View the list of all products with pagination and search functionality.
- **Update Product**: Edit product details including replacing the product image.
- **Delete Product**: Remove a product from the database.

## Image Handling
Product images are stored in the `wwwroot/images` folder in the application. Upon uploading a product image, it is saved to this directory, and the image path is stored in the database.

## Database
The application uses **Entity Framework Core** to interact with an SQL Server database. The database consists of a `Product` table that stores information about each product, including:
- Product ID (Primary Key)
- Name
- Brand
- Category
- Description
- Price
- Image Path

## Screenshots

### Product List
![image](https://github.com/user-attachments/assets/d7a997ca-5ea5-49fd-afb0-cb2ccfa465b4)

### Add New Product
![image](https://github.com/user-attachments/assets/efe99e3c-3620-48b1-893b-2d621ed6b375)

### Edit Product
![image](https://github.com/user-attachments/assets/4f1c3086-59d0-45de-86aa-aa8679316a8b)

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request for any feature requests or improvements.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
