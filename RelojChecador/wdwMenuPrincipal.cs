using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelojChecador
{
    public partial class wdwMenuPrincipal : Form
    {
        public wdwMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Visible = false;
            wdwAdmin wdwAdmon = new wdwAdmin();
            wdwAdmon.ShowDialog();
            Visible = true;
        }

        private void btnReloj_Click(object sender, EventArgs e)
        {
            Visible = false;
            wdwChecador wdwChecador = new wdwChecador();
            wdwChecador.ShowDialog();
            Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            wdwReporte reporte = new wdwReporte();
            reporte.ShowDialog();
            Visible = true;
        }
    }
}
