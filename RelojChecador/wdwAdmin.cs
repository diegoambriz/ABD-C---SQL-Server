using RelojChecador.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelojChecador
{
    public partial class wdwAdmin : Form
    {
        private int opcion;
        private bool conexionOK;

        public wdwAdmin()
        {
            InitializeComponent();
            opcion = 0;
            conexionOK = true;
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            opcion = 1;
            actualizaDatosGrid();
            var form = Application.OpenForms.OfType<wdwProfesores>().FirstOrDefault();
            wdwProfesores wdwProf = form ?? new wdwProfesores();
            wdwProf.inicializaControles();
            agregaFormEnContenedor(wdwProf);
            muestraControles();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            opcion = 2;
            actualizaDatosGrid();
            var form = Application.OpenForms.OfType<wdwMaterias>().FirstOrDefault();
            wdwMaterias wdwMat = form ?? new wdwMaterias();
            wdwMat.inicializaControles();
            agregaFormEnContenedor(wdwMat);
            muestraControles();
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            opcion = 3;
            actualizaDatosGrid();
            var form = Application.OpenForms.OfType<wdwGrupos>().FirstOrDefault();
            wdwGrupos wdwGpos = form ?? new wdwGrupos();
            wdwGpos.inicializaControles();
            agregaFormEnContenedor(wdwGpos);
            muestraControles();
        }

        private void btnHorasClase_Click(object sender, EventArgs e)
        {
            opcion = 4;
            actualizaDatosGrid();
            var form = Application.OpenForms.OfType<wdwHorasClase>().FirstOrDefault();
            wdwHorasClase wdwHrCl = form ?? new wdwHorasClase();
            wdwHrCl.inicializaControles();
            agregaFormEnContenedor(wdwHrCl);
            muestraControles();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            opcion = 5;
            actualizaDatosGrid();
            var form = Application.OpenForms.OfType<wdwHorarios>().FirstOrDefault();
            wdwHorarios wdwHorario = form ?? new wdwHorarios();
            wdwHorario.inicializaControles();
            agregaFormEnContenedor(wdwHorario);
            muestraControles();
        }

        private void actualizaDatosGrid()
        {
            DataSet ds;
            CBaseDatos bd = new CBaseDatos();
            
            switch(opcion)
            {
                case 1:
                    gbTituloDatos.Text = "Profesores";
                    ds = bd.consulta("SELECT * FROM Horarios.Profesor");
                    if (ds != null)
                    {
                        gridViewDatos.DataSource = ds.Tables[0];
                        gridViewDatos.Columns["id_Profesor"].HeaderText = "Id Profesor";
                        gridViewDatos.Columns["Direccion"].HeaderText = "Dirección";
                        gridViewDatos.Columns["Fecha_Nacimiento"].HeaderText = "Fecha de Nacimiento";
                        gridViewDatos.Columns["Horas_Semanales"].HeaderText = "Horas Semanales";
                    }
                    else
                        muestraMensajeErrConexion();
                    break;
                case 2:
                    gbTituloDatos.Text = "Materias";
                    ds = bd.consulta("SELECT * FROM Horarios.Materia");
                    if (ds != null)
                    {
                        gridViewDatos.DataSource = ds.Tables[0];
                        gridViewDatos.Columns["Id_Materia"].HeaderText = "Id Materia";
                        gridViewDatos.Columns["Num_Horas_Clase"].HeaderText = "Numero de Horas Clase";
                    }
                    else
                        muestraMensajeErrConexion();
                    break;
                case 3:
                    gbTituloDatos.Text = "Grupos";
                    ds = bd.consulta("SELECT * FROM Horarios.Grupo");
                    if (ds != null)
                    {
                        gridViewDatos.DataSource = ds.Tables[0];
                        gridViewDatos.Columns["Id_Grupo"].HeaderText = "Id Grupo";
                        gridViewDatos.Columns["Ciclo_Escolar"].HeaderText = "Ciclo Escolar";
                    }
                    else
                        muestraMensajeErrConexion();
                    break;
                case 4:
                    gbTituloDatos.Text = "Horas Clase";
                    ds = bd.consulta("SELECT Id_Hora_Clase, CONVERT(varchar(10), Hora_Inicio, 100) AS Hini, CONVERT(varchar(10), Hora_Fin, 100) AS Hfin FROM Horarios.Hora_Clase");
                    if (ds != null)
                    {
                        gridViewDatos.DataSource = ds.Tables[0];
                        gridViewDatos.Columns["Id_Hora_Clase"].HeaderText = "Id Hora Clase";
                        gridViewDatos.Columns["Hini"].HeaderText = "Hora Inicio";
                        gridViewDatos.Columns["Hfin"].HeaderText = "Hora Fin";
                    }
                    else
                        muestraMensajeErrConexion();
                    break;
                case 5:
                    gbTituloDatos.Text = "Horarios";
                    String query = "SELECT H.Id_Horario, CONVERT(varchar(10), Hora_Inicio, 100) + ' - ' + CONVERT(VARCHAR(10), Hora_Fin, 100) AS HoraClase, G.Ciclo_Escolar + '/' + CAST(G.Semestre AS VARCHAR(2)) + G.Grupo AS Grupo, M.Nombre AS Materia, P.Nombre AS Profesor, H.Dia_Semana ";
                    query += "FROM Horarios.Horario H INNER JOIN Horarios.Hora_Clase HC ON HC.Id_Hora_Clase = H.Id_Hora_Clase INNER JOIN Horarios.Grupo G ON G.Id_Grupo = H.Id_Grupo INNER JOIN Horarios.Materia M ON M.Id_Materia = H.Id_Materia INNER JOIN Horarios.Profesor P ON P.Id_Profesor = H.Id_Profesor";
                    ds = bd.consulta(query);
                    if (ds != null)
                    {
                        gridViewDatos.DataSource = ds.Tables[0];
                        gridViewDatos.Columns["Id_Horario"].HeaderText = "Id Horario";
                        gridViewDatos.Columns["HoraClase"].HeaderText = "Hora-Clase";
                        gridViewDatos.Columns["Dia_Semana"].HeaderText = "Dia Semana";
                    }
                    else
                        muestraMensajeErrConexion();
                    break;
            }
            bd.Dispose();
            if(gridViewDatos.SelectedRows.Count > 0)
            {
                gridViewDatos.SelectedRows[0].Selected = false;
            }
        }

        private void agregaFormEnContenedor(Form f)
        {
            if (pnlContenedor.Controls.Count > 0)
                pnlContenedor.Controls.RemoveAt(0);
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(f);
            pnlContenedor.Tag = f;
            f.Show();
        }

        private void muestraControles()
        {
            if (conexionOK)
            {
                pnlContenedor.Visible = true;
                gbTituloDatos.Visible = true;
                btnAlta.Visible = true;
                btnEdicion.Visible = true;
                btnBaja.Visible = true;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            switch(opcion)
            {
                case 1:
                    ((wdwProfesores)pnlContenedor.Controls[0]).alta_Profesor();
                    break;
                case 2:
                    ((wdwMaterias)pnlContenedor.Controls[0]).alta_Materia();
                    break;
                case 3:
                    ((wdwGrupos)pnlContenedor.Controls[0]).alta_Grupo();
                    break;
                case 4:
                    ((wdwHorasClase)pnlContenedor.Controls[0]).alta_Hora_Clase();
                    break;
                case 5:
                    ((wdwHorarios)pnlContenedor.Controls[0]).alta_Horario();
                    break;
            }
            actualizaDatosGrid();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (gridViewDatos.SelectedRows.Count > 0)
            {
                switch (opcion)
                {
                    case 1:
                        ((wdwProfesores)pnlContenedor.Controls[0]).baja_Profesor(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Profesor"].Value));
                        break;
                    case 2:
                        ((wdwMaterias)pnlContenedor.Controls[0]).baja_Materia(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Materia"].Value));
                        break;
                    case 3:
                        ((wdwGrupos)pnlContenedor.Controls[0]).baja_Grupo(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Grupo"].Value));
                        break;
                    case 4:
                        ((wdwHorasClase)pnlContenedor.Controls[0]).baja_HoraClase(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Hora_Clase"].Value));
                        break;
                    case 5:
                        ((wdwHorarios)pnlContenedor.Controls[0]).baja_Horario(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Horario"].Value));
                        break;
                }
                actualizaDatosGrid();
            }
            else
                MessageBox.Show("No se ha seleccionado ningún elemento a eliminar, por favor seleccione uno de la tabla", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEdicion_Click(object sender, EventArgs e)
        {
            if (gridViewDatos.SelectedRows.Count > 0)
            {
                switch (opcion)
                {
                    case 1:
                        ((wdwProfesores)pnlContenedor.Controls[0]).modifica_Profesor(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Profesor"].Value));
                        break;
                    case 2:
                        ((wdwMaterias)pnlContenedor.Controls[0]).modifica_Materia(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Materia"].Value));
                        break;
                    case 3:
                        ((wdwGrupos)pnlContenedor.Controls[0]).modifica_Grupo(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Grupo"].Value));
                        break;
                    case 4:
                        ((wdwHorasClase)pnlContenedor.Controls[0]).modifica_HoraClase(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Hora_Clase"].Value));
                        break;
                    case 5:
                        ((wdwHorarios)pnlContenedor.Controls[0]).modifica_Horario(Convert.ToInt32(gridViewDatos.SelectedRows[0].Cells["Id_Horario"].Value));
                        break;
                }
                actualizaDatosGrid();
            }
            else
                MessageBox.Show("No se ha seleccionado ningún elemento a modificar, por favor seleccione uno de la tabla", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridViewDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch(opcion)
            {
                case 1:
                    ((wdwProfesores)pnlContenedor.Controls[0]).cargaDatos_Control(gridViewDatos.SelectedRows[0]);
                    break;
                case 2:
                    ((wdwMaterias)pnlContenedor.Controls[0]).cargaDatos_Control(gridViewDatos.SelectedRows[0]);
                    break;
                case 3:
                    ((wdwGrupos)pnlContenedor.Controls[0]).cargaDatos_Control(gridViewDatos.SelectedRows[0]);
                    break;
                case 4:
                    ((wdwHorasClase)pnlContenedor.Controls[0]).cargaDatos_Control(gridViewDatos.SelectedRows[0]);
                    break;
                case 5:
                    ((wdwHorarios)pnlContenedor.Controls[0]).cargaDatos_Control(gridViewDatos.SelectedRows[0]);
                    break;
            }
        }

        private void muestraMensajeErrConexion()
        {
            conexionOK = false;
            MessageBox.Show("Ha ocurrido un error en la conexión a la base de datos, por favor consulte al administrador del sistema", "Error en conexión a Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
