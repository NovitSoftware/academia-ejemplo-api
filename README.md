# Academia Ejemplo WEB API

## Instalación Entity Framework Core

- Abrir el **CMD** o **Simbolo de Sistema** ejecutar el siguiente comando

```
dotnet tool install --global dotnet-ef
```

## Instalar Paquetes Nuget

- En el proyecto instalar los siguientes paquetes Nuget (para todos instalar la version **6.0.13**)
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.EntityFrameworkCore.SqlServer

## Appsettings

- Configurar **ConnectionString** en el archivo **appsettings.json**

```json
"ConnectionStrings": {
    "ITEM_DB" : "server=IP_SERVIDOR_DB;database=NOMBRE_BD;user=USUARIO;password=CONTRASEÑA"
  }
```

Con la configuracion actual

```json
"ConnectionStrings": {
    "proyecto_db" : "Server=localhost;Database=proyectodb;User=sa;Password=pass123"
  }
```

El archivo **appsettings.json** debería quedar:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "proyecto_db" : "Server=localhost;Database=proyectodb;User=root;Password=pass123"
  }
}
```

**Nota:** Los nombres **proyectodb** queda a eleccion del usuario, no necesariamente el nombre de la base de datos debe coincidir con el nombre del connection string


## Scaffold

- Abrir el **CMD** o **Simbolo de Sistema** y posicionarse dentro de la carpeta del proyecto de Web API (donde se encuentra el archivo **.csproj**)
- Con el comando se procede a realizar el scaffold (completar con las credenciales correspondientes)

```
dotnet ef dbcontext scaffold "Server=IP_SERVIDOR_DB;Database=NOMBRE_BD;User=USUARIO;Password=CONTRASEÑA" Microsoft.EntityFrameworkCore.SqlServer --output-dir Persistence --force --context AplicacionDbContext
```


## Configuración Program.cs

- En el archivo **Program.cs** se debe indicar que nuestro contexto se debe asociar con la base de datos SQL Server para ello se debe colocar el siguiente codigo:

```c#
//obtengo el connectionString desde el archivo appsettings.json con el nombre del item "proyecto_db"
var connectionString = builder.Configuration.GetConnectionString("proyecto_db");

//agrego la configuracion al nuestro contexto AplicacionDbContexto
builder.Services.AddDbContext<AplicacionDbContext>(options => options.UseSqlServer(connectionString));

//agrego nuestro context AplicacionDbContext al contenedor DI de objetos
builder.Services.AddDbContext<DbContext, AplicacionDbContext>();
```
