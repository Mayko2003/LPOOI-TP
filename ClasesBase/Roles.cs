using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Roles
    {
        private int rol_codigo;

        public int Rol_codigo
        {
            get { return rol_codigo; }
            set { rol_codigo = value; }
        }
        private string rol_Descripcion;

        public string Rol_Descripcion
        {
            get { return rol_Descripcion; }
            set { rol_Descripcion = value; }
        }
    }
}
