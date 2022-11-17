using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniproject_Team3
{

    public abstract class UserInterface
    {
        AppEngine a = new AppEngine();
        Ado a1 = new Ado();
        Course1 c1 = new Course1();
        //App a = new App();
        Course[] c = new Course[3];
        public void showFirstScreen()
        {

            Console.WriteLine("--------------Welcome to the Student Management App---------------------");
            Console.WriteLine("select one option from below. \n1.Student \n 2.Admin");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    showStudentScreen();
                    break;
                case 2:
                    showAdminScreen();
                    break;
                default:
                    Console.WriteLine("******invalid input select from the given option*******");
                    break;
            }
        }
        public void showStudentScreen()
        {

        start:
            Console.WriteLine("----------Student Screen--------------");
            Console.WriteLine("1. Register new student\n2.Show the list of students\n3. to exit");
            Console.WriteLine("----------- Above choose which you need ------------");
            int showStudentScreeninput = Convert.ToInt32(Console.ReadLine());

            switch (showStudentScreeninput)
            {
                case 1:
                    showStudentRegistrationScreen();
                    break;
                case 2:
                    showAllStudentsScreen();
                    break;
                case 3:
                    Console.WriteLine("Are you sure want to exit Y/N:");
                    char exitVal = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (exitVal == 'Y')
                    {
                        Console.WriteLine("-------------Exiting student----------");
                        showFirstScreen();
                    }
                    else if (exitVal == 'N')
                    {
                        Console.WriteLine("----------you have opted for not to exit-----------");
                        goto start;
                    }
                    else
                    {
                        break;
                    }
                    break;

                default:
                    Console.WriteLine("enter the correct choice above: ");
                    break;
            }

            if (showStudentScreeninput != 3)
            {
                goto start;
            }
        }
        public void showAdminScreen()
        {
            Console.WriteLine("*****Admin Screen******");
            Console.WriteLine("1.Showallstudent detail\n2.enrollcourse\n3.show all courses\n.4.enrollment 5.list of enrollment\n");
            Console.WriteLine("----------- Above choose which you need ------------");
            int showStudentScreeninput = Convert.ToInt32(Console.ReadLine());
            switch (showStudentScreeninput)
            {
                case 1:

                    showAllStudentsScreen();
                    
                    break;

                
                case 2:
                    introduceNewCourseScreen();
                    break;
                case 3:
                    showAllCoursesScreen();
                    break;

                  

                case 4: enroll();
                    break;
                case 5:  displayenroll();
                    break;
                //showAllCoursesScreen();


                default:
                    Console.WriteLine("******enter the any one input from the above option:*********");
                    break;
            }
        }
        public void showAllStudentsScreen()
        {
            // Console.WriteLine("lst of stdnt");
            // a.listOfStudents(2);
            a1.DisplayStudent();
            
            Console.WriteLine("select one option from below. \n1.update \n 2.delete");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    a1.UpdateStudent();
                    break;
                case 2:
                    a1.DeleteStudent();
                    break;
                default:
                    Console.WriteLine("******invalid input select from the given option*******");
                    break;
            }


        }
        public void showStudentRegistrationScreen()
        {
            // Console.WriteLine("register std");
            // a.enroll();
            // a.register(2);
            //a.register();
            a1.EnrollStudent();




        }
        public void introduceNewCourseScreen()
        {
            //a.enrollcourse(2);
            //a.enroll();
            c1.InsertCourse();


        }
        public void showAllCoursesScreen()
        {
            //a.listOfCourses(c);
            c1.displayCourse();
            Console.WriteLine("select one option from below. \n1.update \n 2.delete");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    c1.UpdateCourse();
                    break;
                case 2:
                    c1.DeleteCourse();
                    break;
                default:
                    Console.WriteLine("******invalid input select from the given option*******");
                    break;
            }

        }


        public void UpdateCourse()
        {
            c1.UpdateCourse();
        }

        public void UpdateStudent()
        {
            a1.DisplayStudent();
        }

        public void DeleteStudent()
        {
            a1.DeleteStudent();
        }
        public void DeleteCourse()
        {
            c1.DeleteCourse();
        }
        public void enroll()
        {
            a.enroll();
        }


        public void displayenroll()
        {
            a.displayenroll();
        }

    }

}
