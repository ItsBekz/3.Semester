RESTORE DATABASE [CustomerDB] FROM DISK = '/tmp/Customer.bak'
WITH FILE = 1,
MOVE 'CustomerDB' TO '/var/opt/mssql/data/CustomerDB.mdf',
MOVE 'CustomerDB_log' TO '/var/opt/mssql/data/CustomerDB:log.ldf',
NOUNLOAD, REPLACE, STATS=5
GO