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
        public List<Capitulos> listaCapitulos;

        public Libro libro;
        public Capitulos capitulo;

        public int counter = 1;
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
            libro = new Libro(textBox1.Text, textBox2.Text, textBox3.Text, listaCapitulos, Int32.Parse(textBox4.Text));
            List<int> listaCapitulosActual = new List<int>();
            List<Capitulos> listaAuxiliar = new List<Capitulos>();

            listaCapitulos = new List<Capitulos>();

            listaAuxiliar = listaCapitulos;

            foreach (var capitulo in listaAuxiliar)
            {
                listaCapitulosActual.Add(capitulo.ID);
            }

            libro.listaCapitulos = listaCapitulosActual;
            
            listaLibros.Add(libro);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLibros;

            dataGridView2.DataSource = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            capitulo = new Capitulos();

            capitulo.Nombre = textBox5.Text;
            capitulo.Numero = Int32.Parse(textBox6.Text);
            capitulo.ID = counter;

            counter++;

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
            //C:\Users\Poxi\source\repos\POO_Parcial1_Ej1\POO_Parcial1_Ej1\Documentos

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
                //libro.Titulo = arrayLineas[0];
                //libro.Autor = arrayLineas[1];
                //libro.Editorial = arrayLineas[2];
                //libro.Cantidad_Hojas = Int32.Parse(arrayLineas[3]);
                //Los capitulos del libro los guardaria en otro .csv. Linda pregunta para el profe.

                List<Capitulos> listaVacia = new List<Capitulos>();

                libro = new Libro(arrayLineas[0], arrayLineas[1], arrayLineas[2], listaVacia, Int32.Parse(arrayLineas[3]));

                listaLibros.Add(libro);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLibros;
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

            foreach (var libroz in listaLibros)
            {
                capitulo = capitulo.BuscaCapítulo(libroz.Capitulos, nombreCapitulo);
            }

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
            string lineaLibro = "";

            foreach (var libro in listaLibros)
            {
                lineaLibro = libro.Titulo + ";" + libro.Autor + ";" + libro.Editorial + ";" + libro.Cantidad_Hojas + ";" + libro.Capitulos;
                richTextBox1.Text += Environment.NewLine + lineaLibro;
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

            //Asigno a mi lista de libros los libros que fui leyendo
            var arrayLibros = richTextBox1.Text.Split('\n');
            listaLibros.Clear();

            foreach (var linea in arrayLibros)
            {
                var arrayLineas = linea.Split(';');

                List<Capitulos> listaVacia = new List<Capitulos>();

                libro = new Libro(arrayLineas[0], arrayLineas[1], arrayLineas[2], listaVacia, Int32.Parse(arrayLineas[3]));

                listaLibros.Add(libro);
            }
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
