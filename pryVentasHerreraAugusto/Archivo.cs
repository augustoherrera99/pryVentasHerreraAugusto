using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pryVentasHerreraAugusto
{
    public class Archivo
    {
        public string NombreArchivo { get; set; }

        public List<Vendedor> ListarVendedores()
        {
            List<Vendedor> ListaVendedores = new List<Vendedor>();

            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                string Linea;

                StreamReader AD = new StreamReader(NombreArchivo);
                
                while (AD.EndOfStream == false)
                {
                    Linea = AD.ReadLine();
                    Vendedor Vendedor = new Vendedor();
                    Vendedor.VendedorId = Linea.Split(',')[0];
                    Vendedor.VendedorNombre = Linea.Split(',')[1];
                    Vendedor.Activo = Linea.Split(',')[2];
                    Vendedor.CobraComision = Linea.Split(',')[3];
                    
                    ListaVendedores.Add(Vendedor);
                }
                AD.Close();
                AD.Dispose();
            }
            return ListaVendedores;
        }

        public List<Ventas> ListarVentas()
        {
            List<Ventas> ListaVentas = new List<Ventas>();

            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                string Linea;

                StreamReader AD = new StreamReader(NombreArchivo);

                while (AD.EndOfStream == false)
                {
                    Linea = AD.ReadLine();
                    Ventas Venta = new Ventas();
                    Venta.FacturaTipo = Linea.Split(',')[0];
                    Venta.FacturaNumero = Linea.Split(',')[1];
                    Venta.Fecha = Linea.Split(',')[2];
                    Venta.ClienteId = Linea.Split(',')[3];
                    Venta.VendedorId = Linea.Split(',')[4];
                    Venta.Monto = double.Parse(Linea.Split(',')[5]);

                    ListaVentas.Add(Venta);
                }
                AD.Close();
                AD.Dispose();
            }
            return ListaVentas;
        }

        public List<Clientes> ListarClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();

            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                string Linea;

                StreamReader AD = new StreamReader(NombreArchivo);

                while (AD.EndOfStream == false)
                {
                    Linea = AD.ReadLine();
                    Clientes Cliente = new Clientes();
                    Cliente.ClienteId = Linea.Split(',')[0];
                    Cliente.ClienteNombre = Linea.Split(',')[1];

                    ListaClientes.Add(Cliente);
                }
                AD.Close();
                AD.Dispose();
            }
            return ListaClientes;
        }


    }
}
