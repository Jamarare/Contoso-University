using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student {FirstMidName="Allan" , LastName="´Lond",EnrollmentDate=DateTime.Parse("2069-12-03")},
                new Student {FirstMidName="Marko" , LastName="´Maripuu",EnrollmentDate=DateTime.Parse("2069-04-20")},
                new Student {FirstMidName="Toivo" , LastName="´Treufeld",EnrollmentDate=DateTime.Parse("2069-01-27")},
                new Student {FirstMidName="Mikk" , LastName="Kivisild",EnrollmentDate=DateTime.Parse("2068-11-02")},
                new Student {FirstMidName="Trevor" , LastName="´Metsamaaker",EnrollmentDate=DateTime.Parse("2069-04-20")},
                new Student {FirstMidName="Mihkel" , LastName="´Ploompuu",EnrollmentDate=DateTime.Parse("2069-04-20")},
                new Student {FirstMidName="Marko" , LastName="´Vassiljev",EnrollmentDate=DateTime.Parse("2069-03-16")},
                new Student {FirstMidName="Tormi" , LastName="´Laane",EnrollmentDate=DateTime.Parse("2069-10-10")},
                new Student {FirstMidName="Tanno" , LastName="´Valk",EnrollmentDate=DateTime.Parse("2070-02-01")}
            };

            //iga õpilane lisatakse ükshaaval läbi foreach tsükli
            foreach (Student student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

            //ja andmebaasi muudatused salvestatakse
            var courses = new Course[]
            {
                new Course { CourseID = 9001, Title = "Geograafia", Credits = 3 },
                new Course { CourseID = 5050, Title = "fk", Credits = 1 },
                new Course { CourseID = 4140, Title = "Disain", Credits = 4 },
                new Course { CourseID = 3630, Title = "Bioloogia", Credits = 4 },
                new Course { CourseID = 8240, Title = "Keemia", Credits = 2 },
                new Course { CourseID = 1010, Title = "Programeerimine", Credits = 1 },
                new Course { CourseID = 7947, Title = "Füüsika", Credits = 4 },
                new Course { CourseID = 8351, Title = "Arvutimängude Ajalugu", Credits = 1 }
            };

            foreach(Course course in courses)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();

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

                new Enrollment{StudentID=10,CourseID=9001,Grade=Grade.A},
            };
            foreach (Enrollment enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }
            context.SaveChanges();
        }
    }
}