

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add student");
            Console.WriteLine("2. Delete student by ID");
            Console.WriteLine("3. Update student by ID");
            Console.WriteLine("4. Search student by ID");
            Console.WriteLine("5. Show all students");
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddStudent(); break;
                case "2": DeleteStudent(); break;
                case "3": UpdateStudent(); break;
                case "4": SearchStudent(); break;
                case "5": ShowAllStudents(); break;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    static void AddStudent()
    {
        using var db = new AppDbContext();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Score: ");
        int score = int.Parse(Console.ReadLine());

        var student = new Student { Name = name, Surname = surname, Score = score };
        db.Students.Add(student);
        db.SaveChanges();
        Console.WriteLine("Student added.");
    }

    static void DeleteStudent()
    {
        using var db = new AppDbContext();
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        var student = db.Students.Find(id);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        db.Students.Remove(student);
        db.SaveChanges();
        Console.WriteLine("Student deleted.");
    }

    static void UpdateStudent()
    {
        using var db = new AppDbContext();
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var student = db.Students.Find(id);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("New Name: ");
        student.Name = Console.ReadLine();
        Console.Write("New Surname: ");
        student.Surname = Console.ReadLine();
        Console.Write("New Score: ");
        student.Score = int.Parse(Console.ReadLine());

        db.SaveChanges();
        Console.WriteLine("Student updated.");
    }

    static void SearchStudent()
    {
        using var db = new AppDbContext();
        Console.Write("Enter ID to search: ");
        int id = int.Parse(Console.ReadLine());

        var student = db.Students.Find(id);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine($"{student.Id} - {student.Name} {student.Surname} | Score: {student.Score}");
    }

    static void ShowAllStudents()
    {
        using var db = new AppDbContext();
        var students = db.Students.ToList();

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id} - {student.Name} {student.Surname} | Score: {student.Score}");
        }
    }
}