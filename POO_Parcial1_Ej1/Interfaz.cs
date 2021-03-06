using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace POO_Parcial1_Ej1
{
    public partial class Interfaz : Form
    {
        #region Propiedades

        public List<Libro> listaLibros = new List<Libro>();
        public List<Capitulos> listaCapitulos = new List<Capitulos>();

        public Libro libro;
        public Capitulos capitulo;

        public int counter = 1;
        public int counterLectura = 1;
        #endregion

        #region Metodos de la interfaz
        public Interfaz()
        {
            InitializeComponent();
        }
        private void Interfaz_Load(object sender, EventArgs e)
        {
            textBox7.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        #endregion

        #region Metodos creados
        private void button1_Click(object sender, EventArgs e)
        {
            List<Capitulos> listaAuxiliar = new List<Capitulos>();

            foreach (var item in listaCapitulos)
            {
                listaAuxiliar.Add(item);
            }

            libro = new Libro(textBox1.Text, textBox2.Text, textBox3.Text, listaAuxiliar, Int32.Parse(textBox4.Text),counter);
            List<int> listaCapitulosActual = new List<int>();
        
            foreach (var capitulo in listaAuxiliar)
            {
                listaCapitulosActual.Add(capitulo.ID);
            }

            libro.listaCapitulos = listaCapitulosActual;
            
            listaLibros.Add(libro);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLibros;

            dataGridView2.DataSource = null;
            listaCapitulos.Clear();

            counter++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            capitulo = new Capitulos();

            capitulo.Nombre = textBox5.Text;
            capitulo.Numero = Int32.Parse(textBox6.Text);
            capitulo.ID = counter;

            listaCapitulos.Add(capitulo);

            comboBox1.DataSource = null;
            comboBox1.DataSource = listaCapitulos;
            comboBox1.DisplayMember = "Nombre";

            dataGridView2.DataSource = null;
            int aux = 0;
            if(aux != listaCapitulos.Count)
            { 
                dataGridView2.DataSource = listaCapitulos;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Abro el documento y cargo el richtextbox
            openFileDialog1.DefaultExt = "csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = openFileDialog1.FileName;
                var sr = new StreamReader(textBox7.Text);

                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }

            //Asigno a mi lista de libros los libros que fui leyendo
            var arrayLibros = richTextBox1.Text.Split('\n');
            listaLibros.Clear();

            foreach (var linea in arrayLibros)
            {
                var arrayLineas = linea.Split(';');

                if (arrayLineas[0] != "")
                {
                    List<Capitulos> listaVacia = new List<Capitulos>();

                    libro = new Libro(arrayLineas[0], arrayLineas[1], arrayLineas[2], listaVacia, Int32.Parse(arrayLineas[3]), Int32.Parse(arrayLineas[4]));

                    listaLibros.Add(libro);

                }
            }
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLibros;

            counterLectura = 1;
        }

        private void button4_Click(object sender, EventArgs e)
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
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            string nombreCapitulo = textBox5.Text;

            capitulo = new Capitulos();

            foreach (var libroz in listaLibros)
            {
                try
                {
                    if(capitulo.BuscaCapítulo(libroz.Capitulos, nombreCapitulo)!= null)
                    {
                        capitulo = capitulo.BuscaCapítulo(libroz.Capitulos, nombreCapitulo);
                    }
                }
                catch(Exception ex)
                { 
                    //Ex Vacia
                }
            }

            //capitulo = x;

            if (capitulo != null)
                MessageBox.Show("Se encontro el capitulo deseado", "Sistema Bibliotecario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se encontro el capitulo", "Sistema Bibliotecario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nombreCapitulo = textBox5.Text;

            listaCapitulos = capitulo.EliminaCapítulo(listaCapitulos, nombreCapitulo);
            if (listaCapitulos != null)
                MessageBox.Show("Se elimino el capitulo deseado", "Sistema Bibliotecario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se encontro el capitulo", "Sistema Bibliotecario", MessageBoxButtons.OK, MessageBoxIcon.Error);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaCapitulos;

            comboBox1.DataSource = null;
            comboBox1.DataSource = listaCapitulos;
            comboBox1.DisplayMember = "Nombre";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            
            string lineaLibro = "";

            foreach (var libro in listaLibros)
            {
                lineaLibro = libro.Titulo + ";" + libro.Autor + ";" + libro.Editorial + ";" + libro.Cantidad_Hojas + ";";
                richTextBox1.Text += lineaLibro + Environment.NewLine ;

                foreach (var capitulo in libro.Capitulos)
                {
                    var lineaCapitulo = capitulo.ID + ";" + capitulo.Numero + ";" + capitulo.Nombre;
                    richTextBox2.Text += lineaCapitulo + Environment.NewLine;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Libro> listaLibrosAutor = new List<Libro>();
            foreach (var libro in listaLibros)
            {
                if (textBox2.Text == libro.Autor)
                {
                    listaLibrosAutor.Add(libro);
                }
            }

            foreach (var libro in listaLibrosAutor)
            {
                MessageBox.Show("Los libros del autor son los siguientes: " + libro.Titulo, "Sistema Bibliotecario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (listaLibrosAutor.Count == 0)
                MessageBox.Show("No se encontraron libros del autor: " + textBox2.Text, "Sistema Bibliotecario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = openFileDialog1.FileName;
                var sr = new StreamReader(textBox8.Text);

                richTextBox2.Text = sr.ReadToEnd();
                sr.Close();
            }

            int counterCapitulos = 0;

            //Asigno a mi lista de libros los libros que fui leyendo
            var arrayCapitulos = richTextBox2.Text.Split('\n');

            counterCapitulos = arrayCapitulos.Length - 1;

            //listaLibros.Clear(); >> No la borro mas, porque le asingo los libros ahora

            List<Libro> listaAuxiliarLibros = new List<Libro>();

            foreach (var libros in listaLibros)
            {
                listaAuxiliarLibros.Add(libros);
            }

            listaLibros.Clear();

            foreach (var libro in listaAuxiliarLibros)
            {
                //var arrayLineas = arrayCapitulos.Split(';');

                List<Capitulos> listaVacia = new List<Capitulos>();

                foreach (var lineaCapitulo in arrayCapitulos)
                {
                    var capituloActual = lineaCapitulo.Split(';');

                    var capitulo = new Capitulos();

                    if (capituloActual[0] != "")
                    {
                        if (libro.id == Int32.Parse(capituloActual[0]))
                        {
                            capitulo.ID = Int32.Parse(capituloActual[0]);
                            capitulo.Numero = Int32.Parse(capituloActual[1]);
                            capitulo.Nombre = capituloActual[2];
                            listaVacia.Add(capitulo);
                        }

                    }
                }

                var libroNuevo = new Libro(libro.Titulo, libro.Autor, libro.Editorial, listaVacia, libro.Cantidad_Hojas, libro.id);

                listaLibros.Add(libroNuevo);
            }

            //foreach(var libro in listaAuxiliarLibros)
            //{ 
            //    listaLibros.Add(libro); 
            //}

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLibros;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = saveFileDialog1.FileName;
                var sw = new StreamWriter(textBox8.Text);

                sw.Write(richTextBox2.Text);
                sw.Close();
            }
        }
    }
}
