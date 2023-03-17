using Academy.Core.Interfeys;

namespace Academy.Core.Entitis;

public class Student : lEntetiy
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public static int counter { get; private set; }

    private Student()
    {
        id = counter++;
    }
    public Student(string name,string surname):this()
    {
        Name = name;
        Surname = surname;
    }
}
