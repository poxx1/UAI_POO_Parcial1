using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Parcial1_Ej1
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }

        public readonly List<Capitulos> capitulos;
        public int Cantidad_Hojas { get; set; }

        public void AgregaCapitulo()
        { 
        
        }
        public Libro BuscaLibro() //Devuelve el libro buscado
        {
            Libro libro = new Libro();

            return libro;
        }
        public void EliminaLibro() //Elimina el libro indicado.Ojo los parámetros
        { 
            
        }

        public override string ToString() //Debe devolver todos los datos del Libro
        {
            return "";
        }
    }
}
