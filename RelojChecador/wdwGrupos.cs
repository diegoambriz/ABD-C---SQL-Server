using RelojChecador.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelojChecador
{
    public partial class wdwGrupos : Form
    {
        public wdwGrupos()
        {
            InitializeComponent();
        }

        public void inicializaControles()
        {
            txtCicloEscolar.Clear();
            numSemestre.Value = 1;
            txtGrupo.Clear();
        }

        public void alta_Grupo()
        {
            if (validaDatos(-1))
            {
                CBaseDatos db = new CBaseDatos();
                SqlException error = db.sql("INSERT INTO Horarios.Grupo(Ciclo_Escolar, Semestre, Grupo) VALUES('" + txtCicloEscolar.Text + "', " + Convert.ToInt32(numSemestre.Value) + ", '" + txtGrupo.Text + "' )");
                db.Dispose();
                if(error != null)
                    MessageBox.Show("Por regla en base de datos el grupo solo puede ser A,B o C, favor de verificarlo", "Alta Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            inicializaControles();
        }

        public void baja_Grupo(int idGrupo)
        {
            CBaseDatos db = new CBaseDatos();
            DataSet ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Grupo = " + idGrupo);
            if (ds.Tables[0].Rows.Count > 0)
                MessageBox.Show("No se puede eliminar el grupo porque está asignado a un horario", "Eliminación Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                db.sql("DELETE FROM Horarios.Grupo WHERE Id_Grupo = " + idGrupo);
                inicializaControles();
            }

            db.Dispose();
        }

        public void modifica_Grupo(int idGrupo)
        {
            if (validaDatos(idGrupo))
            {
                CBaseDatos db = new CBaseDatos();
                SqlException error = db.sql("UPDATE Horarios.Grupo SET Ciclo_Escolar = '" + txtCicloEscolar.Text + "', Semestre = " + Convert.ToInt32(numSemestre.Value) + ", Grupo = '" + txtGrupo.Text + "' WHERE Id_Grupo = " + idGrupo);
                db.Dispose();
                if(error != null)
                    MessageBox.Show("Por regla en base de datos el grupo solo puede ser A,B o C, favor de verificarlo", "Edición Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            inicializaControles();
        }

        public void cargaDatos_Control(DataGridViewRow s)
        {
            txtCicloEscolar.Text = s.Cells["Ciclo_Escolar"].Value.ToString();
            numSemestre.Value = Convert.ToDecimal(s.Cells["Semestre"].Value);
            txtGrupo.Text = s.Cells["Grupo"].Value.ToString();
        }

        private bool validaDatos(int idModifica)
        {
            if(String.IsNullOrEmpty(txtCicloEscolar.Text) || String.IsNullOrWhiteSpace(txtCicloEscolar.Text))
            {
                MessageBox.Show("El ciclo escolar es obligatorio", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(String.IsNullOrEmpty(txtGrupo.Text) || String.IsNullOrWhiteSpace(txtGrupo.Text))
            {
                MessageBox.Show("El grupo es obligatorio", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            CBaseDatos db = new CBaseDatos();
            DataSet ds = db.consulta("SELECT * FROM Horarios.Grupo WHERE Ciclo_Escolar = '" + txtCicloEscolar.Text + "' AND Semestre = " + numSemestre.Value + " AND Grupo = '" + txtGrupo.Text + "' AND Id_Grupo != " + idModifica);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("El grupo que se intenta registrar ya existe", "Datos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.Dispose();
                return false;
            }
            db.Dispose();

            return true;
        }
    }
}
