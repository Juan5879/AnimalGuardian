using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProyectoFinal.data
{
    class DBanimal
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int type { get; set; }
    }

}


                                                                /*▀▄▀▄▀▄🄿🄰🄽▀▄▀▄▀▄*/
