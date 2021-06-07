using System.Collections.Generic;

namespace POO_Parcial1_Ej1
{
    public class Capitulos
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }

        #region Constructor/Destructor

        public Capitulos()
        { 
        
        }

        public Capitulos(int num, string nom)
        {
            Numero = num;
            Nombre = nom;
        }

        ~Capitulos()
        {
            Nombre = "";
            Numero = 0;
        }

        #endregion

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

        public List<Capitulos> EliminaCapítulo(List<Capitulos> list, string nombreCapitulo) //Elimina el libro indicado.Ojo los parámetros
        {
            foreach (var capitulo in list)
            {
                if (capitulo.Nombre == nombreCapitulo)
                {
                    list.Remove(capitulo);
                    return list;
                }
            }
            return null;
        }

        public override string ToString()// Debe devolver todos los datos del capítulo
        {
            return Numero + ". " + Nombre;
        }
        
    }
}
