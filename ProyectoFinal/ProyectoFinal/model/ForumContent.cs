using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.model
{
    public class ForumContent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
