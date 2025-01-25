# My C# Project

This project is a C# application that utilizes Entity Framework Core for data access and management. It is structured into several layers, including Application, Infrastructure, and the main entry point.

## Project Structure

- **src**
  - **Infrastructure**
    - **Repositories**
      - `ApplicationLoanRepository.cs`: Contains methods for CRUD operations on the Application table.
    - **Database**
      - `ApplicationDbContext.cs`: Configures the database context and DbSet properties for the models.
      - **Migrations**: Contains migration files for managing database schema changes.
      - **Seeds**
        - `OfferSeed.cs`: Seeds example data into the Offer table.
        - `ApplicationSeed.cs`: Seeds example data into the Application table.
        - `FeatureFlagsSeed.cs`: Seeds example data into the FeatureFlags table.
    - **Models**
      - `Offer.cs`: Represents the Offer model.
      - `Application.cs`: Represents the Application model.
      - `FeatureFlags.cs`: Represents the FeatureFlags model.
  - `Program.cs`: Entry point of the application.
  - `Startup.cs`: Configures services and the application's request pipeline.

## Database Tables

The project includes the following tables:

- **Offer**: Stores information about offers.
- **Application**: Stores application data with properties such as UserId and Status.
- **FeatureFlags**: Manages feature toggles for the application.

## Getting Started

1. Clone the repository.
2. Restore the NuGet packages.
3. Update the connection string in `appsettings.json`.
4. Run the migrations to set up the database.
5. Seed the database with example data.

