using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.model
{
    public class WikiData
    {
        [PrimaryKey, AutoIncrement]
        public int IdWiki { get; set; }
        public string NombreCientifico { get; set; }
        public string Descripcion { get; set; }
        public string Cuidados { get; set; }
    }
}
