using aaacesa.Business.WCFUsuarios.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaacesa.Data.WCFUsuarios;
using System.Data;

namespace aaacesa.Business.WCFUsuarios
{
    public class Bus
    {
        //public List<BE> ObtenerListaUs(int idu, string nombre)
        //{
        //    DataTable dt = new Dat().ObtenerListaUsuarios(idu, nombre);
        //    List<BE> ls = new List<BE>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        BE e = new BE();
        //        if (dt.Rows.Count >= 1)
        //        {
        //            e.U_idu = Convert.ToInt32(dr["IDU"]);
        //            e.Nombre = dr["NOMBRE"].ToString();
        //            e.Paterno = dr["PATERNO"].ToString();
        //            e.Materno = dr["MATERNO"].ToString();
        //            e.Edad = Convert.ToInt32(dr["EDAD"]);
        //            ls.Add(e);
        //        }
        //        else
        //        {
        //            throw new Exception("No hay registros");
        //        }
        //    }
        //    return ls;
        //}

        public List<BE> ObtenerListaUs(string idu, string nombre)
        {
            if (string.IsNullOrEmpty(idu))
                idu = string.Empty;
            if (string.IsNullOrEmpty(nombre))
                nombre = string.Empty;

            Dat datos = new Dat();
            List<BE> ls = datos.ObtenerListaUsuarios(idu, nombre);
            return ls;

        }
        public string AgregarUsu(string nombre, string paterno, string materno, int edad)
        {
            string Mensaje = "";
            if (string.IsNullOrEmpty(nombre))
                nombre = string.Empty;
            if (string.IsNullOrEmpty(paterno))
                paterno = string.Empty;
            if (string.IsNullOrEmpty(materno))
                materno = string.Empty;

            Dat datos = new Dat();
            //List <BE> ls = 
            Mensaje = datos.AgregarUsuario(nombre, paterno, materno, edad);
            return Mensaje;
        }
        public string ActualizarUsusario(string u_idu, string nombre, string paterno, string materno, int edad)
        {
            string Mensaje = "";
            if (string.IsNullOrEmpty(u_idu))
                u_idu = string.Empty;
            if (string.IsNullOrEmpty(nombre))
                nombre = string.Empty;
            if (string.IsNullOrEmpty(paterno))
                paterno = string.Empty;
            if (string.IsNullOrEmpty(materno))
                materno = string.Empty;

            Dat dt = new Dat();

            Mensaje = dt.ActualizarUsuarioBd(u_idu, nombre, paterno, materno, edad);
            return Mensaje;
            //if (nombre == null || paterno == null || materno == null ||
            //    nombre == string.Empty || paterno == string.Empty || materno == string.Empty)
            //{
            //    return "No se puede actualizar, campos vacios.";
            //}
            //else
            //{
            //    if (edad == 0 || edad > 99 || edad <= 0)
            //    {
            //        return "Edad debe ser entre 1 - 99.";
            //    }
            //    else
            //    { 
            //        dt.ActualizarUsuarioBd(u_idu, nombre, paterno, materno, edad);
            //        return "Registro Actualizado";
            //    }
            //}
        }
        public string EliminarUsuario(string u_idu)
        {
            string Mensaje = "";
            if (string.IsNullOrEmpty(u_idu))
                u_idu = string.Empty;
            Dat datos = new Dat();
            Mensaje = datos.Eliminar(u_idu);
            return Mensaje;
        }
    }

}

