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
    public partial class wdwChecador : Form
    {
        private int idHorario;
        public wdwChecador()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void wdwChecador_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
            String dia = obtenDiaActual();
            String semestres = obtenSemestresActuales();
            String anio = DateTime.Now.Year.ToString();
            construyeTablaHorario(dia, semestres, anio);
            cargaComboProfesores(dia, semestres, anio);
        }

        private String obtenDiaActual()
        {
            String dia = "";

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dia = "L";
                    break;
                case DayOfWeek.Tuesday:
                    dia = "Ma";
                    break;
                case DayOfWeek.Wednesday:
                    dia = "Mi";
                    break;
                case DayOfWeek.Thursday:
                    dia = "J";
                    break;
                case DayOfWeek.Friday:
                    dia = "V";
                    break;
            }

            return dia;
        }

        private String obtenSemestresActuales()
        {
            String semestres = "";

            if (DateTime.Now.Month >= 8 && DateTime.Now.Month <= 12)
                semestres = "1,3,5";
            else
                if (DateTime.Now.Month >= 2 && DateTime.Now.Month <= 6)
                    semestres = "2,4,6";

            return semestres;
        }

        private void construyeTablaHorario(String dia, String semestres, String anio)
        {
            agregaGruposTabla(semestres, anio);
            agregaHorasTabla();
            agregaClasesTabla(dia, semestres, anio);
        }

        private void agregaGruposTabla(String semestres, String anio)
        {
            CBaseDatos db = new CBaseDatos();
            String query = "SELECT CAST(G.Semestre AS VARCHAR(5)) + G.Grupo AS Grupo  ";
            query += "FROM Horarios.Grupo G ";
            query += "WHERE G.Ciclo_Escolar LIKE '%" + anio + "%' AND Semestre IN (" + semestres + ")";

            DataSet ds = db.consulta(query);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    gridHorario.Columns.Add(dr["Grupo"].ToString(), dr["Grupo"].ToString());
                    gridHorario.Columns[dr["Grupo"].ToString()].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error en la conexión a la base de datos, por favor consulte al administrador del sistema", "Error en conexión a Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            db.Dispose();
        }

        private void agregaHorasTabla()
        {
            CBaseDatos db = new CBaseDatos();
            String query = "SELECT CONVERT(varchar(10), HC.Hora_Inicio, 100) AS Hora ";
            query += "FROM Horarios.Hora_Clase HC";

            DataSet ds = db.consulta(query);
            int i = 0;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                gridHorario.Rows.Add();
                gridHorario.Rows[i].HeaderCell.Value = dr["Hora"]; 
                i++;
            }

            db.Dispose();
        }

        private void agregaClasesTabla(String dia, String semestres, String anio)
        {
            CBaseDatos db = new CBaseDatos();
            String query = "";
            String hora_ini = "";
            DataSet ds = null;

            foreach (DataGridViewRow row in gridHorario.Rows)
            {
                hora_ini = row.HeaderCell.Value.ToString();
                query = "SELECT M.Nombre AS Materia, P.Nombre As Prof, CAST(G.Semestre AS VARCHAR(5)) + G.Grupo AS Grupo ";
                query += "FROM Horarios.Horario H ";
                query += "INNER JOIN Horarios.Materia M ON M.Id_Materia = H.Id_Materia ";
                query += "INNER JOIN Horarios.Profesor P ON P.Id_Profesor = H.Id_Profesor ";
                query += "INNER JOIN Horarios.Grupo G ON G.Id_Grupo = H.Id_Grupo ";
                query += "INNER JOIN Horarios.Hora_Clase HC ON HC.Id_Hora_Clase = H.Id_Hora_Clase ";
                query += "WHERE H.Dia_Semana LIKE '%" + dia + "%' AND G.Ciclo_Escolar LIKE '%" + anio + "%' AND G.Semestre IN (" + semestres + ") ";
                query += "AND HC.Hora_Inicio = '" + hora_ini + "'";
                ds = db.consulta(query);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    row.Cells[dr["Grupo"].ToString()].Value = dr["Materia"].ToString() + Environment.NewLine + dr["Prof"].ToString();
                }
            }
        }

        private void cargaComboProfesores(String dia, String semestres, String anio)
        {
            CBaseDatos bd = new CBaseDatos();
            DataSet ds = bd.consulta("SELECT Id_Profesor, Nombre  FROM Horarios.Profesor");
            cbProfesor.DataSource = ds.Tables[0];
            cbProfesor.ValueMember = "Id_Profesor";
            cbProfesor.DisplayMember = "Nombre";
            bd.Dispose();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(this.validaDatos())
            {
                string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                string hora = DateTime.Now.TimeOfDay.ToString();
                string firma = this.txtFirma.Text;
                CBaseDatos db = new CBaseDatos();
                db.sql("INSERT INTO ControlPagos.Registro_Asistencia(Id_Horario, Fecha, Hora, Firma) VALUES(" + idHorario + ", '" + fecha + "', '" + hora + "', '" + firma + "')");
                db.Dispose();
                MessageBox.Show("Se registró la asistencia con éxito", "Registro asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridHorario_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool validaDatos()
        {
            if(cbProfesor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un profesor para registrar su asistencia", "Registro de asistenacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(String.IsNullOrEmpty(txtFirma.Text) || String.IsNullOrWhiteSpace(txtFirma.Text))
            {
                MessageBox.Show("Debe ingresar la firma del profesor para registrar su asistencia", "Registro de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            CBaseDatos db = new CBaseDatos();
            long idProfesor = Convert.ToInt64(cbProfesor.SelectedValue);
            String hora = DateTime.Now.TimeOfDay.ToString();
            String dia = obtenDiaActual();
            String semestres = obtenSemestresActuales();
            String anio = DateTime.Now.Year.ToString();
            String query = "SELECT * FROM Horarios.Horario H ";
            query += "INNER JOIN Horarios.Grupo G ON G.Id_Grupo = H.Id_Grupo ";
            query += "INNER JOIN Horarios.Profesor P ON P.Id_Profesor = H.Id_Profesor ";
            query += "INNER JOIN Horarios.Hora_Clase HC ON HC.Id_Hora_Clase = H.Id_Hora_Clase ";
            query += "WHERE G.Ciclo_Escolar LIKE '%" + anio + "%' AND H.Dia_Semana LIKE '%" + dia + "%' AND G.Semestre IN (" + semestres + ") ";
            query += "AND P.Id_Profesor = " + idProfesor + " AND DATEADD(minute, -15, HC.Hora_Inicio)  <= '" + hora + "' AND DATEADD(minute, -15, HC.Hora_Fin) >= '" + hora + "'";

            DataSet ds = db.consulta(query);

            if(ds.Tables[0].Rows.Count == 0)
            {
                db.Dispose();
                MessageBox.Show("El profesor no tiene una clase en esta hora, no se puede registrar su asistencia", "Registro de asistenacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if(ds.Tables[0].Rows[0]["Firma"].ToString() != this.txtFirma.Text)
                {
                    db.Dispose();
                    MessageBox.Show("La firma del profesor no es correcta, por favor ingrese la firma correcta", "Registro de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (ds.Tables[0].Rows.Count > 1)
                {
                    db.Dispose();
                    MessageBox.Show("Incongruencia en la información, existen mas de una clase asignadas al profesor", "Registro de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    //db.Dispose();
                    //CBaseDatos db2 = new CBaseDatos();
                    idHorario = Convert.ToInt32(ds.Tables[0].Rows[0]["Id_Horario"]);
                    String hoy = DateTime.Now.ToString("dd/MM/yyyy");
                    String query2 = "SELECT * FROM ControlPagos.Registro_Asistencia WHERE Id_Horario = " + idHorario + " AND Fecha = '" + hoy + "' AND Hora BETWEEN CONVERT(VARCHAR(5), DATEADD(minute, -15, '" + ds.Tables[0].Rows[0]["Hora_Inicio"].ToString() + "'), 108) AND CONVERT(VARCHAR(5), DATEADD(minute, -15, '" + ds.Tables[0].Rows[0]["Hora_Fin"].ToString() + "'), 108)";
                    DataSet ds2 = db.consulta(query2);
                    if(ds2.Tables[0].Rows.Count > 0)
                    {
                        db.Dispose();
                        MessageBox.Show("Ya se registró una asistencia en esta clase para el profesor", "Registro asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    db.Dispose();
                }
            }

            return true;
        }
    }
}