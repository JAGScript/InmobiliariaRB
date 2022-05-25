using System;

namespace InmobiliariaRB.Model.Shared
{
    public class Transaccion
    {
        public int IDTRANSACCION { get; set; }

        public string NOMBRE { get; set; }

        public string DESCRIPCION { get; set; }

        public bool ESTADO { get; set; }

        public string MENU { get; set; }

        public bool SUBMENU { get; set; }

        public int MENUPADRE { get; set; }

        public int IDUSUARIOMODIFICACION { get; set; }

        public DateTime? FECHAMODIFICACION { get; set; }

        public int IDTRANSACCIONROL { get; set; }
    }
}
