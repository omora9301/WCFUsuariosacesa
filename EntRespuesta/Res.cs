using aaacesa.Business.WCFUsuarios.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaacesa.Business.WCFUsuarios.EntRespuesta
{
    public class Res
    {
        public List<BE> UsuariosLista { get; set; }
        public BE EntidadUsuarios { get; set; }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
    }
}
