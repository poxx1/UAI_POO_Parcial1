using System.Collections.Generic;
using System.Linq;

namespace POO_Parcial1_Ej1
{
    public class Capitulos
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }

        //Tengo que pasarle como parametro tambien el libro para saber que capitulo de que libro estoy buscando?
        //Puedo pasarle la lista de libros y buscar el capitulo del libro sin importar el libro, pero si tengo 2 capitulos iguales en dos libros diferentes?
        public Capitulos BuscaCapítulo(List<Capitulos> list, string nombreCapitulo) //Devuelve el capítulo buscado;
        {
            foreach (var capitulo in list)
            {   
                if (capitulo.Nombre == nombreCapitulo)
                {
                    return capitulo;
                }
            }
            return null;
        }

        public void EliminaCapítulo() //Elimina el libro indicado.Ojo los parámetros
        { 
            
        }
        public override string ToString()// Debe devolver todos los datos del capítulo
        {
            return "";
        }

    }
}