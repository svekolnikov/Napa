# Product managment

## Usage
Install docker
```
https://docs.docker.com/desktop/install/windows-install/
```
Run command for running MS SQL Container
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pa$$w0rd" -p 1433:1433 --name mssql-container -h mssql-container -d mcr.microsoft.com/mssql/server:2019-latest
```
