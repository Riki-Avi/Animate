# Animate.MVC

Aplicacion web ASP.NET Core MVC para listar y agregar assets.

## Estado actual

### Configuracion principal (`Program.cs`)

- `AddControllersWithViews()`
- DI del servicio de assets como `Singleton`
- Pipeline con:
  - `UseExceptionHandler` + `UseHsts` fuera de Development
  - `UseHttpsRedirection`
  - `UseRouting`
  - `UseAuthorization`
  - `MapStaticAssets()`
- Ruta por defecto:
  - `controller=Animate`
  - `action=Index`

### Controladores

1. **AnimateController**
   - `Index()`:
     - obtiene assets desde `IAnimateServicio`
     - retorna vista con el listado
   - `Agregar()` **GET**:
     - muestra formulario
   - `Agregar(Asset asset)` **POST**:
     - agrega asset al servicio
     - redirige a `Index`

2. **HomeController** (base del template)
   - `Index`, `Privacy`, `Error`

### Vistas

- `Views/Animate/Index.cshtml`
  - tabla con Nombre, Descripcion e Imagen
  - boton "Agregar"
  - render de imagen con `~/imagenes/{Imagen}.png`
- `Views/Animate/Agregar.cshtml`
  - formulario HTML simple (Nombre, Descripcion, Imagen)
- `Views/Shared/_Layout.cshtml`
  - layout general con Bootstrap y navegacion base
- Vistas de template en `Home` y `Shared/Error`

### Recursos estaticos

- `wwwroot/css/site.css`
- `wwwroot/js/site.js`
- `wwwroot/lib` (Bootstrap, jQuery, validacion)
- `wwwroot/Imagenes` con:
  - `samurai.png`
  - `dragon.png`
  - `pezkoi.png`

## Ejecucion local

```bash
dotnet run --project .\Animate.MVC\Animate.MVC.csproj
```

Perfiles definidos en `Properties/launchSettings.json`:

- HTTP: `http://localhost:5113`
- HTTPS: `https://localhost:7250` (tambien expone HTTP)

## Alcance funcional actual

- Listado de assets precargados.
- Alta de nuevos assets en memoria.
- Render de imagen por nombre de archivo.

## Limitaciones actuales

- Sin persistencia en BD.
- Sin validacion de formulario/modelo.
- Sin editar/eliminar.
- Sin autenticacion/autorizacion aplicada a acciones.
