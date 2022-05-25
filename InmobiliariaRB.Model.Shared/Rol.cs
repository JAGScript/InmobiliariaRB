using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Model.Shared
{
    public class Rol
    {
        public int IDROL { get; set; }

        public string NOMBREROL { get; set; }

        public bool ESTADOROL { get; set; }

        public List<Transaccion> Transacciones { get; set; }

        public Rol()
        {
            Transacciones = new List<Transaccion>();
        }
    }
}
