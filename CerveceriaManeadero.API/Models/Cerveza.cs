using System;

namespace CerveceriaManeadero.API.Models
{
    public class Cerveza
    {
        public Cerveza()
        {

        }


        public Cerveza(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
