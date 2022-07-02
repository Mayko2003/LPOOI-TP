using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Producto
    {
        private string prod_Codigo;

        public string Prod_Codigo
        {
            get { return prod_Codigo; }
            set { prod_Codigo = value; }
        }
        private string prod_Categoria;

        public string Prod_Categoria
        {
            get { return prod_Categoria; }
            set { prod_Categoria = value; }
        }
        private string prod_Descripcion;

        public string Prod_Descripcion
        {
            get { return prod_Descripcion; }
            set { prod_Descripcion = value; }
        }
        private decimal prod_precio;

        public decimal Prod_precio
        {
            get { return prod_precio; }
            set { prod_precio = value; }
        }

        private bool prod_estado;

        public bool Prod_Estado
        {
            get { return this.prod_estado; }
            set { this.prod_estado = value; }
        }
    }
}
