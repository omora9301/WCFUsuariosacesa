using aaacesa.Business.WCFUsuarios.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]
	List<BE> ObtenerListaUs(string idu, string nombre);

	[OperationContract]
	string AgregarUsuario(string nombre, string paterno, string materno, int edad);

	[OperationContract]
	string ActualizarUsu(string u_idu, string nombre, string paterno, string materno, int edad);

	[OperationContract]
	string Eliminar(string u_idu);

}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
