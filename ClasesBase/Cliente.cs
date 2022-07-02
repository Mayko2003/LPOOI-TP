using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Cliente
    {
        private string cli_DNI;

        public string Cli_DNI
        {
            get { return cli_DNI; }
            set { cli_DNI = value; }
        }
        private string cli_Apellido;

        public string Cli_Apellido
        {
            get { return cli_Apellido; }
            set { cli_Apellido = value; }
        }
        private string cli_Nombre;

        public string Cli_Nombre
        {
            get { return cli_Nombre; }
            set { cli_Nombre = value; }
        }
        private string cli_NroCarnet;

        public string Cli_NroCarnet
        {
            get { return cli_NroCarnet; }
            set { cli_NroCarnet = value; }
        }
        private string os_CUIT;

        public string Os_CUIT
        {
            get { return os_CUIT; }
            set { os_CUIT = value; }
        }

        private string cli_Direccion;

        public string Cli_Direccion
        {
            get { return cli_Direccion; }
            set { cli_Direccion = value; }
        }

        private bool cli_Estado;
        public bool Cli_Estado {
            get { return this.cli_Estado; }
            set { this.cli_Estado = value; }
        }
    }
}
