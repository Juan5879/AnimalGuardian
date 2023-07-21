using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProyectoFinal.model
{
    public class pets
    {
        [PrimaryKey, AutoIncrement]
        public int IdPet { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
