using RelojChecador.Clases;
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
    public partial class wdwReporte : Form
    {
        public wdwReporte()
        {
            InitializeComponent();
        }

        private void wdwReporte_Load(object sender, EventArgs e)
        {
            CBaseDatos bd = new CBaseDatos();
            DataSet dataCiclos = bd.consulta("SELECT DISTINCT(Ciclo_Escolar) FROM Horarios.Grupo");
            this.cbciclos.DataSource = dataCiclos.Tables[0];
            this.cbciclos.DisplayMember = "Ciclo_Escolar";
            this.cbciclos.ValueMember = "Ciclo_Escolar";
            bd.Dispose();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CBaseDatos bd = new CBaseDatos();
            String query = "SELECT * FROM Horarios.Materia ";
            query += "WHERE Id_Materia IN(";
            query += "SELECT DISTINCT (M.Id_Materia) ";
            query += "FROM Horarios.Materia M ";
            query += "INNER JOIN Horarios.Horario H ON H.Id_Materia = M.Id_Materia ";
            query += "INNER JOIN Horarios.Grupo G On H.Id_Grupo = G.Id_Grupo ";
            query += "WHERE G.Ciclo_Escolar = '" + this.cbciclos.SelectedValue.ToString() + "')";
            DataSet dataMaterias = bd.consulta(query);

            this.gridMaterias.DataSource = dataMaterias.Tables[0];
        }
    }
}
