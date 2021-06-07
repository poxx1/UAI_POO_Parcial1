using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Parcial1_Ej2
{
    public class Vendedor//:Nombre // Uso herencia, o uso el type Nombre?
    {
        public Nombre Nombres { get; set; } // >> Pregunta de la herencia
        public string ZonaDeVenta { get; set; }
        public int TotalVendido { get; set; }
        public int Comision { get; set; }

        public Vendedor BuscaVendedor() //Devuelve el Vendedor buscado con todos sus datos
        {

            return null;
        }

        //Si totalVendido< $ 50.000 , la comisión es cero.
        //Si $50.000 <= totalVendido< $75.000, la comisión es del 15%. 
        //Si $75.000 <= totalVendido< $100.000, la comisión es del 20%. 
        //Si $100.000 <= totalVendido, la comisión es del 30 %. 
        public int CálculaComisión(int TotalVenta) //Ojo los parámetros
        {
            if (TotalVenta < 50000)
                return 0;
            if (TotalVenta > 50000 && TotalVenta < 75000)
                return TotalVenta += (TotalVenta * 15) / 100; //Creo que era asi cuenta, validar si no la cague.
            if (TotalVenta > 75000 && TotalVenta < 100000)
                return TotalVenta += (TotalVenta * 20) / 100;
            if (TotalVenta > 100000)
                return TotalVenta += (TotalVenta * 30) / 100; 
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
            Nombres.Apellido = _Nombres.Apellido;
            Nombres.PrimerNombre = _Nombres.PrimerNombre;
            Nombres.SegundoNombre = _Nombres.SegundoNombre;
            ZonaDeVenta = _ZonaDeVenta;
            TotalVendido = _TotalVendido;
            Comision = _Comision;
        }
    }
}
