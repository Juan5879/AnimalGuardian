using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.model
{
    public class User
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
