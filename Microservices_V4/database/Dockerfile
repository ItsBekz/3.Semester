# Use the official Microsoft SQL Server image as a base image
FROM mcr.microsoft.com/mssql/server:2019-latest AS Build

# Set the environment variables for SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Password1

# Create a directory and copy the SQL script
WORKDIR /tmp
COPY CustomerDB.bak .
COPY restore-db.sql .

RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker Manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Password1" -i /tmp/restore-db.sql \
    && pkill sqlservr

FROM mcr.microsoft.com/mssql/server:2019-latest AS release
ENV ACCEPT_EULA=Y
COPY --from=Build /var/opt/mssql/data /var/opt/mssql/data