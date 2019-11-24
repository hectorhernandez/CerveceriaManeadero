using System;

namespace CerveceriaManeadero.API.Models
{
    public class Receta
    {
        public Receta()
        {

        }


        public Receta(DateTime fechaCreacion)
        {
            FechaCreacion = fechaCreacion;
        }

        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}