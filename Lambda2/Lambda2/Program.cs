using System;
using System.IO;
using System.Globalization;
using Lambda2.Entities;

namespace Lambda2;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter full file path: ");
        string path = Console.ReadLine();

        Console.Write("Enter salary: ");
        double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        List<Employee> list = new List<Employee>();

        try
        {
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }
            }

            var emails = list.Where(emp => emp.Salary > value).OrderBy(emp => emp.Email).Select(emp => emp.Email);
            Console.WriteLine($"Email of people whose salary is more than {value.ToString("F2", CultureInfo.InvariantCulture)}:");
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            var sum = list.Where(emp => emp.Name[0] == 'M').Sum(emp => emp.Salary);
            Console.Write($"Sum of salary of people whose name starts with 'M': {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred!");
            Console.WriteLine(e.Message);
        }
    }
}
