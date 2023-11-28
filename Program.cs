using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Education education = new() {
                Name = "Data science"
            };
            using SchoolDbContext db = new();
            db.Add(education);
            db.SaveChanges();
        }

        }
    }
}