using SQLite;

namespace App7_507.Models;

public class Student
{
    [PrimaryKey, AutoIncrement]
    public int ID_A { get; set; }
    public string name_student { get; set; }
    public string group { get; set; }
}

