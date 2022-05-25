using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Parroquia
    {
        public int IDPARROQUIA { get; set; }

        public int IDCANTON { get; set; }

        public string CODPARROQUIA { get; set; }

        public string NOMBREPARROQUIA { get; set; }

        public bool ESTADOPARROQUIA { get; set; }

        public string NOMBRECANTON { get; set; }
    }
}
