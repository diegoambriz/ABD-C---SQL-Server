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
    public partial class wdwHorasClase : Form
    {
        public wdwHorasClase()
        {
            InitializeComponent();
        }

        public void inicializaControles()
        {
            dtHoraInicio.Value = DateTime.Now;
            dtHoraFin.Value = DateTime.Now;
        }

        public void cargaDatos_Control(DataGridViewRow s)
        {
            dtHoraInicio.Value = Convert.ToDateTime(s.Cells["Hini"].Value.ToString());
            dtHoraFin.Value = Convert.ToDateTime(s.Cells["Hfin"].Value.ToString());
        }

        public void alta_Hora_Clase()
        {
            if (validaDatos(-1))
            {
                CBaseDatos db = new CBaseDatos();
                db.sql("INSERT INTO Horarios.Hora_Clase(Hora_Inicio, Hora_Fin) VALUES('" + dtHoraInicio.Value.ToString("HH:mm") + "', '" + dtHoraFin.Value.ToString("HH:mm") + "')");
                db.Dispose();
            }
            inicializaControles();
        }

        public void baja_HoraClase(int idHoraClase)
        {
            CBaseDatos db = new CBaseDatos();
            DataSet ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Hora_Clase = " + idHoraClase);
            if (ds.Tables[0].Rows.Count > 0)
                MessageBox.Show("No se puede eliminar la hora-clase porque está asignada a un horario", "Eliminación Hora-Clase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                db.sql("DELETE FROM Horarios.Hora_Clase WHERE Id_Hora_Clase = " + idHoraClase);
                inicializaControles();
            }

            db.Dispose();
        }

        public void modifica_HoraClase(int idHoraClase)
        {
            if (validaDatos(idHoraClase))
            {
                CBaseDatos db = new CBaseDatos();
                db.sql("UPDATE Horarios.Hora_Clase SET Hora_Inicio = '" + dtHoraInicio.Value.ToString("HH:mm") + "', Hora_Fin = '" + dtHoraFin.Value.ToString("HH:mm") + "' WHERE Id_Hora_Clase = " + idHoraClase);
                db.Dispose();
            }
            inicializaControles();
        }

        private bool validaDatos(int idModifica)
        {
            if (dtHoraInicio.Value == null)
            {
                MessageBox.Show("La hora de inicio es obligatoria", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(dtHoraFin.Value == null)
            {
                MessageBox.Show("La hora de fin es obligatoria", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return validaDuplicados(idModifica);
        }

        private bool validaDuplicados(int idModifica)
        {
            String horaIni = dtHoraInicio.Value.ToString("HH:mm");
            String horaFin = dtHoraFin.Value.ToString("HH:mm");
            CBaseDatos db = new CBaseDatos();
            DataSet ds = db.consulta("SELECT * FROM Horarios.Hora_Clase WHERE Hora_Inicio = '" + horaIni + "' AND Hora_Fin = '" + horaFin + "' AND Id_Hora_Clase != " + idModifica);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Ya existe una hora clase con las mismas horas de inicio y de fin", "Datos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.Dispose();
                return false;
            }

            //Validaciones para horas entre horas ya registradas
            ds = db.consulta("SELECT * FROM Horarios.Hora_Clase WHERE Hora_Inicio < '" + horaIni + "' AND Hora_Fin > '" + horaIni + "' AND Id_Hora_Clase != " + idModifica);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("La hora de inicio no puede estar entre otras horas clase ya registradas", "Datos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.Dispose();
                return false;
            }

            ds = db.consulta("SELECT * FROM Horarios.Hora_Clase WHERE Hora_Inicio < '" + horaFin + "' AND Hora_Fin > '" + horaFin + "' AND Id_Hora_Clase != " + idModifica);
            if(ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("La hora de fin no puede estar entre horas clase ya registradas", "Datos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.Dispose();
                return false;
            }

            db.Dispose();
            return true;
        }
    }
}
