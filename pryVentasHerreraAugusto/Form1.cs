using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryVentasHerreraAugusto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string NombreArchivoVendedores = "Vendedor.csv";
        private const string NombreArchivoClientes = "Cliente.csv";
        private const string NombreArchivoVentas = "Ventas.csv";
        private void Form1_Load(object sender, EventArgs e)
        {
            Archivo Vendedores = new Archivo();

            Vendedores.NombreArchivo = NombreArchivoVendedores;

            List<Vendedor> ListaVendedores = Vendedores.ListarVendedores();
            cmbVendedor.Items.Clear();

            foreach (Vendedor Vendedor in ListaVendedores)
            {
                cmbVendedor.Items.Add(Vendedor.VendedorNombre);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Archivo Vendedores = new Archivo();
                Vendedores.NombreArchivo = NombreArchivoVendedores;
                List<Vendedor> ListaVendedores = Vendedores.ListarVendedores();

                Archivo Ventas = new Archivo();
                Ventas.NombreArchivo = NombreArchivoVentas;
                List<Ventas> ListaVentas = Ventas.ListarVentas();

                Archivo Clientes = new Archivo();
                Clientes.NombreArchivo = NombreArchivoClientes;
                List<Clientes> ListaClientes = Clientes.ListarClientes();

                dgvConsulta.Rows.Clear();
                lblComision.Text = "";
                lblTotalVentas.Text = "";
                double Total = 0;
                bool a = false;


                foreach (Vendedor Vendedor in ListaVendedores)
                {
                    if (cmbVendedor.Text == Vendedor.VendedorNombre)
                    {
                        foreach (Ventas Venta in ListaVentas)
                        {
                            if (Vendedor.VendedorId == Venta.VendedorId)
                            {

                                if (DateTime.Compare(DateTime.Parse(txtDesde.Text), DateTime.Parse(Venta.Fecha)) >= 0)
                                {
                                    if (DateTime.Compare(DateTime.Parse(txtHasta.Text), DateTime.Parse(Venta.Fecha)) <= 0)
                                    {

                                        dgvConsulta.Rows.Add(Venta.FacturaNumero, Venta.FacturaTipo, Venta.Fecha, Venta.ClienteId, Venta.Monto);

                                        Total += Venta.Monto;

                                        lblTotalVentas.Text = Total.ToString();

                                        if (int.Parse(Vendedor.CobraComision) == 1)
                                        {
                                            a = true;
                                        }

                                    }
                                }


                            }
                            else
                            {
                                MessageBox.Show("El vendedor no ha tenido ventas", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }

                double TotalComision = Total * 0.15;
                lblComision.Text = TotalComision.ToString();

                if (a == false)
                {
                    lblComision.Text = "No Asignado.";
                }
            }
            else
            {
                MessageBox.Show("Datos incorrectos.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool ValidarDatos()
        {
            bool resultado = false;
            if (cmbVendedor.Text != "")
            {
                if (txtDesde.Text != "")
                {
                    if (txtHasta.Text != "")
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }

    }
}
