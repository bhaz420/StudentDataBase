using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace StudentDataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentDbContext())
            {

                // Add a student
                var newStudent = new Student
                {
                    FirstName = "John",
                    LastName = "Doe"
                };
                context.Students.Add(newStudent);
                context.SaveChanges();

                // Retrieve and display the added student
                var addedStudent = context.Students.Find(newStudent.Id);
                Console.WriteLine($"Added Student: {addedStudent.FirstName} {addedStudent.LastName}");
            }
        }
        public class Student
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
        public class StudentDbContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
        }
    }
}
