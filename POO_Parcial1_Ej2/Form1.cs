using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace POO_Parcial1_Ej2
{
    public partial class Form1 : Form
    {
        public List<Vendedor> listaVendedor = new List<Vendedor>();
        public List<Nombre> listaNombres = new List<Nombre>();
        public List<Ventas> listaVentas = new List<Ventas>();
        public List<string> listaApellidoVendedor = new List<string>();

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
            Vendedor vendedorActual = new Vendedor("",0,0);

            foreach (var item in listaVendedor)
            {
                if ((string)listBox1.SelectedItem == item.Nombres.Apellido)
                {
                    vendedorActual = item;     
                }
            }

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

            richTextBox1.Text += vendedorActual.Nombres.Apellido + ";" + venta.ZonaVenta + ";" + venta.TotalVenta + ";" + venta.Comision + "\n";

            int comisiones = 0;
            listView1.Clear();

            foreach (var venta1 in listaVentas)
            {
                comisiones += venta1.Comision;
                listView1.Items.Add(venta1.Comision.ToString());
            }

            label14.Text = comisiones.ToString();
            
        }

        private void button1_Click(object sender, EventArgs x)
        {
            nombre = new Nombre(textBox1.Text, textBox2.Text, textBox3.Text);
            vendedor = new Vendedor(comboBox1.Text, 0, 0); //Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
            vendedor.Nombres = nombre;

            listaVendedor.Add(vendedor);
            listaNombres.Add(nombre);

            listaApellidoVendedor.Add(nombre.Apellido);

            listBox1.DataSource = null;
            listBox1.DataSource = listaApellidoVendedor;


            richTextBox2.Text += vendedor.Nombres.Apellido + ";" + vendedor.Nombres.PrimerNombre + ";" + vendedor.Nombres.SegundoNombre
                + ";" + vendedor.ZonaDeVenta + "\n"; // Le agrego estos datos? + ";" + vendedor.TotalVendido + ";" + vendedor.Comision;
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
            foreach(var actualVendedor in listaVendedor)
            { 
                if ((string)listBox1.SelectedItem == actualVendedor.Nombres.Apellido)
                {
                    listaVendedor.Remove(actualVendedor);
                    listaApellidoVendedor.Remove(actualVendedor.Nombres.Apellido);
                    break;
                }
            }

            listBox1.DataSource = null;
            listBox1.DataSource = listaApellidoVendedor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = openFileDialog1.FileName;
                var sr = new StreamReader(textBox7.Text);

                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = openFileDialog1.FileName;
                var sr = new StreamReader(textBox8.Text);

                richTextBox2.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = saveFileDialog1.FileName;
                var sw = new StreamWriter(textBox7.Text);

                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = saveFileDialog1.FileName;
                var sw = new StreamWriter(textBox8.Text);

                sw.Write(richTextBox2.Text);
                sw.Close();
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (var item in listaVendedor)
            {
                if ((string)listBox1.SelectedItem == item.Nombres.Apellido)
                {
                    var listaVentasData = new List<Ventas>();
                    foreach (var venta in listaVentas)
                    {
                        if (venta.vendedor == item)
                        {
                            listaVentasData.Add(venta);
                        }
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaVentasData;
                }
            }
        }
    }
}
