  
# Wait to be sure that SQL Server came up
sleep 90s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P K18922d1c5988903be3525c3b81a6561270c5daa0f5556981951b05150484fc1 -d master -i database.sql