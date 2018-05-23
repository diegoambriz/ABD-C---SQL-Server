using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RelojChecador.Clases
{
    public class CBaseDatos:IDisposable
    {
        private SqlConnection conexion;

        public CBaseDatos()
        {
            conexion = new SqlConnection("Data Source=DESKTOP-6GMTUC7\\SQLEXPRESS; Initial Catalog = checador; Integrated Security = True");
            //this.conexion = new SqlConnection("Data Source=DESKTOP-OQJCMDH\\SQLEXPRESS; Initial Catalog = checador; Integrated Security = True");
        }

        public DataSet consulta(String query)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try {
                conexion.Open();
                SqlCommand instruccion = new SqlCommand(query, conexion);
                da.SelectCommand = instruccion;
                da.Fill(ds);
                da.Dispose();
                instruccion.Dispose();
                conexion.Close();
            }
            catch(Exception ex)
            {
                ds = null;
            }
            
            return ds;
        }

        public SqlException sql(String query)
        {
            try {
                conexion.Open();
                SqlCommand instruccion = new SqlCommand(query, conexion);
                instruccion.ExecuteNonQuery();
                conexion.Close();
                return null;
            }
            catch(SqlException ex)
            {
                return ex;
            }
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
