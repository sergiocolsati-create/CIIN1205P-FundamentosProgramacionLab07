# Lab07 - Sistema de Cotización y Cobranzas

Aplicación de consola desarrollada en **C# (.NET)** que permite gestionar cotizaciones de productos y el registro de facturas con seguimiento de pagos.

---

## Funcionalidades

- **Cotizar producto:** calcula el precio mínimo de venta según el costo y el margen de ganancia, y valida si el precio propuesto es aceptable.
- **Registrar venta / factura:** permite registrar facturas para clientes de tipo crédito o prepago.
- **Ver cobranzas:** lista todas las facturas con su estado (PAGADA, PENDIENTE o VENCIDA) y muestra el total por cobrar.
- **Registrar pago:** marca una factura existente como pagada.
- **Persistencia de datos:** las facturas se guardan en un archivo `facturas.txt` al salir y se cargan automáticamente al iniciar.

---

## Estructura del proyecto

```
Lab07/
├── Program.cs          # Menú principal y flujo de la aplicación
├── Cotizaciones.cs     # Lógica de cálculo y validación de precios
├── Cobranzas.cs        # Gestión de facturas, pagos y archivos
└── facturas.txt        # Archivo generado en tiempo de ejecución
```

---

## Clases principales

### `Cotizaciones`
| Método | Descripción |
|---|---|
| `CalcularPrecioMinimo(costo, margen)` | Retorna el precio mínimo según costo y margen (%) |
| `ValidarPrecio(precioCotizado, precioMinimo)` | Retorna `true` si el precio respeta el mínimo |

### `Cobranzas`
| Método | Descripción |
|---|---|
| `RegistrarFactura(cliente, monto, tipo, dias)` | Agrega una nueva factura a la lista |
| `VerCobranzas()` | Muestra todas las facturas y el total por cobrar |
| `RegistrarPago()` | Marca una factura como pagada |
| `GuardarFacturas()` | Escribe las facturas en `facturas.txt` |
| `CargarFacturas()` | Lee las facturas desde `facturas.txt` al iniciar |

### `Factura`
Modelo que representa una factura con los campos: `Cliente`, `Monto`, `TipoCliente`, `FechaEmision`, `DiasPlazo` y `Pagada`.

---

## Cómo ejecutar

1. Abrir el proyecto en **Visual Studio**.
2. Compilar y ejecutar con `F5` o desde la terminal:
   ```bash
   dotnet run
   ```
3. Seguir las opciones del menú interactivo.

---

## Tecnologías

- Lenguaje: C#
- Framework: .NET
- Almacenamiento: archivo de texto plano (`.txt`)