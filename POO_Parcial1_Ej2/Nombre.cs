﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Parcial1_Ej2
{
    public class Nombre
    {
        public string Apellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }

        public Nombre()
        { 
        
        }
        ~Nombre()
        {
            Apellido = "";
            PrimerNombre = "";
            SegundoNombre = "";
        }

        public Nombre(string _Apellido, string _PrimerNombre, string _SegundoNombre)
        {
            Apellido = _Apellido;
            PrimerNombre = _PrimerNombre;
            SegundoNombre = _SegundoNombre;
        }
    }
}
