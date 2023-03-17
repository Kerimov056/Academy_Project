using Academy.Core.Entitis;
using Academy.Infascturute.Servies;

Console.WriteLine("Welcome");
CourseServise coreServies = new();
GroupServise groupServise = new();
while (true)
{
    Console.WriteLine
        (
        "Exit - 0 " +
        "\nCreate Academy - 1 " +
        "\nList Courses - 2 " +
        "\nDelete Courses - 3 " +
        "\nCreate Group - 4 " +
        "\nGroup List - 5"
        );
    string respons = Console.ReadLine();
    int menu;
    bool tryToInt = int.TryParse(respons, out menu);
    if (tryToInt)
    {
        switch (menu)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine("Enter Cours name:");
                string? Course_name=Console.ReadLine();
                try
                {
                    coreServies.Create(Course_name);
                    Console.WriteLine($"new course: {Course_name}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                break;
            case 2:
                Console.WriteLine("List Course:");
                coreServies.GetAll();
                break;
            case 3:
                Console.WriteLine("Enter Delete Courses name:");
                string? deletename=Console.ReadLine();
                if (deletename == null)
                {
                    goto case 3;
                }
                coreServies.Delete(deletename);
                break;
            case 4:
                Console.WriteLine("Enter Group Name:");
                string? newGroup=Console.ReadLine();
                Max_count:
                Console.WriteLine("Enter Group Max Number:");
                string? Group_max=Console.ReadLine();
                int Max_count;
                bool tryToIntMax = int.TryParse(Group_max, out Max_count);
                if (!tryToIntMax)
                {
                    Console.WriteLine("Enter Corret Format");
                    goto Max_count;
                }
                GroupType:
                Console.WriteLine("Enter Group Type(Number):");
                foreach (var GroupsType in Enum.GetValues(typeof(GroupType)))
                {
                    Console.WriteLine((int)GroupsType + "-"+ GroupsType);
                }
                string? Group_Type=Console.ReadLine();
                int Grop_Type;
                bool tryToIntType = int.TryParse(Group_Type, out Grop_Type);
                if (!tryToIntType)
                {
                    Console.WriteLine("Enter Corret Format");
                    goto GroupType;
                }
                Select_couse:
                Console.WriteLine("Enter Course (id):");
                coreServies.GetAll();
                string? Select_couse = Console.ReadLine();
                int Course_id;
                bool tryToIdCourse = int.TryParse(Select_couse, out Course_id);
                if (!tryToIntType)
                {
                    Console.WriteLine("Enter Corret Course Id");
                    goto Select_couse;
                }
                try
                {
                    groupServise.Create(newGroup, Grop_Type, Max_count, Course_id);
                    Console.WriteLine("Succesfulluy created:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 3;
                }
                break;
            case 5:
                Console.WriteLine("Group List:");
                groupServise.GetAll();
                break;
            default:
                Console.WriteLine("Select correct from ones menu!!!");
                break;
        }
    }
    else
    {
        Console.WriteLine("enter corret menu item!");
    }
    Console.WriteLine("------------------------");
}