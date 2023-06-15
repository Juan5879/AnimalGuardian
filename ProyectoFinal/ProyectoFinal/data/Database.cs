using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

public class Database : SQLiteConnection
{
    public Database(string databasePhat) : base(databasePhat)
    {
        CreateTable<DBanimal>();
    }
    public class DBanimal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Type { get; set; }

    }

    public class DBuser
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}