# Animate

Proyecto en .NET 10 con arquitectura por capas simple para gestionar y mostrar assets (personajes/imagenes) en una app ASP.NET Core MVC.

## Estado actual (lo implementado hasta ahora)

Actualmente el proyecto ya tiene:

1. **Solucion multi-proyecto** en `Animate.slnx`.
2. **Capa de entidad** (`Animate.Entidad`) con el modelo `Asset`.
3. **Capa de servicio** (`Animate.Servicio`) con un servicio en memoria (`IAnimateServicio` + `AnimateServicio`) que:
   - precarga 3 assets iniciales (Samurai, Dragon, Pez Koi),
   - devuelve la lista completa,
   - agrega nuevos assets durante la ejecucion.
4. **Capa web MVC** (`Animate.MVC`) con:
   - inyeccion de dependencias del servicio como **Singleton**,
   - controlador `AnimateController` para listar y agregar,
   - vistas para mostrar tabla de assets y formulario de alta,
   - contenido estatico en `wwwroot` (Bootstrap, jQuery, CSS y carpeta `Imagenes`).

## Estructura

```text
Animate/
|- Animate.slnx
|- Animate.Entidad/
|- Animate.Servicio/
`- Animate.MVC/
```

## Flujo funcional actual

1. La app inicia en `Animate/Index` (ruta por defecto configurada en `Program.cs`).
2. El controlador pide los datos a `IAnimateServicio`.
3. La vista `Views/Animate/Index.cshtml` renderiza la tabla de assets e imagenes.
4. Desde "Agregar", se envia formulario POST a `AnimateController.Agregar`.
5. El servicio guarda el nuevo asset en la lista en memoria y redirige al listado.

## Como ejecutar

Desde la raiz del repositorio:

```bash
dotnet restore .\Animate.slnx
dotnet run --project .\Animate.MVC\Animate.MVC.csproj
```

URL local (segun `launchSettings.json`):
- `http://localhost:5113`
- `https://localhost:7250`

## Notas importantes del estado actual

- No hay persistencia en base de datos: los datos viven en memoria y se pierden al reiniciar.
- No hay validaciones de modelo en el formulario de alta.
- No hay edicion ni eliminacion de assets.
- `Home` y `Privacy` son vistas base del template MVC.
- El proyecto usa `net10.0`.

## README por proyecto

- `Animate.Entidad/README.md`
- `Animate.Servicio/README.md`
- `Animate.MVC/README.md`
