# Project

This project is a C# application that utilizes Entity Framework Core for data access and management. It is structured into several layers, including Application, Infrastructure, and the main entry point.

## Prerequisites

Before you begin, ensure you have the following installed on your computer:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html)

## Getting Started

Follow these steps to set up and run the project:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/your-repo.git
    cd your-repo
    ```

2. **Restore the NuGet packages**:
    ```bash
    dotnet restore
    ```

3. **Run the migrations to set up the database**:
    ```bash
    dotnet ef migrations add InitialCreate --output-dir src/Infrastructure/Database/Migrations
    dotnet ef database update
    ```

4. **Seed the database with example data**:
    - The seeding is handled automatically in the `OnModelCreating` method of `ApplicationDbContext`.

5. **Run the tests**:
    ```bash
    dotnet test
    ```

6. **Build the project**:
    ```bash
    dotnet build
    ```

7. **Run the application**:
    ```bash
    dotnet run
    ```

## Project Structure

- **src**
  - **Infrastructure**
    - **Repositories**
      - `LoanApplicationRepository.cs`: Contains methods for CRUD operations on the Application table.
    - **Database**
      - `RelationalDbContext.cs`: Configures the database context and DbSet properties for the models.
      - **Migrations**: Contains migration files for managing database schema changes.
      - **Seeds**
        - `OfferSeed.cs`: Seeds example data into the Offer and Application table.
        - `FeatureFlagsSeed.cs`: Seeds example data into the FeatureFlags table.
    - **Models**
      - `Offer.cs`: Represents the Offer model.
      - `Application.cs`: Represents the Application model.
      - `FeatureFlags.cs`: Represents the FeatureFlags model.
  - `Program.cs`: Entry point of the application.

## Database Tables

The project includes the following tables:

- **Offer**: Stores information about offers.
- **Application**: Stores application data with properties such as UserId and Status.
- **FeatureFlags**: Manages feature toggles for the application.

## Explanation of Build and Test Process

### Build

The build process compiles the application and ensures that all dependencies are correctly referenced and that there are no syntax errors. This step is crucial to ensure that the application can run without issues.

To build the project, run:
```bash
dotnet build