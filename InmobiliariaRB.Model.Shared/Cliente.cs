using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Cliente
    {
        public int IDCLIENTE { get; set; }

        public string IDENTIFICACIONCLIENTE { get; set; }

        public string NOMBRECLIENTE { get; set; }

        public string DIRECCIONCLIENTE { get; set; }

        public string CELULARCLIENTE { get; set; }

        public string CORREOCLIENTE { get; set; }

        public int ASESOR { get; set; }

        public bool ESTADOCLIENTE { get; set; }
    }
}
