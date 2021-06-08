using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_Parcial1_Ej2
{
    public partial class Form1 : Form
    {
        public List<Vendedor> listaVendedor = new List<Vendedor>();
        public List<Nombre> listaNombres = new List<Nombre>();
        public List<Ventas> listaVentas = new List<Ventas>();

        private Nombre nombre;
        private Ventas venta;
        private Vendedor vendedor;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            venta = new Ventas();
            var vendedorActual = (Vendedor)listBox1.SelectedItem;

            venta.TotalVenta = Int32.Parse(textBox5.Text);
            venta.Comision = vendedorActual.CálculaComisión(venta.TotalVenta);
            venta.vendedor = vendedorActual;
            venta.ZonaVenta = vendedorActual.ZonaDeVenta;

            vendedorActual.Comision = venta.Comision;
            vendedorActual.TotalVendido = venta.TotalVenta;

            //Renuevo la lista de vendedores por si acaso.
            listaVendedor.Remove(vendedorActual);
            listaVendedor.Add(vendedorActual);
            listaVentas.Add(venta);

            int totalVentas = 0;
            //label10 = total ventas;
            foreach (var venta in listaVentas)
            {
                totalVentas += venta.TotalVenta; 
            }
            label10.Text = "Total de las ventas: " + totalVentas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombre = new Nombre(textBox1.Text, textBox2.Text, textBox3.Text);
            vendedor = new Vendedor(comboBox1.Text, 0, 0); //Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
            vendedor.Nombres = nombre;

            listaVendedor.Add(vendedor);
            listaNombres.Add(nombre);

            listBox1.DataSource = null;
            listBox1.DataSource = listaVendedor;

            listBox1.DisplayMember = "Nombres";
            listBox1.Format += (s, c) =>
            {
                c.Value = ((Nombre)c.Value).Apellido;
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mar del Plata");
            comboBox1.Items.Add("Balcarce");
            comboBox1.Items.Add("Miramar");
            comboBox1.Items.Add("Necochea");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comisionTotal = 0;//label7 = Comision Total
            int ventasTotales = 0;//label8 = Ventas Totales

            foreach (var venta in listaVentas)
            {
                if (venta.ZonaVenta == comboBox1.Text)
                {
                    comisionTotal += venta.Comision;
                    ventasTotales += venta.TotalVenta;
                }
            }

            label7.Text = "Comsion total: " + comisionTotal;
            label8.Text = "Ventas totales: " + ventasTotales;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listaVentasData = new List<Ventas>();
            foreach(var venta in listaVentas)
            {
                if (venta.vendedor == listBox1.SelectedItem)
                {
                    listaVentasData.Add(venta);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaVentasData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaVentas.Remove((Ventas)dataGridView1.CurrentRow.DataBoundItem);

            var vendedorActual = ((Ventas)dataGridView1.CurrentRow.DataBoundItem).vendedor;
            listaVendedor.Remove(vendedorActual);
            vendedorActual.Comision -= ((Ventas)dataGridView1.CurrentRow.DataBoundItem).Comision;
            vendedorActual.TotalVendido -= ((Ventas)dataGridView1.CurrentRow.DataBoundItem).TotalVenta;
            listaVendedor.Add(vendedorActual);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listaVendedor.Remove((Vendedor)listBox1.SelectedItem);
            listBox1.DataSource = null;
            listBox1.DataSource = listaVendedor;
        }
    }
}
