using FFImageLoading.Work;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.model
{
    public class pets
    {
        public Guid IdPet { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOfAnimal { get; set; }
        public byte[] Image { get; set; }
    }
    public class petTS
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
