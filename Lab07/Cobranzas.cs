using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    public class Factura
    {
        public string Cliente { get; set; }
        public double Monto { get; set; }
        public string TipoCliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public int DiasPlazo { get; set; }
        public bool Pagada { get; set; }
    }
    public class Cobranzas
    {
        // Lista compartida que guarda todas las facturas en memoria
        private static List<Factura> facturas = new List<Factura>();

        /// <summary>
        /// Registra una nueva factura con los datos del cliente y la agrega a la lista.
        /// </summary>
        public static void RegistrarFactura(string cliente, double monto, string tipoCliente, int diasPlazo)
        {
            // Creamos una nueva factura usando el molde Factura
            Factura nueva = new Factura();
            nueva.Cliente = cliente;
            nueva.Monto = monto;
            nueva.TipoCliente = tipoCliente;
            nueva.FechaEmision = DateTime.Now;   // fecha y hora actual
            nueva.DiasPlazo = diasPlazo;
            nueva.Pagada = false;                // toda factura nace sin pagar

            facturas.Add(nueva);
            

            Console.WriteLine("Factura registrada correctamente.");
        }
        /// <summary>
        /// Muestra todas las facturas, marca las vencidas y calcula el total por cobrar.
        /// </summary>
        public static void VerCobranzas()
        {
            if (facturas.Count == 0)
            {
                Console.WriteLine("No hay facturas registradas.");
                return;
            }

            double totalPorCobrar = 0;

            Console.WriteLine("----- LISTADO DE FACTURAS -----");

            // Recorremos cada factura de la lista
            foreach (Factura f in facturas)
            {
                // Fecha de vencimiento = fecha de emision + dias de plazo
                DateTime vencimiento = f.FechaEmision.AddDays(f.DiasPlazo);

                // Estado de pago
                string estado;
                if (f.Pagada)
                {
                    estado = "PAGADA";
                }
                else
                {
                    if (DateTime.Now > vencimiento)
                    {
                        estado = "VENCIDA";
                    }
                    else
                    {
                        estado = "PENDIENTE";
                    }
                }

                // Si no esta pagada, suma su monto al total por cobrar
                if (!f.Pagada)
                {
                    totalPorCobrar +=f.Monto; // TODO: acumula el monto de esta factura en totalPorCobrar
                }

                Console.WriteLine(
                    f.Cliente + " | " + f.TipoCliente + " | Monto: " + f.Monto +
                    " | Vence: " + vencimiento.ToShortDateString() + " | " + estado);
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine("TOTAL POR COBRAR: " + totalPorCobrar);
        }

        /// <summary>
        /// Muestra las facturas pendientes numeradas y marca como pagada la que elija el usuario.
        /// </summary>
        public static void RegistrarPago()
        {
            if (facturas.Count == 0)
            {
                Console.WriteLine("No hay facturas registradas.");
                return;
            }

            Console.WriteLine("----- FACTURAS REGISTRADAS -----");

            // Recorremos con indice para mostrar un numero por cada factura
            for (int i = 0; i < facturas.Count; i++)
            {
                Factura f = facturas[i];
                string estadoPago = f.Pagada ? "PAGADA" : "PENDIENTE";
                Console.WriteLine((i + 1) + ". " + f.Cliente + " | Monto: " + f.Monto + " | " + estadoPago);
            }

            Console.Write("Numero de factura a pagar: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            // Validamos que el numero exista (entre 1 y la cantidad de facturas)
            if (numero >= 1 && numero <= facturas.Count)
            {
                Factura f = facturas[numero-1];
                f.Pagada = true;

                Console.WriteLine("Factura pagada correctamente.");
            }
            else
            {
                Console.WriteLine("Numero de factura no valido.");
            }
        }
        /// <summary>
        /// Guarda todas las facturas en un archivo de texto (una linea por factura).
        /// </summary>
        public static void GuardarFacturas()
        {
            // Lista de texto donde acumularemos una linea por cada factura
            List<string> lineas = new List<string>();

            foreach (Factura f in facturas)
            {
                // Convertimos la factura en una linea con datos separados por ;
                string linea =
                    f.Cliente + ";" +
                    f.Monto + ";" +
                    f.TipoCliente + ";" +
                    f.FechaEmision.ToString("yyyy-MM-dd") + ";" +
                    f.DiasPlazo + ";" +
                    f.Pagada;

                lineas.Add(linea);
                // TODO: agrega 'linea' a la lista 'lineas'
                // Pista: es el mismo .Add(...) que usaste con las facturas
            }

            // Escribimos todas las lineas en el archivo facturas.txt
            File.WriteAllLines("facturas.txt", lineas);

            Console.WriteLine("Facturas guardadas en facturas.txt");
        }

        /// <summary>
        /// Carga las facturas guardadas en el archivo de texto (si existe) a la lista.
        /// </summary>
        public static void CargarFacturas()
        {
            // Si el archivo no existe todavia, no hay nada que cargar
            if (!File.Exists("facturas.txt"))
            {
                return;
            }

            // Leemos todas las lineas del archivo
            string[] lineas = File.ReadAllLines("facturas.txt");

            foreach (string linea in lineas)
            {
                // Partimos la linea en sus 6 datos usando el ;
                string[] datos = linea.Split(';');

                // Reconstruimos la factura a partir de los datos de texto
                Factura f = new Factura();
                f.Cliente = datos[0];
                f.Monto = Convert.ToDouble(datos[1]);
                f.TipoCliente = datos[2];
                f.FechaEmision = DateTime.Parse(datos[3]);
                f.DiasPlazo = Convert.ToInt32(datos[4]);
                f.Pagada = bool.Parse(datos[5]);

                facturas.Add(f);
            }

            Console.WriteLine("Facturas cargadas desde facturas.txt");
        }

    }
}
