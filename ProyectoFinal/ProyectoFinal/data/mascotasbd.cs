using SQLite;

public class mascota
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Notes { get; set; }


}
