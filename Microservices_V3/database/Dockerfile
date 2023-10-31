# Use the official Microsoft SQL Server image as a base image
FROM mcr.microsoft.com/mssql/server


# Set the environment variables for SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=administrator

# Create a directory and copy the SQL script
COPY ./Customer.sql /docker-entrypoint-initdb.d/ 

EXPOSE 1433

