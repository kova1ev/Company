# Company

## Local Run

1. Create database ms sql local db from migrations. From solution root dir run command: 
```bash
dotnet ef database update --startup-project backend/company.api --project backend/company.data
```
2. Run api server:
```bash
dotnet run --project .\Backend\Company.Api\
```

3. Run [angular project](/frontend/company/README.md) from solution root dir `cd frontend/company` and run: 
```bash
ng serve --open
```

Required:
- angular 16
- npm
- dotnet 6
- dotnet ef
- mssql server( localdb)
