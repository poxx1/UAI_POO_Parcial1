using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Parcial1_Ej2
{
    public class Vendedor
    {
        public Nombre Nombres { get; set; }
        public string ZonaDeVenta { get; set; }
        public int TotalVendido { get; set; }
        public int Comision { get; set; }

        public Vendedor BuscaVendedor() //Devuelve el Vendedor buscado con todos sus datos
        {

            return null;
        }
        public int CálculaComisión() //Ojo los parámetros
        {

            return 0;
        }

        ~Vendedor()
        {
            //Nombres 
            ZonaDeVenta = "";
            TotalVendido = 0;
            Comision = 0;
        }

        public Vendedor(Nombre _Nombres, string _ZonaDeVenta, int _TotalVendido, int _Comision)
        {
            Nombres = _Nombres;
            ZonaDeVenta = _ZonaDeVenta;
            TotalVendido = _TotalVendido;
            Comision = _Comision;
        }
    }
}
