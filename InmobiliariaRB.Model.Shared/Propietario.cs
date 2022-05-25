using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Propietario
    {
        public int IDPROPIETARIO { get; set; }

        public string NOMBREPROPIETARIO { get; set; }

        public string DIRECCIONPROPIETARIO { get; set; }

        public string CELULARPROPIETARIO { get; set; }

        public string CORRREOPROPIETARIO { get; set; }

        public bool ESTADOPROPIETARIO { get; set; }
    }
}
