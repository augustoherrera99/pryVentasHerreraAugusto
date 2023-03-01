using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryVentasHerreraAugusto
{
    public class Ventas
    {
        // Propiedades

        public string FacturaTipo { get; set; }
        public string FacturaNumero { get; set; }
        public string Fecha { get; set; }
        public string ClienteId { get; set; }
        public string VendedorId { get; set; }
        public double Monto { get; set; }
    }
}
