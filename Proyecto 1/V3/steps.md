
**Asegurar que postgres se encuentre en ejecución**
```powershell
docker ps
```

**Crea web api
```powershell
dotnet new webapi -o webapi
cd webapi
```powershell

**Instala nugets de EF, para inicializar el contexto
```powershell
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
```

**Crea el modelo en codigo C# a partir de la base de postgresql
```powershell
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=mi_proyecto;Username=postgres;Password=contraseña" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models
```