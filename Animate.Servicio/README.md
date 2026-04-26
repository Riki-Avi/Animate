# Animate.Servicio

Capa de servicio con logica de gestion de assets.

## Estado actual

Se implemento:

1. **Interfaz `IAnimateServicio`**
   - `List<Asset> ObtenerAssets()`
   - `void AgregarAsset(Asset asset)`
2. **Clase `AnimateServicio`**
   - almacena assets en una lista privada en memoria (`_assets`),
   - precarga 3 registros iniciales:
     - Samurai
     - Dragon
     - Pez Koi
   - expone listado completo y alta de nuevos assets.

## Comportamiento actual

- Es un servicio en memoria sin base de datos.
- Los cambios duran solo mientras el proceso esta activo.
- No hay validaciones internas para evitar ids duplicados o campos vacios.

## Integracion

En `Animate.MVC/Program.cs` el servicio se registra como:

```csharp
builder.Services.AddSingleton<Animate.Servicio.IAnimateServicio, Animate.Servicio.AnimateServicio>();
```

Esto significa que durante toda la ejecucion de la app se comparte una sola instancia del servicio.

## Notas tecnicas

- Referencia a `Animate.Entidad`.
- Target framework: `net10.0`.
