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
    public partial class wdwMaterias : Form
    {
        public wdwMaterias()
        {
            InitializeComponent();
        }

        public void inicializaControles()
        {
            txtNombre.Clear();
            numHorasClase.Value = 1;
        }

        public void cargaDatos_Control(DataGridViewRow s)
        {
            txtNombre.Text = s.Cells["Nombre"].Value.ToString();
            numHorasClase.Value = Convert.ToDecimal(s.Cells["Num_Horas_Clase"].Value);
        }

        public void alta_Materia()
        {
            if (validaDatos())
            {
                CBaseDatos db = new CBaseDatos();
                SqlException error = db.sql("INSERT INTO Horarios.Materia(Nombre, Num_Horas_Clase) VALUES('" + txtNombre.Text + "' , " + Convert.ToInt32(numHorasClase.Value) + ")");
                db.Dispose();
                if (error != null)
                    MessageBox.Show("No se puede insertar un nombre de materia duplicado: " + txtNombre.Text, "Alta Materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            inicializaControles();
        }

        public void baja_Materia(int idMateria)
        {
            CBaseDatos db = new CBaseDatos();
            DataSet ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Materia = " + idMateria);
            if (ds.Tables[0].Rows.Count > 0)
                MessageBox.Show("No se puede eliminar la materia por que esta asignada a un horario", "Eliminación Materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                db.sql("DELETE FROM Horarios.Materia WHERE Id_Materia = " + idMateria);
                
            }
            inicializaControles();

            db.Dispose();
        }

        public void modifica_Materia(int idMateria)
        {
            if (validaDatos())
            {
                CBaseDatos db = new CBaseDatos();
                SqlException error = db.sql("UPDATE Horarios.Materia SET Nombre = '" + txtNombre.Text + "', Num_Horas_Clase = " + Convert.ToInt32(numHorasClase.Value) + " WHERE Id_Materia = " + idMateria);
                db.Dispose();
                if (error != null)
                    MessageBox.Show("Un nombre de materia no puede estar duplicado: " + txtNombre.Text, "Edición Materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            inicializaControles();
        }

        private bool validaDatos()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de materia es obligatorio", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(numHorasClase.Value <= 0)
            {
                MessageBox.Show("El número de horas debe ser mayor a 0", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
