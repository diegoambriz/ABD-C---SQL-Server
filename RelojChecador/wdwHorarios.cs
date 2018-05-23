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
    public partial class wdwHorarios : Form
    {
        public wdwHorarios()
        {
            InitializeComponent();
        }

        public void inicializaControles()
        {
            cargaComboGrupos();
            cargaComboMaterias();
            cargaComboProfesores();
            cargaComboHorasClase();
            limpiaControles();
        }

        private void cargaComboGrupos()
        {
            CBaseDatos bd = new CBaseDatos();
            DataSet ds = bd.consulta("SELECT Id_Grupo, Ciclo_Escolar + '/' + cast(Semestre AS VARCHAR(2))  + Grupo AS nombreGrupo FROM Horarios.Grupo");
            cbGrupos.DataSource = ds.Tables[0];
            cbGrupos.ValueMember = "Id_Grupo";
            cbGrupos.DisplayMember = "nombreGrupo";
            bd.Dispose();
        }

        private void cargaComboMaterias()
        {
            CBaseDatos bd = new CBaseDatos();
            DataSet ds = bd.consulta("SELECT Id_Materia, Nombre  FROM Horarios.Materia");
            cbMateria.DataSource = ds.Tables[0];
            cbMateria.ValueMember = "Id_Materia";
            cbMateria.DisplayMember = "Nombre";
            bd.Dispose();
        }

        private void cargaComboProfesores()
        {
            CBaseDatos bd = new CBaseDatos();
            DataSet ds = bd.consulta("SELECT Id_Profesor, Nombre  FROM Horarios.Profesor");
            cbProfesor.DataSource = ds.Tables[0];
            cbProfesor.ValueMember = "Id_Profesor";
            cbProfesor.DisplayMember = "Nombre";
            bd.Dispose();
        }

        private void cargaComboHorasClase()
        {
            CBaseDatos bd = new CBaseDatos();
            DataSet ds = bd.consulta("SELECT Id_Hora_Clase, CONVERT(varchar(10), Hora_Inicio, 100) + ' - ' + CONVERT(VARCHAR(10), Hora_Fin, 100) AS HORARIO FROM Horarios.Hora_Clase");
            cbHoraClase.DataSource = ds.Tables[0];
            cbHoraClase.ValueMember = "Id_Hora_Clase";
            cbHoraClase.DisplayMember = "HORARIO";
            bd.Dispose();
        }

        private void desmarcaChecksDias()
        {
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
        }

        private void limpiaControles()
        {
            cbGrupos.SelectedIndex = -1;
            cbMateria.SelectedIndex = -1;
            cbProfesor.SelectedIndex = -1;
            cbHoraClase.SelectedIndex = -1;
            desmarcaChecksDias();
        }

        public void cargaDatos_Control(DataGridViewRow filaSelect)
        {
            limpiaControles();
            cargaDatoComboGrupo(filaSelect.Cells["Grupo"].Value.ToString());
            cargaDatoComboMateria(filaSelect.Cells["Materia"].Value.ToString());
            cargaDatoComboProfesor(filaSelect.Cells["Profesor"].Value.ToString());
            cargaDatoComboHoraClase(filaSelect.Cells["HoraClase"].Value.ToString());
            cargaDatoChecksDias(filaSelect.Cells["Dia_Semana"].Value.ToString());
        }

        public void alta_Horario()
        {
            if (validaDatos(-1))
            {
                String diaSemana = generaCadenaDias();
                CBaseDatos db = new CBaseDatos();
                db.sql("INSERT INTO Horarios.Horario(Id_Hora_Clase, Id_Grupo, Id_Materia, Id_Profesor, Dia_Semana) VALUES(" + cbHoraClase.SelectedValue + ", " + cbGrupos.SelectedValue + ", " + cbMateria.SelectedValue + ", " + cbProfesor.SelectedValue + ", '" + diaSemana + "')");
                db.Dispose();
            }
            limpiaControles();
        }

        public void baja_Horario(int idHorario)
        {
            CBaseDatos db = new CBaseDatos();
            db.sql("DELETE FROM Horarios.Horario WHERE Id_Horario = " + idHorario);
            db.Dispose();
            limpiaControles();
        }

        public void modifica_Horario(int idHorario)
        {
            if (validaDatos(idHorario))
            {
                String diaSemana = generaCadenaDias();
                CBaseDatos db = new CBaseDatos();
                db.sql("UPDATE Horarios.Horario SET Id_Hora_Clase = " + cbHoraClase.SelectedValue + ", Id_Grupo = " + cbGrupos.SelectedValue + ", Id_Materia = " + cbMateria.SelectedValue + ", Id_Profesor = " + cbProfesor.SelectedValue + ", Dia_Semana = '" + diaSemana + "' WHERE Id_Horario = " + idHorario);
                db.Dispose();
            }
            limpiaControles();
        }

        private String generaCadenaDias()
        {
            String dias = "";

            if (chkLunes.Checked)
                dias += "L";
            if(chkMartes.Checked)
                dias += "Ma";
            if (chkMiercoles.Checked)
                dias += "Mi";
            if (chkJueves.Checked)
                dias += "J";
            if (chkViernes.Checked)
                dias += "V";

            return dias;
        }

        private void cargaDatoComboGrupo(String datoGrupo)
        {
            foreach (DataRowView dr in cbGrupos.Items)
            {
                if (dr.Row.ItemArray[1].ToString() == datoGrupo)
                {
                    cbGrupos.SelectedIndex = cbGrupos.Items.IndexOf(dr);
                    break;
                }
            }
        }

        private void cargaDatoComboMateria(String datoMateria)
        {
            foreach (DataRowView dr in cbMateria.Items)
            {
                if (dr.Row.ItemArray[1].ToString() == datoMateria)
                {
                    cbMateria.SelectedIndex = cbMateria.Items.IndexOf(dr);
                    break;
                }
            }
        }

        private void cargaDatoComboProfesor(String datoProfesor)
        {
            foreach (DataRowView dr in cbProfesor.Items)
            {
                if (dr.Row.ItemArray[1].ToString() == datoProfesor)
                {
                    cbProfesor.SelectedIndex = cbProfesor.Items.IndexOf(dr);
                    break;
                }
            }
        }

        private void cargaDatoComboHoraClase(String datoHoraClase)
        {
            foreach (DataRowView dr in cbHoraClase.Items)
            {
                if (dr.Row.ItemArray[1].ToString() == datoHoraClase)
                {
                    cbHoraClase.SelectedIndex = cbHoraClase.Items.IndexOf(dr);
                    break;
                }
            }
        }

        private void cargaDatoChecksDias(String dias)
        {
            if (dias.Contains("L"))
                chkLunes.Checked = true;
            if (dias.Contains("Ma"))
                chkMartes.Checked = true;
            if (dias.Contains("Mi"))
                chkMiercoles.Checked = true;
            if (dias.Contains("J"))
                chkJueves.Checked = true;
            if (dias.Contains("V"))
                chkViernes.Checked = true;
        }

        private bool validaDatos(int idModifica)
        {
            if(cbGrupos.SelectedIndex == -1)
            {
                MessageBox.Show("El grupo es obligatorio, no se ha seleccionado uno", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(cbMateria.SelectedIndex == -1)
            {
                MessageBox.Show("La materia es obligatoria, no se ha seleccionado una", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(cbProfesor.SelectedIndex == -1)
            {
                MessageBox.Show("El profesor es obligatorio, no se ha seleccionado uno", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(cbHoraClase.SelectedIndex == -1)
            {
                MessageBox.Show("La hora clase es obligatoria, no se ha seleccionado una", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(!chkLunes.Checked && !chkMartes.Checked && !chkMiercoles.Checked && !chkJueves.Checked && !chkViernes.Checked)
            {
                MessageBox.Show("El horario debe tener al menos un día asignado, no se ha seleccionado uno", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!validaDatosUnicosGrupo(idModifica))
                return false;

            if (!validaDatosUnicosProfesor(idModifica))
                return false;

            return true;
        }

        private bool validaDatosUnicosGrupo(int idModifica)
        {
            CBaseDatos db = new CBaseDatos();
            int idGrupo = Convert.ToInt32(cbGrupos.SelectedValue);
            int idMateria = Convert.ToInt32(cbMateria.SelectedValue);
            int idHoraClase = Convert.ToInt32(cbHoraClase.SelectedValue);
            string cadenaDias = generaCadenaDias();

            DataSet ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Grupo = " + idGrupo + "AND Id_Materia = " + idMateria + " AND Id_Horario != " + idModifica);
            if(ds.Tables[0].Rows.Count > 0)
            {
                DataSet ds2 = db.consulta("SELECT Num_Horas_Clase FROM Horarios.Materia WHERE Id_Materia = " + idMateria);
                int numHoras = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
                int auxHoras = 0;
                int horasAsignar = cuentaDiasSemana(cadenaDias);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    auxHoras += cuentaDiasSemana(r["Dia_Semana"].ToString());
                }
                if((auxHoras + horasAsignar) > numHoras)
                {
                    if (auxHoras == numHoras)
                        MessageBox.Show("El grupo ya tiene asignadas todas las horas de la materia, no se puede registrar", "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("El grupo se pasa con " + ((auxHoras + horasAsignar) - numHoras) + " horas para esta materia, no se puede registrar", "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.Dispose();
                    return false;
                }
            }
            else
            {
                DataSet ds2 = db.consulta("SELECT Num_Horas_Clase FROM Horarios.Materia WHERE Id_Materia = " + idMateria);
                int numHoras = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
                int horasAsignar = cuentaDiasSemana(cadenaDias);
                if (horasAsignar > numHoras)
                {
                    MessageBox.Show("El grupo se pasa con " + (horasAsignar - numHoras) + " horas para esta materia, no se puede registrar", "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.Dispose();
                    return false;
                }
            }

            ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Grupo = " + idGrupo + " AND Id_Hora_Clase = " + idHoraClase + " AND Id_Horario != " + idModifica);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow r in ds.Tables[0].Rows)
                {
                    if(!comparaDiasHoraClase(r["Dia_Semana"].ToString(), cadenaDias, true))
                    {
                        db.Dispose();
                        return false;
                    }
                }
            }

            db.Dispose();
            return true;
        }

        private bool validaDatosUnicosProfesor(int idModifica)
        {
            int idHoraClase = Convert.ToInt32(cbHoraClase.SelectedValue);
            int idProfesor = Convert.ToInt32(cbProfesor.SelectedValue);
            string cadenaDias = generaCadenaDias();
            CBaseDatos db = new CBaseDatos();

            DataSet ds = db.consulta("SELECT * FROM Horarios.Horario WHERE Id_Hora_Clase = " + idHoraClase + " AND Id_Profesor = " + idProfesor + " AND Id_Horario != " + idModifica);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (!comparaDiasHoraClase(r["Dia_Semana"].ToString(), cadenaDias, false))
                    {
                        db.Dispose();
                        return false;
                    }
                }
            }

            db.Dispose();
            return true;
        }

        private int cuentaDiasSemana(String cadenaDias)
        {
            int numDias = 0;

            if (cadenaDias.Contains("L"))
                numDias++;
            if (cadenaDias.Contains("Ma"))
                numDias++;
            if (cadenaDias.Contains("Mi"))
                numDias++;
            if (cadenaDias.Contains("J"))
                numDias++;
            if (cadenaDias.Contains("V"))
                numDias++;

            return numDias;
        }

        private bool comparaDiasHoraClase(String cad1, String cad2, bool grupo)
        {
            String hora = cbHoraClase.Text;

            if(cad1.Contains("L") && cad2.Contains("L"))
            {
                if(grupo)
                    MessageBox.Show("El grupo ya tiene una materia asignada el Lunes en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("El profesor ya tiene un grupo asignado el Lunes en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cad1.Contains("Ma") && cad2.Contains("Ma"))
            {
                if(grupo)
                    MessageBox.Show("El grupo ya tiene una materia asignada el Martes en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("El profesor ya tiene un grupo asignado el Martes en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cad1.Contains("Mi") && cad2.Contains("Mi"))
            {
                if(grupo)
                    MessageBox.Show("El grupo ya tiene una materia asignada el Miércoles en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("El profesor ya tiene un grupo asignado el Miércoles en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cad1.Contains("J") && cad2.Contains("J"))
            {
                if(grupo)
                    MessageBox.Show("El grupo ya tiene una materia asignada el Jueves en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("El profesor ya tiene un grupo asignado el Jueves en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cad1.Contains("V") && cad2.Contains("V"))
            {
                if(grupo)
                    MessageBox.Show("El grupo ya tiene una materia asignada el Viernes en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("El profesor ya tiene un grupo asignado el Viernes en la clase " + hora, "Alta horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
