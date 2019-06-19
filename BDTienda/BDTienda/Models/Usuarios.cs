

namespace BDTienda.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SQLite;

    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
    }
}
