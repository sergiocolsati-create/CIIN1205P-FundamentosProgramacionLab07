using System;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            // El menu se repite mientras 'continuar' sea verdadero
            while (continuar)
            {
                Console.WriteLine();
                Console.WriteLine("===== SISTEMA DE COTIZACION Y COBRANZAS =====");
                Console.WriteLine("1. Cotizar producto (validar precio)");
                Console.WriteLine("2. Registrar venta / factura");
                Console.WriteLine("3. Ver cobranzas (facturas pendientes)");
                Console.WriteLine("4. Registrar pago de factura");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opcion: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa el costo del producto: ");
                        double costo = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Ingresa el margen minimo (%): ");
                        double margen = Convert.ToDouble(Console.ReadLine());

                        double precioMin = Cotizaciones.CalcularPrecioMinimo(costo, margen);
                        Console.WriteLine("Precio minimo de venta: " + precioMin);

                        Console.Write("Ingresa el precio que cotiza la vendedora: ");
                        double precioVendedora = Convert.ToDouble(Console.ReadLine());

                        bool esValido = Cotizaciones.ValidarPrecio(precioVendedora, precioMin);

                        if (esValido)
                        {
                            Console.WriteLine("Precio APROBADO: respeta el margen minimo.");
                        }
                        else
                        {
                            Console.WriteLine("ALERTA: precio por debajo del minimo. NO autorizado.");
                        }
                        break;
                    case "2":
                        Console.Write("Nombre del cliente: ");
                        string cliente = (Console.ReadLine() ?? "").Trim();

                        Console.Write("Monto del pedido: ");
                        double monto = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Tipo de cliente (credito / prepago): ");
                        string tipo = (Console.ReadLine() ?? "").Trim().ToLower();

                        if (tipo == "prepago")
                        {
                            // El prepago paga antes de facturar: plazo 0 dias
                            Console.WriteLine("Cliente prepago: debe cancelar antes del envio.");
                            Cobranzas.RegistrarFactura(cliente, monto, "prepago", 0);
                        }
                        else if (tipo == "credito")
                        {
                            Console.Write("Dias de plazo para el pago: ");
                            int dias = Convert.ToInt32(Console.ReadLine());
                            Cobranzas.RegistrarFactura(cliente, monto, "credito", dias);
                            
                        }
                        else
                        {
                            Console.WriteLine("Tipo no valido. No se registro la factura.");
                        }
                        break;
                    case "3":
                        Cobranzas.VerCobranzas();
                        break;
                    case "4":
                        Cobranzas.RegistrarPago(); 
                        break;
                    case "5":
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intenta de nuevo.");
                        break;
                }
                // Pausa despues de cada operacion (dentro del while, fuera del switch)
                Console.WriteLine();
                Console.WriteLine("Presiona una tecla para volver al menu...");
                Console.ReadKey();
            }
        }
    }
}