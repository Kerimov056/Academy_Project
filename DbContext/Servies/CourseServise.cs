using Academy.Core.Entitis;
using Academy.Infascturute.Entetis.Exceptin;
using DbContext.DbContext;
using Academy.Infascturute.Entetis.Exceptin;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace Academy.Infascturute.Servies;

public class CourseServise
{
    private static int _count = 0;
    public void Create(string? _name)
    {
        if (String.IsNullOrWhiteSpace(_name)) throw new ArgumentNullException(nameof(_name));
        bool isExits=false;
        for (int i = 0; i < _count; i++)
        {
            if (AppDbConntext.courses[i].AName.ToUpper() == _name.ToUpper())
            {
                isExits = true; break;
            }
        }
        if (isExits)
        {
            throw new DuplicatNameException("This course name already extis:");
        }
        Course course = new(_name);
        AppDbConntext.courses[_count++]=course;
    }
    
    public void GetAll()
    {
        for (int i = 0; i < _count; i++)
        {
            Console.WriteLine(AppDbConntext.courses[i].id+"-"+AppDbConntext.courses[i].AName);
        }
    }

    public void Delete(string? _Name)
    {
        if (String.IsNullOrWhiteSpace(_Name)) throw new ArgumentNullException(nameof(_Name));

        bool isNull = false;
        for (int i = 0; i < _count; i++)
        {
            if (AppDbConntext.courses[i].AName == _Name)
            {
                AppDbConntext.courses[i].AName = null;
                isNull = true;
                break;
            }
        }
        //if (isNull)
        //{
        //    throw new DuplicatNameException("There is no such course:");
        //}
    }
}
