using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }

        public User(int id, string firstName, string lastName, string email, int age, int salary, string department)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Salary = salary;
            Department = department;
        }
    }
}
