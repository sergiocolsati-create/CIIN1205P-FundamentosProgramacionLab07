Lab07 - Sistema de Cotización y Cobranzas

Aplicación de consola desarrollada en C# (.NET) que permite gestionar cotizaciones de productos y el registro de facturas con seguimiento de pagos.


Funcionalidades


Cotizar producto: calcula el precio mínimo de venta según el costo y el margen de ganancia, y valida si el precio propuesto es aceptable.
Registrar venta / factura: permite registrar facturas para clientes de tipo crédito o prepago.
Ver cobranzas: lista todas las facturas con su estado (PAGADA, PENDIENTE o VENCIDA) y muestra el total por cobrar.
Registrar pago: marca una factura existente como pagada.
Persistencia de datos: las facturas se guardan en un archivo facturas.txt al salir y se cargan automáticamente al iniciar.



Estructura del proyecto

Lab07/
├── Program.cs          # Menú principal y flujo de la aplicación
├── Cotizaciones.cs     # Lógica de cálculo y validación de precios
├── Cobranzas.cs        # Gestión de facturas, pagos y archivos
└── facturas.txt        # Archivo generado en tiempo de ejecución


Clases principales

Cotizaciones

MétodoDescripciónCalcularPrecioMinimo(costo, margen)Retorna el precio mínimo según costo y margen (%)ValidarPrecio(precioCotizado, precioMinimo)Retorna true si el precio respeta el mínimo

Cobranzas

MétodoDescripciónRegistrarFactura(cliente, monto, tipo, dias)Agrega una nueva factura a la listaVerCobranzas()Muestra todas las facturas y el total por cobrarRegistrarPago()Marca una factura como pagadaGuardarFacturas()Escribe las facturas en facturas.txtCargarFacturas()Lee las facturas desde facturas.txt al iniciar

Factura

Modelo que representa una factura con los campos: Cliente, Monto, TipoCliente, FechaEmision, DiasPlazo y Pagada.


Cómo ejecutar


Abrir el proyecto en Visual Studio.
Compilar y ejecutar con F5 o desde la terminal:


bash   dotnet run


Seguir las opciones del menú interactivo.



Tecnologías


Lenguaje: C#
Framework: .NET
Almacenamiento: archivo de texto plano (.txt)