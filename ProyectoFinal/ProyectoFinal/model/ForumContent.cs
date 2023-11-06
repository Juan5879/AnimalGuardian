using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.model
{
    public class ForumContent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string user { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
