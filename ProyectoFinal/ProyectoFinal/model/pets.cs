using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.model
{
    public class pets
    {
        [PrimaryKey, AutoIncrement]
        public int IdPet { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class petTS
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
