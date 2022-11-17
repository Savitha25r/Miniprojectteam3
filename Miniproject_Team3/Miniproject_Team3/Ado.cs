using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Miniproject_Team3
{
    /* question case study 4:- We had created an AppEngine class before to store data in memory.
- All we need to do now is to modify that code and introduce database connectivity.

For ex: the code for register method might look like this 
    public void register(Student student) {
		Connection con = null;
		Command cmd = null;
		try {
			con=new SqlConnection("<give connection details>");
			
			cmd=new SqlCommand("insert into student values(@1,@2,@3..)",con);
			Bind parameters here.. for the variables
  cmd.executeNonQuery();

		}
		catch(SQLException e) {
			Console.WriteLine(e); //instead throw user defined exception
		}
		finally {
			
			 con.close(); 
		}
    }*/
    
        public class Ado
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

            public  void EnrollStudent()
            {
                con = getConnection();
                Console.WriteLine("Please enter id,Sname,Date_Of_Birth");
                int sid = Convert.ToInt32(Console.ReadLine());
                string Sname = Console.ReadLine();
                DateTime dateofbirth = Convert.ToDateTime(Console.ReadLine());


                cmd = new SqlCommand("insert into Student values(@ID,@Name,@dob)", con);
                //command object has property known as parameters - a collection object
                //to the parameters collection, we have to add the parameters for insert
                cmd.Parameters.AddWithValue("@ID", sid);
                cmd.Parameters.AddWithValue("@Name", Sname);
                cmd.Parameters.AddWithValue("@dob", dateofbirth.ToShortDateString());

                int records = cmd.ExecuteNonQuery();
                if (records > 0)
                {
                    Console.WriteLine("****The student data enrolled successfully****");
                }
                else
                {
                    Console.WriteLine("****Something went wrong please check it****");
                }
                Console.WriteLine("------------------------------------");
            }
            public  void DisplayStudent()
            {
                con = getConnection();
                try
                {
                    Console.WriteLine("****The student data list are:****");
                    cmd = new SqlCommand("select * from Student");
                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);

                    }
                    Console.WriteLine("------------------------------------");
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se.Message);
                    Console.WriteLine("Error in the Server...");
                }
            }

            public  void DeleteStudent()
            {
                con = getConnection();

                Console.WriteLine("****Enter the Student Id to delete:****");
                int sid = Convert.ToInt32(Console.ReadLine());
                SqlCommand cmd1 = new SqlCommand("Select * from Student where ID=@sid", con);
                cmd1.Parameters.AddWithValue("@sid", sid);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    for (int i = 0; i < dr1.FieldCount; i++)
                    {
                        Console.WriteLine(dr1[i]);
                    }
                }
                con.Close();

                //if (dr1.HasRows)
                //{
                //    for (int i = 0; i < dr1.FieldCount; i++)
                //    {
                //        Console.WriteLine(dr1[i]);
                //    }
                //}

                //else
                //{
                //    Console.WriteLine("Invalid Student Id");
                //}


                Console.WriteLine("Are you Sure to delete this student? Y/N :");
                string status = Console.ReadLine();
                if (status == "y" || status == "Y")
                {
                    cmd = new SqlCommand("delete from Student where ID=@sid", con);
                    cmd.Parameters.AddWithValue("@sid", sid);
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Console.WriteLine("****Student data Deleted Successfully****");
                    }
                    else
                        Console.WriteLine("****Contact Admin****");
                }
                else
                {
                    Console.WriteLine("****You Opted not to delete the student not to delete*****");
                }
                Console.WriteLine("------------------------------------");

            }




            public  void UpdateStudent()
            {

                con = getConnection();

                Console.WriteLine("Enter the student id and sname to Update:");
                int sid = Convert.ToInt32(Console.ReadLine());
                string Sname = Console.ReadLine();


                SqlCommand cmd2 = new SqlCommand("UPDATE student Set Name=@Sname where ID=@sid ", con);

                cmd2.Parameters.AddWithValue("@sid", sid);

                cmd2.Parameters.AddWithValue("@Sname", Sname);


                try
                {
                    int data = cmd2.ExecuteNonQuery();

                    if (data > 0)
                    {
                        Console.WriteLine("****Student data Updated successfully****");
                    }
                    else
                    {
                        Console.WriteLine("****Student data update failed****");
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
                Console.WriteLine("------------------------------------");

            }
            static void Main(string[] args)
            {
                Console.WriteLine("********welcome to student app system*********");
                Console.WriteLine("-------------------Enroll student data-----------------------");
                //EnrollStudent();
               // DisplayStudent();

                Console.WriteLine("-------------------Delete student data-----------------------");
                //DeleteStudent();

                Console.WriteLine("-------------------Update student data--------------------------------------------");
                //UpdateStudent();
                //DisplayStudent();
                Console.WriteLine("-----------------Thank you-----------------------");
                Console.ReadKey();
            }
        }
    }
   
