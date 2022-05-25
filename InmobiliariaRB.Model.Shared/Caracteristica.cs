using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Caracteristica
    {
        public int IDCARACTERISTICA { get; set; }

        public decimal METROSCUADRADOS { get; set; }

        public int PLANTAS { get; set; }

        public int BANIOS { get; set; }

        public int HABITACIONES { get; set; }

        public int PARQUEADEROS { get; set; }

        public string SERVICIOS { get; set; }

        public string OTROS { get; set; }
    }
}
