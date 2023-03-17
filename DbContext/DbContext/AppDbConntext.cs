using Academy.Core.Entitis;

namespace DbContext.DbContext;

public class AppDbConntext
{
    public static Student[] students { get; set; }=new Student[1600];
    public static Group[] groups { get; set; } = new Group[100];
    public static Course[] courses { get; set; }= new Course[100];
}
