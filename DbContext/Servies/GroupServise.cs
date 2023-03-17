using Academy.Core.Entitis;
using Academy.Infascturute.Entetis.Exceptin;
using Academy.Infascturute.Entetis.Exceptioon;
using DbContext.DbContext;

namespace Academy.Infascturute.Servies;

public class GroupServise
{
    private static int _count = 0;

    public void Create(string? _name, int type,int max_count,int coursid)
    {
        if (String.IsNullOrWhiteSpace(_name)) throw new ArgumentNullException(nameof(_name));
        bool isExits = false;
        for (int i = 0; i < _count; i++)
        {
            if (AppDbConntext.groups[i].Groupname.ToUpper() == _name.ToUpper())
            {
                isExits = true; break;
            }
        }
        if (isExits)
        {
            throw new DuplicatNameException("This course name already extis:");
        }
        GroupType groupType;
        if (Enum.IsDefined(typeof(GroupType), type))
        {
            groupType=(GroupType)type;
        }
        else
        {
            throw new NotGroupTypeException("Select correct group's type");
        }
        Group new_group = new(_name, max_count, groupType, coursid);
        AppDbConntext.groups[_count++] = new_group;
    }

    public void GetAll()
    {
        for (int i = 0; i < _count; i++)
        {
            string tempcourse = string.Empty;
            foreach (var course in AppDbConntext.courses)
            {
                if (course is null) break;
                if (AppDbConntext.groups[i].courseId==course.id)
                {
                    tempcourse = course.AName;
                    break;
                }
            }
            Console.WriteLine
            (
              $"Id: {AppDbConntext.groups[i].id} " +
              $"\nGroup name: {AppDbConntext.groups[i].Groupname} " +
              $"\nType: {AppDbConntext.groups[i].Type} " +
              $"\nMaxCount: {AppDbConntext.groups[i].Max_count} " +
              $"\nBelengous To: {tempcourse}"
            );
        }
    }
}

