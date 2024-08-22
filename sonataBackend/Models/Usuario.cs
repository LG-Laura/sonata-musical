﻿namespace sonataBackend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
