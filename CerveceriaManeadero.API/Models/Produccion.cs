using System;

namespace CerveceriaManeadero.API.Models
{
    public class Produccion
    {
        public Produccion()
        {

        }


        public Produccion(string contenedor, int litros, DateTime fecha)
        {
            Contenedor = contenedor;
            Litros = litros;
            Fecha = fecha;
        }

        public int Id { get; set; }
        public string Contenedor { get; set; }
        public int Litros { get; set; }
        public DateTime Fecha { get; set; }

    }
}