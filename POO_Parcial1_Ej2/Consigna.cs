using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Parcial1_Ej2
{
    public class Consigna
    {
        /*
        Una Empresa dedicada a la venta de Jugos, desea registrar la información de sus vendedores, 
        respecto a: nombre, zonaDeVenta, totalVendido y comisión.  
        Donde totalVendido representa las ventas realizadas por el vendedor en cada mes, y comisión un porcentaje que depende del totalVendido.  
        Además la variable nombre está asociada con una clase Nombre cuyas instancias representan el apellido, 
        el primerNombre y el segundoNombre de cada vendedor.  

        Diseñe las siguientes clases: 

        Clase VENDEDOR 
            Propiedades:
            ++ NOMBRE (Clase Nombre)
            ++ ZONADEVENTA
            ++ TOTALVENDIDO 
            ++ COMISIÓN  

            Métodos:
            BuscaVendedor() Devuelve el Vendedor buscado con todos sus datos
            CálculaComisión() Ojo los parámetros
            ++ CONSTRUCTOR SOBRECARGADO
            ++ DESTRUCTOR

        Clase NOMBRE
            Propiedades:
            ++ APELLIDO
            ++ PRIMERNOMBRE
            ++ SEGUNDONOMBRE

            Métodos:
            ++ CONSTRUCTOR SOBRECARGADO
            ++ DESTRUCTOR

        >> Aunque no diga de la clase venta, diria que tengo que crearla si o si. ~~ Pregunta pal profe

        Detalle de cálculo de Comisión:
            Si totalVendido < $ 50.000 , la comisión es cero. 
            Si $50.000 <= totalVendido < $75.000, la comisión es del 15%. 
            Si $75.000 <= totalVendido < $100.000, la comisión es del 20%. 
            Si $100.000 <= totalVendido, la comisión es del 30 %. 

        Crear una Solución en Visual Studio tipo Winform C# que permita: 
            ++ 1.	Cargar Vendedores
            2.	Cargar Ventas
            3.	Crear una lista para agregar los vendedores. 
            4.	Cargar en un combo las siguientes Zonas de venta: Mar del Plata, Balcarce, Miramar y Necochea. 
            5.	Para mostrar los totales por zona se debe seleccionar del combo una zona y mostrar las ventas totales de dicha zona y la comisión total. 
            a.	Cuando se selecciona un Vendedor mostrar en datagridview las ventas
            b.	Mostrar en ListView las comisiones y en un label la suma
            6.	Eliminar Ventas
            7.	Eliminar Vendedores
            8.	Mostrar el Total de Ventas
            9.	Persistir en un archivo los datos del Vendedor
            10.	Persistir en un archivo los datos de las ventas
            11.	Diagrama de Clases participantes

        Agregar los métodos que crea necesarios
  
        */
    }
}
