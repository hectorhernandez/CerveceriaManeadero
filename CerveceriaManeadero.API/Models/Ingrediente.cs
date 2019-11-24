using System;

namespace CerveceriaManeadero.API.Models
{
    public class Ingrediente
    {
        public Ingrediente()
        {

        }


        public Ingrediente(string cantidad)
        {
            Cantidad = cantidad;
        }

        public int Id { get; set; }
        public string Cantidad { get; set; }

    }
}