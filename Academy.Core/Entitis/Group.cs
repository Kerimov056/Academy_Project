using Academy.Core.Interfeys;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Academy.Core.Entitis;

public class Group : lEntetiy
{
    public int id { get; set; }
    public int courseId { get; set; }
    public GroupType Type { get; set; }
    public string Groupname { get; set; }
    public int Max_count { get; set; }
    public static int counter { get; private set; }

    private Group()
    {
        id = counter++;
    }
    public Group(string Group_name,int _Max_count, GroupType type,int course_Id) : this()
    {
        Groupname = Group_name;
        Max_count= _Max_count;
        Type = type;
        courseId= course_Id;
    }
}
public enum GroupType { Programing=1, Dizayn, Marketing }