using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASP_MVC_Contoso.Models;

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
            AddDepartments(context);
            AddInstructors(context);
            AddOfficeAssignments(context);
            AddCourseAssignments(context);
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

        public static void AddDepartments(ApplicationDbContext context)
        {
            // Look for any departments.
            if (context.Departments.Any())
            {
                return;   // DB has been seeded
            }

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();
        }

        public static void AddInstructors(ApplicationDbContext context)
        {
            // Look for any instructors.
            if (context.Instructors.Any())
            {
                return;   // DB has been seeded
            }

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }

            context.SaveChanges();
        }

        public static void AddOfficeAssignments(ApplicationDbContext context)
        {
            // Look for any Office Assignments.
            if (context.OfficeAssignments.Any())
            {
                return;   // DB has been seeded
            }

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }

            context.SaveChanges();
        }

        public static void AddCourseAssignments(ApplicationDbContext context)
        {
            // Look for any departments.
            if (context.CourseAssignments.Any())
            {
                return;   // DB has been seeded
            }

            var courseInstructors = new CourseAssignment[]
                {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }

            context.SaveChanges();
        }
    }
}