using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM02.Ejercicio2._2.Features
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public String image { get; set; }

        [MaxLength(100)]
        public String nombre { get; set; }

        [MaxLength(100)]
        public String description { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
