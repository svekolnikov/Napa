# Product managment

## Usage
Install docker
```
https://docs.docker.com/desktop/install/windows-install/
```
Run command for running MS SQL Container
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pa$$w0rd" -p 1434:1433 --name mssql-container-3 -h mssql-container -d mcr.microsoft.com/mssql/server:2019-latest
```
## Users
Role Admin
```
johnny.deep@company.com
```
```
AdminPa$$w0rd1
```
Role User
```
jack.sparrow@company.com
```
```
UserPa$$w0rd1
```
