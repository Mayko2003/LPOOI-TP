using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class VentaDetalle
    {

        #region Atributos
        private int det_Nro;
        public int Det_Nro
        {
            get { return this.det_Nro; }
            set { this.det_Nro = value; }
        }

        private int ven_Nro;
        public int Ven_Nro
        {
            get { return this.ven_Nro; }
            set { this.ven_Nro = value; }
        }

        private string prod_Codigo;
        public string Prod_Codigo
        {
            get { return this.prod_Codigo; }
            set { this.prod_Codigo = value; }
        }

        private decimal det_Cantidad;
        public decimal Det_Cantidad
        {
            get { return this.det_Cantidad; }
            set { this.det_Cantidad = value; }
        }

        private decimal det_Precio;
        public decimal Det_Precio
        {
            get { return this.det_Precio; }
            set { this.det_Precio = value; }
        }
        private decimal det_Total;
        public decimal Det_Total
        {
            get { return this.det_Total; }
            set { this.det_Total = value; }
        }
        #endregion


        public VentaDetalle() { }
    }
}
