using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vistas
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            this.SendToBack();
        }
    }
}
