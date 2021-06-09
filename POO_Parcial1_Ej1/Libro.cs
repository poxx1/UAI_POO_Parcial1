using System.Collections.Generic;

namespace POO_Parcial1_Ej1
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }

        public readonly List<Capitulos> Capitulos;
        public int Cantidad_Hojas { get; set; }
        public List<int> listaCapitulos { get; set; }

        public Libro(string _Titulo, string _Autor, string _Editorial, List<Capitulos> _capitulos, int _Cantidad_Hojas) 
        {
            Titulo = _Titulo;
            Autor = _Autor;
            Editorial = _Editorial;
            Cantidad_Hojas = _Cantidad_Hojas;
            Capitulos = _capitulos;
        }

        public Libro() 
        {
            
        }
        
        ~Libro()
        {
            Titulo = "";
            Autor = "";
            Editorial = "";
            //Capitulos = null; > Destructor de una lista?
            Cantidad_Hojas = 0;
        }

        public List<Capitulos> AgregaCapitulo(List<Capitulos> listaCapitulos, Capitulos capitulo)
        {
            listaCapitulos.Add(capitulo);
            return listaCapitulos;
        }

        public Libro BuscaLibro(List<Libro> listaLibros, string tituloLibro) //Devuelve el libro buscado
        {
            foreach (var libro in listaLibros)
            {
                if (libro.Titulo == tituloLibro)
                    return libro;
            }
            return null;
        }
        public List<Libro> EliminaLibro(List<Libro> listaLibros, string tituloLibro) //Elimina el libro indicado.Ojo los parámetros
        {
            foreach (var libro in listaLibros)
            {
                if (libro.Titulo == tituloLibro)
                {
                    listaLibros.Remove(libro);
                    return listaLibros;
                }
            }
            return null;
        }

        public override string ToString() //Debe devolver todos los datos del Libro
        {
            return Titulo + ", " + Autor + ", " + Editorial + ", " + Cantidad_Hojas;
        }
    }
}
 