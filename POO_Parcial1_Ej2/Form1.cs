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

        private Nombre nombre;
        private Vendedor vendedor;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombre = new Nombre(textBox1.Text, textBox2.Text, textBox3.Text);
            vendedor = new Vendedor(nombre, comboBox1.Text, Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));

            listaVendedor.Add(vendedor);
            listaNombres.Add(nombre);

            listBox1.DataSource = null;
            listBox1.DataSource = listaVendedor;
            listBox1.DisplayMember = "Apellido";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mar del Plata");
            comboBox1.Items.Add("Balcarce");
            comboBox1.Items.Add("Miramar");
            comboBox1.Items.Add("Necochea");
        }
    }
}
