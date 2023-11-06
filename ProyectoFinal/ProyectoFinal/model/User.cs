using System;
using System.Collections.Generic;
using System.Text;

public class User
{
    public Guid IdUser { get; set; }
    public int? IdUserLocal { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}