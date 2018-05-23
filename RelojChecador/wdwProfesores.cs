using RelojChecador.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelojChecador
{
    public partial class wdwProfesores : Form
    {
        public wdwProfesores()
        {
            InitializeComponent();
        }

        public void inicializaControles()
        {
            txtNombre.Clear();
            dtFechaNac.MaxDate = DateTime.Now.AddDays(1);
            dtFechaNac.Value = DateTime.Now;
            txtRFC.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtFirma.Clear();
        }

        public void cargaDatos_Control(DataGridViewRow s)
        {
            txtNombre.Text = s.Cells["Nombre"].Value.ToString();
            dtFechaNac.Value = Convert.ToDateTime(s.Cells["Fecha_Nacimiento"].Value);
            txtRFC.Text = s.Cells["RFC"].Value.ToString();
            txtDireccion.Text = s.Cells["Direccion"].Value.ToString();
            txtTelefono.Text = s.Cells["Telefono"].Value.ToString();
            txtFirma.Text = s.Cells["Firma"].Value.ToString();
        }

        public void alta_Profesor()
        {
            if (validaDatos())
            {
                CBaseDatos db = new CBaseDatos();
                db.sql("INSERT INTO Horarios.Profesor(Nombre, Direccion, Telefono, Fecha_Nacimiento, RFC, Firma) VALUES('" + txtNombre.Text + "' , '" + txtDireccion.Text + "', '" + txtTelefono.Text + "', '" + dtFechaNac.Text + "', '" + txtRFC.Text + "', '" + txtFirma.Text + "')");
                db.Dispose();
            }
            inicializaControles();
        }

        public void baja_Profesor(int idProfesor)
        {
            CBaseDatos db = new CBaseDatos();
            DataSet ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Profesor = " + idProfesor);
            if (ds.Tables[0].Rows.Count > 0)
                MessageBox.Show("No se puede eliminar el profesor ya que esta asignado a un horario", "Eliminación Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                db.sql("DELETE FROM Horarios.Profesor WHERE Id_Profesor = " + idProfesor);
                inicializaControles();
            }

            db.Dispose();
        }

        public void modifica_Profesor(int idProfesor)
        {
            if (validaDatos())
            {
                CBaseDatos db = new CBaseDatos();
                db.sql("UPDATE Horarios.Profesor SET Nombre = '" + txtNombre.Text + "', Direccion = '" + txtDireccion.Text + "', Telefono = '" + txtTelefono.Text + "', Fecha_Nacimiento = '" + dtFechaNac.Text + "',  RFC = '" + txtRFC.Text + "', Firma = '" + txtFirma.Text + "' WHERE Id_Profesor = " + idProfesor);
                db.Dispose();
            }
            inicializaControles();
        }

        private bool validaDatos()
        {
            if(String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de profesor es obligatorio", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if(dtFechaNac.Value == null)
            {
                MessageBox.Show("La fecha de nacimiento del profesor es obligatoria", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (String.IsNullOrEmpty(txtRFC.Text) || String.IsNullOrWhiteSpace(txtRFC.Text))
            {
                MessageBox.Show("El RFC del profesor es obligatorio", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(txtRFC.Text.Length > 13)
            {
                MessageBox.Show("El RFC debe ser máximo de 13 caracteres", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección del profesor es obligatoria", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (String.IsNullOrEmpty(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono del profesor es obligatorio", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(txtTelefono.Text.Length > 10 || txtTelefono.Text.Length < 7)
            {
                MessageBox.Show("El telefono debe ser entre 7 y 10 caracteres", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(txtTelefono.Text.StartsWith("0"))
            {
                MessageBox.Show("El telefono no puede iniciar con 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Regex re = new Regex(@"[0-9]+");
            if(!re.Match(txtTelefono.Text).Success)
            {
                MessageBox.Show("El telefono debe contener solo números", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(String.IsNullOrEmpty(txtFirma.Text) || String.IsNullOrWhiteSpace(txtFirma.Text))
            {
                MessageBox.Show("La firma del profesor es obligatoria", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
