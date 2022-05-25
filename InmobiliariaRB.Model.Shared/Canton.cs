using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Canton
    {
        public int IDCANTON { get; set; }

        public int IDPROVINCIA { get; set; }

        public string CODCANTON { get; set; }

        public string NOMBRECANTON { get; set; }

        public bool ESTADOCANTON {get; set; }

        public string NOMBREPROVINCIA { get; set; }
    }
}
