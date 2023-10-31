# Use the official Microsoft SQL Server image as a base image
FROM mcr.microsoft.com/mssql/server

# Set the environment variables for SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=admin

# Create a directory and copy the SQL script
WORKDIR /docker-entrypoint-initdb.d
COPY Customer.sql .

# Expose the SQL Server port
EXPOSE 1433
