using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    public class Cotizaciones
    {
        /// <summary>
        /// Calcula el precio minimo de venta segun el costo y el margen (%).
        /// </summary>
        public static double CalcularPrecioMinimo(double costo, double margen)
        {
            double minimo = costo * (1 + (margen/100));
            return Math.Round(minimo,2);
        }

        /// <summary>
        /// Indica si el precio cotizado respeta el precio minimo permitido.
        /// </summary>
        public static bool ValidarPrecio(double precioCotizado, double precioMinimo)
        {
            return precioCotizado >= precioMinimo;
        }
    }
}
