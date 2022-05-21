using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Venta
    {
        private int ven_Nro;
        public int Ven_Nro
        {
            get { return this.ven_Nro; }
            set { this.ven_Nro = value; }
        }

        private DateTime ven_Fecha;
        public DateTime Ven_Fecha
        {
            get { return this.ven_Fecha; }
            set { this.ven_Fecha = value; }
        }

        private string cli_DNI;
        public string Cli_DNI
        {
            get { return this.cli_DNI; }
            set { this.cli_DNI = value; }
        }

        public Venta() { }

        public Venta(int nro, DateTime fecha, string cli_dni)
        {
            this.ven_Nro = nro;
            this.ven_Fecha = fecha;
            this.cli_DNI = cli_dni;
        }
    }
}
