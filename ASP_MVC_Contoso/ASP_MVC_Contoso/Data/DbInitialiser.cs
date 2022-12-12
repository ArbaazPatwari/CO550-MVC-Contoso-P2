using ASP_MVC_Contoso.Models;
using System;
using System.Linq;

namespace ASP_MVC_Contoso.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            AddStudents(context);
            AddCourses(context);
            AddEnrollments(context);
        }

        private static void AddEnrollments(ApplicationDbContext context)
        {
            // Look for any Enrollments.
            if (context.Enrollments.Any())
            {
                return;   // DB has been seeded
            }

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();
        }

        public static void AddCourses(ApplicationDbContext context)
        {
            // Look for any Courses.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }

            var courses = new Course[]
            {
                new Course{CourseID=1050, CourseCode="BNU-SE", Title="Software Engineering",Credits=3},
                new Course{CourseID=4022, CourseCode="BNU-CW", Title="Computing with Web Development",Credits=3},
                new Course{CourseID=4041, CourseCode="BNU-GD", Title="Games Development",Credits=3},
                new Course{CourseID=1045, CourseCode="BNU-DS", Title="Data Science",Credits=4},
                new Course{CourseID=3141, CourseCode="BNU-CS", Title="Cyber Security",Credits=4},
                new Course{CourseID=2021, CourseCode="BNU-CO", Title="Computing",Credits=3},
                new Course{CourseID=2042, CourseCode="BNU-IS", Title="Information Systems",Credits=4}
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }

        public static void AddStudents(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Arbaaz",LastName="Patwari",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Mohammed",LastName="Loqman",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Stefan",LastName="Allen",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Akes",LastName="Ali",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Ben",LastName="Thompson",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Alfred",LastName="Holmes",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Bilal",LastName="Rahman",EnrollmentDate=DateTime.Parse("2022-09-26")},
                new Student{FirstName="Cassandra",LastName="Yareli",EnrollmentDate=DateTime.Parse("2022-09-26")}
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();
        }
    }
}