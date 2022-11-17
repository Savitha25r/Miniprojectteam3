using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Miniproject_Team3
{

    class Enroll
    {
        private Student student;
        private Course course;
        private DateTime EnrollmentDate;

        public Student std
        {
            get { return student; }
            set { student = value; }
        }
        public Course crs
        {
            get { return course; }
            set { course = value; }
        }
        public DateTime enrollDate
        {
            get { return EnrollmentDate; }
            set { EnrollmentDate = value; }
        }


    }


    public class AppEngine
    {
        int val;
        Student[] s = new Student[5];
        List<Course> courses = new List<Course>();
        Course[] c = new Course[5];
        Enroll[] e = new Enroll[5];
        public void enrollcourse(int input)
        {

            for (int i = 0; i < input; i++)
            {

                Console.WriteLine("Enter Course Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course Name");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Course Duration");
                string Duration = Console.ReadLine();
                Console.WriteLine("Enter Course Fees");
                float Fee = Convert.ToSingle(Console.ReadLine());
                courses.AddRange(new List<Course> {
                   new Course {id = id,  name = Name,  duration = Duration,fees = Fee },
                });


            }
        }

        public void register()
        {
            Console.WriteLine("enter how many student details needs to register\n");
            val = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < val; i++)
            {
                Console.WriteLine("Enter Stdid, Stdname,Dob");
                int id = Convert.ToInt32(Console.ReadLine());
                string name = Console.ReadLine();
                DateTime Dob = DateTime.Parse(Console.ReadLine());



                s[i] = new Student()
                {
                    id = id,
                    name = name,
                    dob = Dob,
                };
            }

        }

        public Student[] listOfStudents(int input)
        {
            Console.WriteLine();
            for (int i = 0; i < val; i++)
            {
                s[i] = new Student()
                {
                    id = s[i].id,
                    name = s[i].name,
                    dob = s[i].dob,
                };
            }
            for (int i = 0; i < val; i++)
            {
                Console.WriteLine("Student ID: {0}", s[i].id);
                Console.WriteLine("Student Name:{0}", s[i].name);
                Console.WriteLine("Student DOB: {0}", s[i].dob.ToShortDateString());
                Console.WriteLine();
                //Console.WriteLine(s[i].id + s[i].name + s[i].dob.ToShortDateString());
                //Console.WriteLine(" student Id: {0}\n student Name: {1}\n dob:{2}\n ", s[i].id + s[i].name + s[i].dob.ToShortDateString());
            }
            return s;

        }

        public List<Course> listOfCourses(Course[] course)
        {

            for (int i = 0; i < val; i++)
            {
                courses = new List<Course>
                {
                    new Course{id = course[i].id,name = course[i].name,duration = course[i].duration,fees = course[i].fees},
                };
            }
            foreach (var a in courses)
            {
                Console.WriteLine(" course Id: {0}\n Course Name: {1}\n Course Duration: {2}\n Course Fee: {3}\n ", a.id, a.name, a.duration, a.fees);
            }

            return courses;
        }


        //public class database
        //{
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlConnection getConnection()
        {
            con = new SqlConnection(@"Data Source = WSL011805884\SQLEXPRESS; Initial Catalog =Casestudy4; Integrated Security = True");

            con.Open();
            return con;
        }

        public void enroll()
        {
            int val;
            //Student[] s = new Student[5];
            //Course[] c = new Course[5];
            //Enroll[] e = new Enroll[5];
            con = getConnection();
            Console.WriteLine("enter how many student details needs to enroll\n");
            val = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < val; i++)
            {
                Console.WriteLine("Enter Stdid, Stdname");
                int id = Convert.ToInt32(Console.ReadLine());
                string name = Console.ReadLine();
                Console.WriteLine("Enter Course Id and Course Name");
                int Cid = Convert.ToInt32(Console.ReadLine());
                string CName = Console.ReadLine();
                Console.WriteLine("Enter Duration and fees");
                string Duration = Console.ReadLine();
                float Fee = Convert.ToSingle(Console.ReadLine());
                DateTime enrollment = Convert.ToDateTime(DateTime.Now);
                //                 ID int foreign key references student(ID),
                //cid int foreign key references Course(Cid),
                //  sname varchar(20) not null,
                //  cname varchar(30) not null,
                //  duration varchar(40),
                //  fees float,
                //  Enrollmentdate date,
                //  primary key(cid, ID)

                cmd = new SqlCommand("insert into Enrollment values(@ID,@CID,@Name,@Cname,@duration,@fees,@Enrollmentdate)", con);
                //command object has property known as parameters - a collection object
                //to the parameters collection, we have to add the parameters for insert
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@CID", Cid);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@Cname", CName);

                cmd.Parameters.AddWithValue("@duration", Duration);
                cmd.Parameters.AddWithValue("@fees", Fee);
                cmd.Parameters.AddWithValue("@Enrollmentdate", enrollment);


                int records = cmd.ExecuteNonQuery();
                if (records > 0)
                {
                    Console.WriteLine("Inserted successfully..");
                }
                else
                    Console.WriteLine("Something went wrong..");
            }

            //s[i] = new Student()
            //{
            //    id = id,
            //    name = name,
            //};
            //c[i] = new Course()
            //{
            //    cid = Cid,
            //    name = CName,
            //};
            //e[i] = new Enroll()
            //{
            //    enrollDate = enrollment,
            //};



        }


        public void displayenroll()
        {
            con = getConnection();
            try
            {
                Console.WriteLine("The enrollment list are:");
                cmd = new SqlCommand("select * from enrollment");
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4] + " " + dr[5] + " " + dr[6]);

                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                Console.WriteLine("Error in the Server...");
            }
        }
    }
    }




            //public Enroll[] listOfEnrollments()
            //{
            //    for (int i = 0; i < val; i++)
            //    {
            //        s[i] = new Student()
            //        {
            //            ID = s[i].ID,
            //            Name = s[i].Name,
            //        };
            //        c[i] = new Course()
            //        {
            //            cid = c[i].cid,
            //            name = c[i].name,
            //        };
            //        e[i] = new Enroll()
            //        {
            //            enrollDate = e[i].enrollDate,
            //        };
            //    }
            //    for (int i = 0; i < val; i++)
            //    {
            //        Console.WriteLine(" \nStudent ID: {0} \nStudent Name: {1} \nCourse ID: {2} \nCourse Name: {3} \nEnrollment Date: {4}", s[i].ID, s[i].Name, c[i].cid, c[i].name, e[i].enrollDate.ToShortDateString()); ;
            //    }
            //    return e;
            //}

        




