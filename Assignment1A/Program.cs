using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//1.Einai kako na kanw implement olo to output tou menu se ena allo help static class? giati tha ginei megalo me polles methodoues kai h main tha exei polu liga pragmata
//einai san na metaferw apla oli ti douleia tis main sto menu class
//2. Einai bad practise na balw stin program static variables?(ta courses)
//3. Ta dates prepei na einai correct metaksi tous? p.x. ena student ginete na exei genithei meta apo
//TWRA kai assignment SUB_DATE?
//4. Pou na apotrepsw ton xristi apto na kataxwrei bugs? sto program h' stin class pou ftiaxnoume to object?(duplicate student)
// to stream ti einai?
// mporw na stamataw to input rotontas ton xristi?
namespace Assignment1A
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            bool exit = false;
            List<Course> courses = new List<Course>();
            while (!exit)
            {
                short choice = outputMainMenu();
                if (choice == 1)//enter entities
                {
                    bool continue_adding_entities = true;
                    while (continue_adding_entities)
                    {
                        choice = outputEnterEntityMenu();
                        if (choice == 1)// enter students mode
                        {
                            bool continue_adding = true;
                            while (continue_adding)
                            {
                                //check if courses exist
                                //check if student exists in the same course
                                if (courses.Count == 0)
                                    Console.WriteLine("You don't have any courses to add students to");
                                else
                                {
                                    Course course = chooseCourse(courses);
                                    Student s = constructStudent();
                                    if (isDuplicate(course, s))
                                        Console.WriteLine("ERROR: STUDENT {0} {1} ALREADY EXISTS IN COURSE {2}", s.getFirstName(), s.getLastName(), course.getTitle());
                                    else
                                    {
                                        course.addStudent(s);
                                    }
                                }

                                continue_adding = insistForCorrectInput("Continue Adding Students?\n1.Yes\n2.No", (short)1, (short)2) == 1 ? true : false;
                            }
                        }
                        if (choice == 2)
                        {
                            bool continue_adding = true;
                            while (continue_adding)
                            {
                                if (courses.Count == 0)
                                    Console.WriteLine("You don't have any courses to add trainers to");
                                else
                                {
                                    Course course = chooseCourse(courses);
                                    Trainer trainer = constructTrainer();

                                    course.addTrainer(trainer);
                                }
                                continue_adding= insistForCorrectInput("Continue Adding Trainers?\n1.Yes\n2.No", (short)1, (short)2) == 1 ? true : false;
                            }
                        }
                        //if(choice==3)
                        if (choice == 4)
                        {

                        }
                        continue_adding_entities= insistForCorrectInput("Continue Adding Entities?\n1.Yes\n2.No", (short)1, (short)2) == 1 ? true : false;
                    }
                }
                else if (choice == 2)
                {
                    outputViewEntityMenu();
                }
                else if (choice == 3)
                {
                    outputEditEntityMenu();
                }
                else if (choice == 4)
                {
                    exit = true;
                }
            }
        }

        //private static short chooseCourse(List<Course> courses)
        //{
        //    string outp="";
        //    for (int i = 0; i < courses.Count; i++)
        //        outp += String.Format("\n{0}.{1}",i,courses[i].getTitle());
        //    return 
        //}
        public static Trainer constructTrainer()
        {
            Console.Write("Enter first name:");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name:");
            string lastName = Console.ReadLine();
            Console.Write("Enter subject:");
            string subject = Console.ReadLine();

            return new Trainer(firstName, lastName, subject);
        }
        public static Student constructStudent()
        {
            Console.Write("Enter first name:");
            string firstName=Console.ReadLine();
            Console.Write("Enter last name:");
            string lastName=Console.ReadLine();
            Console.Write("Birth date (format dd/mm/yyyy):");
            DateTime dateOfBirth=insistForCorrectDateInput();
            Console.WriteLine("Enter his tuition fees");
            int tuition_fees;
            while(!int.TryParse(Console.ReadLine(),out tuition_fees) || tuition_fees<0)
            {
                Console.WriteLine("You need to enter a positive integer for the fees");
            }

            return new Student(firstName, lastName, dateOfBirth, tuition_fees);
        }

        private static DateTime insistForCorrectDateInput()
        {
            DateTime date;
            while(DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                       DateTimeStyles.None,out date))
            {
                Console.WriteLine("You need to enter a date of the format dd/mm/yyyy");
            }
            return date;     
        }

        private static bool isDuplicate(Course course,Student student)
        {
            foreach(Student stuIter in course.getStudents())
                if (stuIter.getFirstName() == student.getFirstName() && stuIter.getLastName() == student.getLastName())
                    return true;
            return false;     
        }
        private static bool isDuplicate(Course course,Trainer trainer)
        {
            for
        }

        public static short outputMainMenu()
        {
            String outp = @"Please type in a number corresponding to the option you want to be executed:
    1.To enter entities
    2.To edit entities
    3.To view entities
    4.To exit the program.";
            return insistForCorrectInput(outp, 1, 4);
        }

        public static short outputViewEntityMenu()
        {
            string outp = @"Please type in a number corresponding to the option you want to be executed:
    1.To view all the students
    2.To view all the trainers
    3.To view all the assignments
    4.To view all the courses
    5.To view all the students per course
    6.To view all the trainers per course
    7.To view all the assisgnments per course
    8.To view all the assignments per student
    9. To view a list of students that belong to more than 1 courses";
            return insistForCorrectInput(outp, 1, 9);
        }

        public static void outputEditEntityMenu()
        {
            throw new NotImplementedException();
        }

        public static short outputEnterEntityMenu()
        {
            string outp = @"Please type in a number corresponding to the option you want to be executed:
    1.Enter student(s)
    2.Enter trainer(s)
    3.Enter assignment(s)
    4.Enter course(s)
    5.Generate synthetic data for all entities";
            return insistForCorrectInput(outp, 1, 5);
        }
        public static Course chooseCourse(List<Course> courses)
        {
            string outp = "";
            for (int i = 0; i < courses.Count; i++)
                outp += String.Format("\n{0}.{1}", i + 1, courses[i].getTitle());
            return courses[insistForCorrectInput(outp, 1, (short)courses.Count) - 1];

        }

        private static short insistForCorrectInput(string output, short start, short end)
        {
            Console.WriteLine(output);
            short input;
            while (!short.TryParse(Console.ReadLine(), out input) || input < start || input > end)
                Console.WriteLine("ERROR:YOU NEED TO ENTER AN INT FROM {0} TO {1}.\n{2}", start, end, output);
            return input;
        }
    }
}
