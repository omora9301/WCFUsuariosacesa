using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

using System.Configuration;
using aaacesa.Business.WCFUsuarios.AppEntity;

namespace aaacesa.Data.WCFUsuarios
{
    public class Dat
    {
        string strSQL;
        OracleConnection cnn = new OracleConnection();
        string oradb;

        public Dat()
        {
            strSQL = string.Empty;
        }

        public void ConnectarOracle()
        {
            try
            {
                oradb = ConfigurationManager.ConnectionStrings["ConnectionORACLE"].ConnectionString;
                cnn.ConnectionString = oradb;
                cnn.Open();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
        }

        public void DesconectarOracle()
        {
            cnn.Close();
        }

        public List<BE> ObtenerListaUsuarios(string idu, string nombre)
        {
            try
            {
                List<BE> usuariolist = new List<BE>();
                this.ConnectarOracle();
                if (cnn.State == ConnectionState.Open)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = "PK_CON_USU.SP_LISTAUSUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("u_idu", OracleDbType.Varchar2).Value = idu.ToString();
                    cmd.Parameters.Add("u_nombre", OracleDbType.Varchar2).Value = nombre.ToString();
                    cmd.Parameters.Add("saldatos_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    OracleDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BE e = new BE();

                        e.U_idu = dr["IDU"].ToString();
                        e.Nombre = dr["NOMBRE"].ToString();
                        e.Paterno = dr["PATERNO"].ToString();
                        e.Materno = dr["MATERNO"].ToString();
                        e.Edad = Convert.ToInt32(dr["EDAD"]);
                        usuariolist.Add(e);
                    }
                    cnn.Dispose();
                    cnn.Close();
                    return usuariolist;
                }
                else
                {
                    cnn.Dispose();
                    cnn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Ocurrio un error.");
            }
        }

        public string AgregarUsuario(string nombre, string paterno, string materno, int edad)
        {
            //List<BE> usuariolist = new List<BE>();
            string Mensaje = "";
            try
            {
                this.ConnectarOracle();
                if (cnn.State == ConnectionState.Open)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = "PK_CON_USU.SP_AGREGARUSUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("u_nombre", OracleDbType.Varchar2).Value = nombre;
                    cmd.Parameters.Add("u_paterno", OracleDbType.Varchar2).Value = paterno;
                    cmd.Parameters.Add("u_materno", OracleDbType.Varchar2).Value = materno;
                    cmd.Parameters.Add("u_edad", OracleDbType.Int32).Value = edad;
                    cmd.Parameters.Add("saldatos_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.FieldCount != 1)
                    {
                        Mensaje = "Se agregó: "+ nombre +" "+paterno+ " " + materno;
                    }
                    else {
                        Mensaje = "Falló al agregar";
                    }
                    //while (dr.Read())
                    //{
                    //    BE e = new BE();

                    //    e.U_idu = dr["IDU"].ToString();
                    //    e.Nombre = dr["NOMBRE"].ToString();
                    //    e.Paterno = dr["PATERNO"].ToString();
                    //    e.Materno = dr["MATERNO"].ToString();
                    //    e.Edad = Convert.ToInt32(dr["EDAD"]);
                    //    usuariolist.Add(e);
                    //}
                    cnn.Dispose();
                    cnn.Close();
                }
                else
                {
                    cnn.Dispose();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                //return null;
                throw new Exception("Error interno: " + ex.Message);

            }
            return Mensaje;
        }

        public string ActualizarUsuarioBd(string u_idu, string nombre, string paterno, string materno, int edad)
        {
            List<BE> usuariolist = new List<BE>();
            string Mensaje = "";
            try
            {
                this.ConnectarOracle();
                if (cnn.State == ConnectionState.Open)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = "PK_CON_USU.SP_ACTUALIZAR_USUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("u_idu", OracleDbType.Varchar2).Value = u_idu;
                    cmd.Parameters.Add("u_nombre", OracleDbType.Varchar2).Value = nombre;
                    cmd.Parameters.Add("u_paterno", OracleDbType.Varchar2).Value = paterno;
                    cmd.Parameters.Add("u_materno", OracleDbType.Varchar2).Value = materno;
                    cmd.Parameters.Add("u_edad", OracleDbType.Int32).Value = edad;
                    cmd.Parameters.Add("saldatos_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Mensaje = "Registro actualizado";
                    }
                    else {
                        Mensaje = "No existe";
                    }
                    cnn.Dispose();
                    cnn.Close();

                }
                else
                {
                    cnn.Dispose();
                    cnn.Close();
                }
                return Mensaje;
            }
            catch (Exception ex)
            {
                Mensaje = "Error interno" + ex.Message.ToString();
                return Mensaje;
            }
        }

        public string Eliminar(string u_idu)
        {
            string mensaje = "";
            try
            {
                this.ConnectarOracle();
                if (cnn.State == ConnectionState.Open)
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = "PK_CON_USU.SP_ELIMINARUSUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("u_idu", OracleDbType.Varchar2).Value = u_idu;
                    cmd.Parameters.Add("saldatos_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        mensaje = "No se puede eliminar";
                    }
                    else {
                        mensaje = "Eliminado";
                    }
                    cnn.Dispose();
                    cnn.Close();
                }
                else
                {
                    cnn.Dispose();
                    cnn.Close();
                }
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Error interno: " + ex.Message.ToString();
            }
            return mensaje;
        }
    }
}
