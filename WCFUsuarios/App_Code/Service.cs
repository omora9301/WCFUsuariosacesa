using aaacesa.Business.WCFUsuarios;
using aaacesa.Business.WCFUsuarios.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    Bus neg = new Bus();
    public List<BE> ObtenerListaUs(string idu, string nombre)
    {
        List<BE> ls = neg.ObtenerListaUs(idu, nombre);
        return ls;
    }

    public string AgregarUsuario(string nombre, string paterno, string materno, int edad)
    {
        string Mensaje = "";
        Bus bus = new Bus();
        //List<BE> ls = 
        Mensaje = bus.AgregarUsu(nombre, paterno, materno, edad);
        return Mensaje;
    }

    public string ActualizarUsu(string u_idu, string nombre, string paterno, string materno, int edad)
    {
        string Mensaje = "";

        Bus bus = new Bus();
        Mensaje = bus.ActualizarUsusario(u_idu, nombre, paterno, materno, edad);
        return Mensaje;
    }

    public string Eliminar(string u_idu)
    {
        string Mensaje = "";
        Bus bus = new Bus();
        Mensaje = bus.EliminarUsuario(u_idu);
        return Mensaje;
    }
}
