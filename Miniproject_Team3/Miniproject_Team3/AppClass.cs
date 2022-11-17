using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniproject_Team3
{

    public class AppClass:UserInterface
    {
        static void Main(string[] args)
        {
            AppClass app = new AppClass();

            //app.Scenario1();
            //app.Scenerio2();
            //app.Scenerio3();



            AppEngine a = new AppEngine();

            Console.WriteLine("------------enter how many details------------- ");
            int input = Convert.ToInt32(Console.ReadLine());
            //a.register(input);
            //a.listOfStudents(input);
            //a.introduce(input);


            //Course[] c = new Course[5];
            //a.listOfCourses(c);

            app.showFirstScreen();
            
            Console.Read();

        }

        public void Scenario1()
        {
            Console.WriteLine("--------------------Scenario1----------------------------");
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();
            Student s4 = new Student();

            Info d1 = new Info();

            s1.id = 1;
            s1.name = "Savitha";
            s1.dob = Convert.ToDateTime("01/12/2000");

            s2.id = 2;
            s2.name = "Aishwariya";
            s2.dob = Convert.ToDateTime("06/07/2000");

            s3.id = 3;
            s3.name = "Sairoopa";
            s3.dob = Convert.ToDateTime("12/12/1999");

            s4.id = 4;
            s4.name = "vishnu";
            s4.dob = Convert.ToDateTime("10/02/2003");

            d1.DisplayStudent(s1);
            d1.DisplayStudent(s2);
            d1.DisplayStudent(s3);
            d1.DisplayStudent(s4);
            //Console.WriteLine("------------------------------------------------");

        }

        public void Scenerio2()
        {
            Console.WriteLine("--------------------Scenerio2----------------------------");
            var s = new Student[4];
            Info d2 = new Info();


            s[0] = new Student();
            s[1] = new Student();
            s[2] = new Student();
            s[3] = new Student();


            s[0].id = 1;
            s[0].name = "anupa";
            s[0].dob = Convert.ToDateTime("2000/11/10");


            s[1].id = 2;
            s[1].name = "Niranjan";
            s[1].dob = Convert.ToDateTime("2000/07/19");


            s[2].id = 3;
            s[2].name = "Harish";
            s[2].dob = Convert.ToDateTime("2000/04/01");


            s[3].id = 4;
            s[3].name = "Nidhi";
            s[3].dob = Convert.ToDateTime("1999/02/21");

            foreach (var st in s)
            {
                d2.DisplayStudent(st);
            }

            Console.WriteLine("");

        }



        public void Scenerio3()
        {
            Console.WriteLine("--------------------Scenerio3----------------------------");
            Console.Write("*****enter how many student details need to enter*****\n");
            int input = Convert.ToInt32(Console.ReadLine());
            Student[] s = new Student[input];
            Info d3 = new Info();
            for (int ans = 0; ans < s.Length; ans++)
            {
                s[ans] = new Student();
                Console.WriteLine("Enter Student Id");
                s[ans].id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name");
                s[ans].name = Console.ReadLine();
                Console.WriteLine("Enter Date of birth for the student");
                s[ans].dob = Convert.ToDateTime(Console.ReadLine());
            }

            foreach (var std in s)
            {
                d3.DisplayStudent(std);
            }
            Console.ReadLine();
        }




    }
    public class Student
    {

        public int id { get; set; }
        public String name { get; set; }
        public DateTime dob { get; set; }


        //public Student(int id, string name, DateTime dob)
        //{
        //    this.id = id;
        //    this.name =name;
        //    this.dob = dob;

        //}
    }

    public class Course
    {
        public int id { get; set; }
        public String name { get; set; }
        public String duration { get; set; }
        public float fees { get; set; }

        public int cid
        {
            get { return id; }
            set { id = value; }
        }
        public string Cname
        {
            get { return name; }
            set { name = value; }
        }
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public float fee
        {
            get { return fees; }
            set { fees = value; }
        }


    }

    public class Info
        {
            public void DisplayStudent(Student student)
            {
                Console.WriteLine("Student ID: {0}", student.id);
                Console.WriteLine("Student Name:{0}", student.name);
                Console.WriteLine("Student DOB: {0}", student.dob.ToShortDateString());
                Console.WriteLine();
            }



            public void DisplayCourse(Course course)
            {

                Console.WriteLine("Course ID: " + course.id);
                Console.WriteLine("Course Name: " + course.name);
                Console.WriteLine("Course Duration: " + course.duration);
                Console.WriteLine("Course Fees: " + course.fees);
                Console.ReadLine();
                //Console.WriteLine("{0} \t {1} \t {2}\t{3}", course.id, course.name, course.duration, course.fees);
            }


        }

    }






