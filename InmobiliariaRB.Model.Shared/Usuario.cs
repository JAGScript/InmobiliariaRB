namespace InmobiliariaRB.Model.Shared
{
    public class Usuario
    {
        public int IDUSUARIO { get; set; }

        public int IDROL { get; set; }

        public string NOMBREUSUARIO { get; set; }

        public string IDENTIFICACIONUSUARIO { get; set; }

        public string CORREOUSUARIO { get; set; }

        public string USERNAME { get; set; }

        public byte[] CONTRASENA { get; set; }

        public bool ESTADO { get; set; }
    }
}
