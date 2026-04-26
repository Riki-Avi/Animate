# Animate.Entidad

Libreria de clases con las entidades del dominio.

## Estado actual

Se implemento una unica entidad:

- **Asset** (`Asset.cs`)
  - `Id` (`int`)
  - `Nombre` (`string`)
  - `Descripcion` (`string`)
  - `Imagen` (`string`)

## Rol dentro de la solucion

Este proyecto define el contrato de datos compartido por:

- `Animate.Servicio` (logica de negocio en memoria)
- `Animate.MVC` (binding del formulario y renderizado en vistas)

## Notas

- No contiene logica de negocio ni persistencia.
- Se usa `Nullable` habilitado y `ImplicitUsings` habilitado.
- Target framework: `net10.0`.
