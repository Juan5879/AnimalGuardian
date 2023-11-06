using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

public class Notification
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Description { get; set; }
    public Guid IdPet { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public DateTime Time { get; set; }
    public string PetName { get; set; }
}