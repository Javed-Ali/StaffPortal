# Staff Portal Application

This repository contains a simple Staff Portal application built with .NET Core 6 and ReactJS.

## Setup Instructions

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com/) (or [Yarn](https://yarnpkg.com/))
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Getting Started
Backend Setup:

    Open StaffPortal.Server solution in Visual Studio 2022 (or use Visual Studio Code).
    Update the database connection string in appsettings.json or appsettings.Development.json under StaffPortal.Server project.
"ConnectionStrings": {
    "DefaultConnection": "SET YOUR CONNECTION STRING HERE"
}

    Run the following commands in Package Manager Console (PMC) to apply migrations and seed the database. Migrations folder has the schema and seed data and will populate the db for you:

Update-Database


Frontend Setup:

    Navigate to the StaffPortal.client directory.
    Install dependencies:

npm install

    Create a .env file in the StaffPortal.client directory with the following content:
VITE_API_BASE_URL=YOUR_LOCAL_HOST_URL_HERE

Additional Notes

    Seeders: Seed data is automatically applied when running Update-Database.
    Environment Variables: Modify .env file for different environment configurations.
