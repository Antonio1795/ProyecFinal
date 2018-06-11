using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyecFinal
{
    class VentasEmpleadosporMes
    {
        string codigoempleado;
        int mes;
        int cantidadvendida=0;
        Decimal totalvendido=0;

        public string Codigoempleado { get => codigoempleado; set => codigoempleado = value; }
       public int Cantidadvendida { get => cantidadvendida; set => cantidadvendida = value; }
        public decimal Totalvendido { get => totalvendido; set => totalvendido = value; }
        public int Mes1 { get => mes; set => mes = value; }
    }
}
