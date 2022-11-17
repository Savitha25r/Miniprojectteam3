using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Miniproject_Team3
{
    public class Course1
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        //function that establishes connection with the database server and returns
        // an object of SqlConnection type
        public static SqlConnection getConnection()
        {
            con = new SqlConnection(@"Data Source = WSL011805884\SQLEXPRESS; Initial Catalog =Casestudy4; Integrated Security = True");

            con.Open();
            return con;
        }
        //public void register(Student student)
        //{
        public  void InsertCourse()
        {
            con = getConnection();


            //giving static hard coded values as below will result in errors on successive execution
            // cmd = new SqlCommand("insert into employee values(300,'ADO',16000,'Others',5,'999999')",con);

            Console.WriteLine("Please enter cid,cname,duration,fee");
            int cid = Convert.ToInt32(Console.ReadLine());
            string cname = Console.ReadLine();
            //DateTime duration = Convert.ToDateTime(Console.ReadLine());
            string duration = Console.ReadLine();
            float fee = Convert.ToSingle(Console.ReadLine());




            cmd = new SqlCommand("insert into Enrollment values(@CID,@name,@duration,@fee)", con);
            //command object has property known as parameters - a collection object
            //to the parameters collection, we have to add the parameters for insert
            cmd.Parameters.AddWithValue("@CID", cid);
            cmd.Parameters.AddWithValue("@name", cname);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@fee", fee);


            int records = cmd.ExecuteNonQuery();
            if (records > 0)
            {
                Console.WriteLine("Inserted course successfully..");
            }
            else
                Console.WriteLine("Something went wrong please check ..");
        }
        public  void displayCourse()
        {
            con = getConnection();
            try
            {
                Console.WriteLine("The Course data list are:");
                cmd = new SqlCommand("select * from Course");
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3]);

                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                Console.WriteLine("Error in the Server...");
            }
        }

        public  void DeleteCourse()
        {
            con = getConnection();
            Console.WriteLine("Enter the course id to delete:");
            int cid = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd1 = new SqlCommand("Select * from Course where CID=@cid", con);
            cmd1.Parameters.AddWithValue("@cid", cid);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                for (int i = 0; i < dr1.FieldCount; i++)
                {
                    Console.WriteLine(dr1[i]);
                }
            }
            con.Close();
            Console.WriteLine("Are you Sure to delete this Course? Y/N :");
            string status = Console.ReadLine();
            if (status == "y" || status == "Y")
            {
                cmd = new SqlCommand("delete from Course where CID=@cid", con);
                cmd.Parameters.AddWithValue("@cid", cid);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine("Record of course Deleted Successfully...");
                }
                else
                    Console.WriteLine("Contact DBA..");
            }
            else if (status == "n" || status == "N")
            {
                Console.WriteLine("You Opted not to delete the Course");
            }

        }

        //else
        //{
        //    Console.WriteLine("invalid course");
        //}


        //}

        public  void UpdateCourse()
        {

            con = getConnection();
            Console.WriteLine("Enter the Course id and Cname to Update:");
            int cid = Convert.ToInt32(Console.ReadLine());
            string cname = Console.ReadLine();


            SqlCommand cmd2 = new SqlCommand("UPDATE Course Set name=@cname where CID=@cid ", con);

            cmd2.Parameters.AddWithValue("@cid", cid);

            cmd2.Parameters.AddWithValue("@cname", cname);


            try
            {
                int data = cmd2.ExecuteNonQuery();

                if (data > 0)
                {
                    Console.WriteLine(" course Updated successfully");
                }
                else
                {
                    Console.WriteLine(" course update failed");
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------Enroll course-------------");
            //InsertCourse();
            //displayCourse();

            Console.WriteLine("-------------Delete Course-----------------");
            //DeleteCourse();
            // displayCourse();

            Console.WriteLine("------------------update course-----------------------");
            //UpdateCourse();
            //displayCourse();
            //DeleteCourse();

            Console.ReadKey();
        }
    }
}

