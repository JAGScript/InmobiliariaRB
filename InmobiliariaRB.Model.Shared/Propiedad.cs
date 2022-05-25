using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Propiedad
    {
        public int IDPROPIEDAD { get; set; }

        public int IDCARACTERISTICA { get; set; }

        public int IDPROVINCIA { get; set; }

        public string NOMBREPROVINCIA { get; set; }

        public int IDTIPOPROPIEDAD { get; set; }

        public string NOMBRETIPOPROPIEDAD { get; set; }

        public int IDPROPIETARIO { get; set; }

        public int IDUSUARIO { get; set; }

        public decimal PRECIO { get; set; }

        public DateTime FECHAREGISTROPROPIEDAD { get; set; }

        public string FOTOPRINCIPAL { get; set; }

        public bool ESTADOPROPIEDAD { get; set; }

        public decimal METROSCUADRADOS { get; set; }

        public int PLANTAS { get; set; }

        public int BANIOS { get; set; }

        public int HABITACIONES { get; set; }

        public int PARQUEADEROS { get; set; }

        public string SERVICIOS { get; set; }

        public string OTROS { get; set; }

        public string NOMBREPROPIETARIO { get; set; }
    }
}
