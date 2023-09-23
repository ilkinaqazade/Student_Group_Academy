using System;

class Teacher
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }
    public string Speciality { get; set; }
}

class Student
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public double AverageScore { get; set; }
    public string Major { get; set; }
}

class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Teacher GroupTeacher { get; set; }
    public Student[] Students { get; set; }

    public Group(int studentCapacity)
    {
        Students = new Student[studentCapacity];
    }
}

class Academy
{
    public Group[] Groups { get; set; }
    private int groupCount = 0;

    public Academy(int groupCapacity)
    {
        Groups = new Group[groupCapacity];
    }

    public void CreateGroup()
    {
        if (groupCount < Groups.Length)
        {
            Group group = new Group(100);

            Console.Write("Enter Group Name: ");

            group.Name = Console.ReadLine();


            Teacher teacher = new Teacher();

            Console.Write("Enter Teacher Fullname: ");

            teacher.Fullname = Console.ReadLine();

            Console.Write("Enter Teacher Age: ");

            teacher.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher Experience: ");

            teacher.Experience = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher Speciality: ");

            teacher.Speciality = Console.ReadLine();

            group.GroupTeacher = teacher;

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Exit");
                Console.Write("Select an action: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    if (group.Students.Length > group.Id)
                    {

                        Student student = new Student();

                        Console.Write("Enter Student Fullname: ");

                        student.Fullname = Console.ReadLine();

                        Console.Write("Enter Student Average Score: ");

                        student.AverageScore = double.Parse(Console.ReadLine());

                        Console.Write("Enter Student Major: ");

                        student.Major = Console.ReadLine();

                        group.Students[group.Id] = student;

                        group.Id++;
                    }
                    else
                    {
                        Console.WriteLine("Student capacity reached for this group.");
                    }
                }
                else if (choice == 2)
                {
                    break;
                }
            }

            Groups[groupCount] = group;
            groupCount++;
        }
        else
        {
            Console.WriteLine("Group capacity reached for the academy.");
        }
    }

    public void ShowAllGroups()
    {
        Console.WriteLine("All Groups:");
        foreach (var group in Groups)
        {
            if (group != null)
            {
                Console.WriteLine($"Group Name: {group.Name}");
                Console.WriteLine($"Teacher: {group.GroupTeacher.Fullname}");
                Console.WriteLine("Students:");
                foreach (var student in group.Students)
                {
                    if (student != null)
                    {
                        Console.WriteLine($"- {student.Fullname}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the maximum number of groups: ");
        int maxGroupCount = int.Parse(Console.ReadLine());

        Academy academy = new Academy(maxGroupCount);

        while (true)
        {
            Console.WriteLine("[1] Make New Group");
            Console.WriteLine("[2] Show All Groups");
            Console.WriteLine("[3] Exit");
            Console.Write("Select an action: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                academy.CreateGroup();
            }
            else if (choice == 2)
            {
                academy.ShowAllGroups();
            }
            else if (choice == 3)
            {
                break;
            }
        }
    }
}
