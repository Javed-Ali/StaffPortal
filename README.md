
# Staff Portal Application

This repository contains a simple Staff Portal application built with .NET Core 6 and ReactJS.



## Prerequisites 
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com/) (or [Yarn](https://yarnpkg.com/))
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Getting Started

### Backend Setup

Open **StaffPortal** solution in Visual Studio 2022.
Update the database connection string in **appsettings.json** under **StaffPortal.Server project**.

```bash
"ConnectionStrings": {
    "DefaultConnection": "SET YOUR CONNECTION STRING HERE"
}
```

### Database Migrations
Run the following commands in Package Manager Console (PMC) to apply migrations and seed the database. Migrations folder has the schema and seed data and will populate the DB for you

```bash
ADD-MIGRATION init
UPDATE-DATABASE
```

### Front-End Setup
In a terminal navigate to the StaffPortal.client directory and run the following command to get all the relevant packages. 

```bash
npm install
```
Create a .env file in the StaffPortal.client directory and setup the url to connect to backend
```bash
VITE_API_BASE_URL=YOUR_LOCAL_HOST_URL_HERE
```


#### Packages used by the app:
- Tailwindcss - For styling (npm)
- Axios - For network calls (npm)
- Moq - For unit test (nuget)
- Entity Framework for .NET Core (nuget)
