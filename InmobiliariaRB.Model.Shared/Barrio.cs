using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Barrio
    {
        public int IDBARRIO { get; set; }

        public int IDPARROQUIA { get; set; }

        public string NOMBREBARRIO { get; set; }

        public bool ESTADOBARRIO { get; set; }

        public string NOMBREPARROQUIA { get; set; }
    }
}
