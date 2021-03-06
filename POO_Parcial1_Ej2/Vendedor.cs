namespace POO_Parcial1_Ej2
{
    public class Vendedor 
    { 
        public Nombre Nombres { get; set; } 
        public string ZonaDeVenta { get; set; }
        public int TotalVendido { get; set; }
        public int Comision { get; set; }
        public bool Estado { get; set; }

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
                return (TotalVenta * 15) / 100; //Creo que era asi cuenta, validar si no la cague.
            if (TotalVenta > 75000 && TotalVenta < 100000)
                return (TotalVenta * 20) / 100;
            if (TotalVenta >= 100000)
                return (TotalVenta * 30) / 100; 
            return 0;
        }

        ~Vendedor()
        {
            //Nombres 
            ZonaDeVenta = "";
            TotalVendido = 0;
            Comision = 0;
        }

        public Vendedor(string _ZonaDeVenta, int _TotalVendido, int _Comision)
        {
            ZonaDeVenta = _ZonaDeVenta;
            TotalVendido = _TotalVendido;
            Comision = _Comision;
            Estado = true;
        }
    }
}
