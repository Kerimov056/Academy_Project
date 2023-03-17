using Academy.Core.Interfeys;

namespace Academy.Core.Entitis;

public class Course : lEntetiy
{

    public int id { get; set; }
    public string AName { get; set; }
    public static int counter { get; private set; }
    private Course()
    {
        id = counter++;
    }
    public Course(string ad) :this()
    {
        AName= ad;
    }
}
