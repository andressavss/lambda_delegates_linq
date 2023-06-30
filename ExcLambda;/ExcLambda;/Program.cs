using System;
using System.IO;
using System.Globalization;
using ExcLambda.Entities;

namespace ExcLambda;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter full file path: ");
        string path = Console.ReadLine();

        List<Employee> emp = new List<Employee>();

        using (StreamReader sr = File.OpenText(path))
        {
            while (!sr.EndOfStream)
            {
                string[] fields = sr.ReadLine().Split(',');
                string name = fields[0];
                string email = fields[1];
                double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                emp.Add(new Employee(name, email, salary));
            }
        }

        Console.Write("Enter the salary: ");
        double value = double.Parse(Console.ReadLine());

    }
}


/*var names = emp.Where(emp => emp.Salary > value).OrderBy(emp => emp.Name).Select(emp => emp.Email);
foreach (string str in names)
{
    Console.WriteLine("Email of people whose salary is more than value" + names);
}

//  Console.Write("Sum of salary of people whose name starts with 'M': "); 
}
}*/
