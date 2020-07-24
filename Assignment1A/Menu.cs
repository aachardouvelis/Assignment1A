using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    public static class Menu
    {
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
                outp += String.Format("\n{0}.{1}", i+1, courses[i].getTitle());
            return courses[insistForCorrectInput(outp, 1, (short)courses.Count)-1];
           
        }

        private static short insistForCorrectInput(string output, short start, short end)
        {
            Console.WriteLine(output);
            short input;
            while (!short.TryParse(Console.ReadLine(), out input) || input<start || input>end)
                Console.WriteLine("ERROR:YOU NEED TO ENTER AN INT FROM {0} TO {1}.\n{2}", start, end, output);
            return input;
        }

    }
}
