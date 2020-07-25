using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    public static class Menu
    {
        
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
            string firstName = Console.ReadLine();
            Console.Write("Enter last name:");
            string lastName = Console.ReadLine();
            Console.Write("Birth date (format dd/mm/yyyy):");
            DateTime dateOfBirth = insistForCorrectDateInput();
            Console.Write("Enter his tuition fees:");
            int tuition_fees;
            while (!int.TryParse(Console.ReadLine(), out tuition_fees) || tuition_fees < 0)
            {
                Menu.WriteLineRed("You need to enter a positive integer for the fees.");
                Console.Write("Please try again:");
            }

            return new Student(firstName, lastName, dateOfBirth, tuition_fees);
        }
        public static Assignment ConstructAssignment()
        {
            Console.Write("Please enter the assignment's title:");
            String title = Console.ReadLine();
            Console.Write("Please enter the assignment's description:");
            String descr = Console.ReadLine();
            Console.Write("Please enter the assignment's oral mark:");
            float oral;
            while (!float.TryParse(Console.ReadLine(), out oral) && oral < 100 && oral >= 0)
                Console.Write("Please enter a float from 1 to 100.");
            Console.Write("Please enter the assignment's total mark:");
            float total;
            while (!float.TryParse(Console.ReadLine(), out total) && total < 100 && total >= 0)
                Console.Write("Please enter a float from 1 to 100.");
            Console.Write("Please enter the assignment's submission date:");
            DateTime sub_date = insistForCorrectDateInput(true);
            return new Assignment(title, descr, oral, total, sub_date);
        }
        

        internal static Course ConstructCourse()
        {
            Console.Write("Please enter a Title:");
            string title = Console.ReadLine();
            Console.Write("Please enter the type:");
            string type = Console.ReadLine();
            Console.Write("Please enter the stream:");
            string stream = Console.ReadLine();
            Console.Write("Please enter the course's start date (dd/MM/yyyy):");
            DateTime start = Menu.insistForCorrectDateInput(true);
            Console.Write("Please enter the course's end date (dd/MM/yyyy):");
            DateTime end = Menu.insistForCorrectDateInput(true);
            while (start.Subtract(end).TotalDays > 0)//start date after end date
            {
                Menu.WriteLineRed("The end date given was before the start date.");
                Console.Write("Please re-enter the course's start date (dd/MM/yyyy)");
                start = Menu.insistForCorrectDateInput(true);
                Console.Write("Please re-enter the course's end date (dd/MM/yyyy)");
                end = Menu.insistForCorrectDateInput(true);
            }

            return new Course(title, type, stream, start, end);
        }

       

        //private static bool isDuplicate(List<Assignment> assignments,Assignment assignment)
        //{
        //    //CHECK IF IT WORKS FOR LIST SIZE ==0
        //    foreach (Assignment assIter in assignments)
        //        if (assignment.ID == assIter.ID)
        //            return true;
        //    return false;
        //}

        //public static bool isDuplicate(List<Course> courses, Course course)
        //{
        //    foreach (Course curIter in courses)
        //        if (curIter.getTitle() == course.getTitle() 
        //                && curIter.getType() == course.getType() 
        //                && curIter.getStream() == course.getStream())
        //            return true;
        //    return false;
        //}

        //public static bool isDuplicate(List<Identity> elements,Identity element)
        //{
        //    foreach (Identity idIter in elements)
        //        if (idIter.ID == element.ID)
        //            return true;
        //    return false;
        //}

        public static bool isDuplicate(IEnumerable<Identity> elements, Identity element)
        {
            foreach (Identity idIter in elements)
                if (idIter.ID == element.ID)
                    return true;
            return false;
        }

        public static string getMainMenuStr()
        {
            String outp = @"    1.To enter entities
    2.To edit entities
    3.To view entities
    4.To exit the program.";
            return outp;
        }

        public static string getViewEntityMenuStr()
        {
            string outp = @"    1.To view all the students
    2.To view all the trainers
    3.To view all the assignments
    4.To view all the courses
    5.To view all the students per course
    6.To view all the trainers per course
    7.To view all the assisgnments per course
    8.To view all the assignments per student
    9. To view a list of students that belong to more than 1 courses
    10.To enter a date and view all students that need to submit at least one exam that week";

            return outp;
        }
        public static string getEnterEntityMenuStr()
        {
            string outp = @"    1.Enter student(s)
    2.Enter trainer(s)
    3.Enter assignment(s)
    4.Enter course(s)
    5.Generate synthetic data for all entities";
            return outp;
        }
        public static string getEditEntityStr()
        {

            string outp = @"    1.To add existing students to other courses
    2.To add existing trainers to other courses
    3.To add existing assignments to other courses
    4.To remove a students from a course
    5.To remove a trainers from a course
    6.To remove an assignment from a course
    7.To remove a course completely";
            
            return outp;
        }
        
        public static List<Course> GetSyntheticData1()
        {
            Course course1 = new Course("Java", "Programming", "J1", new DateTime(2020, 1, 1), new DateTime(2020, 12, 1));
            Course course2 = new Course("Java", "Programming", "J2", new DateTime(2020, 6, 1), new DateTime(2020, 12, 1));
            Course course3 = new Course("C#", "Programming", "C1", new DateTime(2020, 6, 1), new DateTime(2021, 6, 1));

            Student stu1 = new Student("George", "Georgakis", new DateTime(2000, 10, 3), 300.5);
            Student stu2 = new Student("John", "Johnnakis", new DateTime(1998, 5, 9), 200.5);
            Student stu3 = new Student("Chris", "Chrissoulis", new DateTime(1990, 11, 4), 320.5);
            Student stu4 = new Student("Athan", "Nasios", new DateTime(2002, 4, 3), 350.5);
            Student stu5 = new Student("Peter", "Peterinio", new DateTime(2004, 10, 3), 350.5);
            Student stu6 = new Student("Kostas", "Kostakis", new DateTime(2002, 6, 22), 222.22);

            Trainer tr1 = new Trainer("Sammy", "Samson", "History");
            Trainer tr2 = new Trainer("Jimmy", "Jimelton", "Data Bases");
            Trainer tr3 = new Trainer("Fred", "Frederson", "OOP");
            

            Assignment ass1 = new Assignment("School database", "Create 3 school entities and connect them", 5, 30, new DateTime(2020, 7, 27));
            Assignment ass2 = new Assignment("Weather application", "Create a weather app", 5, 30, new DateTime(2020, 7, 28));//MONDAY
            Assignment ass3 = new Assignment("School Project", "Create 3 school entities and connect them", 5, 30, new DateTime(2020, 5, 27));
            Assignment ass4 = new Assignment("PC game", "Re-create pacman", 10, 50, new DateTime(2020, 6, 10));
            Assignment ass5 = new Assignment("Projname1231", "projecdescription here", 20, 60, new DateTime(2020, 6, 12));
            Assignment ass6 = new Assignment("Proj11131", "projecdescription here here here", 15, 35, new DateTime(2020, 3, 3));

            course1.addAssignment(ass1);
            course1.addAssignment(ass2);
            course3.addAssignment(ass2);
            course1.addAssignment(ass3);
            course2.addAssignment(ass4);
            course3.addAssignment(ass5);
            course3.addAssignment(ass6);

            course1.addStudent(stu1);
            course2.addStudent(stu1);
            course1.addStudent(stu2);
            course1.addStudent(stu3);
            course2.addStudent(stu4);
            course2.addStudent(stu5);
            course3.addStudent(stu6);
            course3.addStudent(stu1);

            course1.addTrainer(tr1);
            course2.addTrainer(tr2);
            course3.addTrainer(tr3);
            course3.addTrainer(tr2);
            List<Course> courses = new List<Course>();
            
            courses.Add(course1);
            courses.Add(course2);
            courses.Add(course3);
            return courses;
        }

        public static List<Course> getCoursesNotOfElement(List<Course>courses, Identity iden)
        {
            List<Course> notOwnedCourses = new List<Course>();
            foreach (Course courIter in courses)
                if (!courIter.containsElement(iden))
                    notOwnedCourses.Add(courIter);
            return notOwnedCourses;
        }

        //internal static List<Course> getCoursesNotOfTrainer(List<Course> courses, Trainer trainer)
        //{
        //    List<Course> notOwnedCourses = new List<Course>();
        //    foreach (Course courIter in courses)
        //        if (!courIter.hasTrainer(trainer))
        //            notOwnedCourses.Add(courIter);
        //    return notOwnedCourses;
        //}

        //internal static List<Course> getCoursesNotOfStudent(List<Course> courses,Student student)
        //{
        //    List<Course> notOwnedCourses = new List<Course>();
        //    foreach (Course courIter in courses)
        //        if (!courIter.hasStudent(student))
        //            notOwnedCourses.Add(courIter);
        //    return notOwnedCourses;
        //}
        //internal static List<Course> getCoursesNotOfAssignment(List<Course> courses, Assignment chosen_assignment)
        //{
        //    List<Course> notOwnedCourses = new List<Course>();
        //    foreach (Course courIter in courses)
        //        if (!courIter.hasAssignment(chosen_assignment))
        //            notOwnedCourses.Add(courIter);
        //    return notOwnedCourses;

        //}
        

        public static short insistForCorrectInput(string outputMenu, short start, short end,string title="")
        {
            Menu.WriteLineYellow(title);
            Console.WriteLine(outputMenu);
            short input;
            while (!short.TryParse(Console.ReadLine(), out input) || input < start || input > end)
            {
                WriteLineRed(String.Format("Error: You need to enter an int from {0} to {1}.", start, end));
                Console.WriteLine(outputMenu);
            }
            return input;
        }
        public static DateTime insistForCorrectDateInput(bool weekends_excluded = false)
        {
            DateTime date=new DateTime();
            bool flag = true;
            string weekendStr = weekends_excluded ? "weekday(Mon-Fri)" : "";
            bool date_parsed = false;
            Menu.WriteLineYellow("Please enter a date in the form of dd/MM/yyyy");
            while (flag)
            {
                if (date_parsed = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out date))
                {
                    //ERROR PARSING DATES
                    if (weekends_excluded && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                        flag = false;
                    else if (!weekends_excluded)
                        flag = false;
                    else
                    {  
                        Menu.WriteLineRed("You didn't enter a " + weekendStr + "date of the format dd/mm/yyyy.");
                        if (date_parsed)
                            Menu.WriteLineRed(String.Format("The date you entered is a {0}", date.DayOfWeek));
                        Menu.WriteLineYellow("Please try again:");
                    }
                }
                else
                {
                    Menu.WriteLineRed("You didn't enter a date of the format dd/MM/yyyy");
                    Menu.WriteLineYellow("Please try again:");
                }

            }
            return date;

           
        }

        public static string listToMenuStr<E>(List<E> list)
        {
            string outp = "";

            for (int i = 0; i < list.Count(); i++)
                outp += String.Format("\n{0}.{1}", i+1, list[i]);
            return outp;
        }

        //public static void removeCourse(List<Course> courses, Course course)
        //{

        //    for (int i = 0; i < courses.Count; i++)//foreach(Course courIter in courses)
        //        if (courses[i].ID == course.ID)
        //        {
        //            courses.RemoveAt(i);
        //            break;
        //        }
        //}
        //public static void removeElementFromCourses(List<Course> courses, IEnumerable<Identity> distinct_elements)
        //{
        //    //IEnumerable<Identity> elements;
        //    //if (typeof(Trainer).IsInstanceOfType(element))
        //    //    elements = Menu.getDistinctTrainers(courses);
        //    //else if (typeof(Student).IsInstanceOfType(element))
        //    //    elements = Menu.getDistinctStudents(courses);
        //    //else if (typeof(Assignment).IsInstanceOfType(element))
        //    //    elements = Menu.getDistinctAssignments(courses);
        //    //else
        //    //    throw new ArgumentException("can only remove Assignments Trainers or Students");
        //    Console.WriteLine((List<Identity>)distinct_elements);
        //    List<Identity> iden_list = (List<Identity>)distinct_elements;


        //    if (iden_list.Count() > 0)
        //    {
        //        int choice = Menu.selectFromList("Select an entity to edit:", iden_list);
        //        Identity chosen_element = iden_list[choice - 1];
        //        List<Course> owned_courses = Menu.getCoursesOfIdentity(courses, chosen_element);
        //        string menu_title = String.Format("Entity {0} can be removed from the following courses. Pick one:", chosen_element);
        //        if (owned_courses.Count > 0)
        //        {
        //            choice = Menu.selectFromList(menu_title, owned_courses);
        //            Course chosen_course = owned_courses[choice - 1];
        //            chosen_course.remove(chosen_element);
        //        }

        //        else
        //            Menu.WriteLineRed(String.Format("Entity {0} isn't added in any courses yet", chosen_element));
        //    }
        //    else
        //        Menu.WriteLineRed("No such entity has been created yet..");
        //}
        public static int selectFromList<E>(string title,List<E> list)
        {
            
            if (list.Count() < 0)
                return -1;
            else
            {
                
                string menu_str = Menu.listToMenuStr(list);
                //Menu.WriteLineYellow(title);
                int choice = insistForCorrectInput(menu_str, 1, (short)list.Count,title);
                return choice;
            }
        }

        public static Student selectStudent(List<Course> courses)
        {
            List<Student> distinct_students = Menu.getDistinctStudents(courses);
            //if (distinct_students.Count > 0)
            //{
            string menu_str = Menu.listToMenuStr(distinct_students);
            Console.WriteLine("Select a student to edit:");
            Console.WriteLine(menu_str);
            int choice = Menu.insistForCorrectInput(menu_str, 1, (short)distinct_students.Count);
            Student chosen_student = distinct_students[choice - 1];
            //}
            return chosen_student;

        }
        public static Trainer selectTrainer(List<Course> courses)
        {
            Console.WriteLine("Select a trainer to edit:");
            List<Trainer> distinct_trainers = Menu.getDistinctTrainers(courses);
            string menu_str = Menu.listToMenuStr(distinct_trainers);
            Console.WriteLine(menu_str);
            int choice = Menu.insistForCorrectInput(menu_str, 1, (short)distinct_trainers.Count);
            Trainer chosen_trainer = distinct_trainers[choice - 1];
            return chosen_trainer;
        }



        public static Assignment selectAssignment(List<Course> courses)
        {
            Console.WriteLine("Select an assignment to edit:");
            List<Assignment> distinct_assignments = Menu.getDistinctAssignments(courses);
            string menu_str = Menu.listToMenuStr(distinct_assignments);
            Console.WriteLine(menu_str);
            int choice = Menu.insistForCorrectInput(menu_str, 1, (short)distinct_assignments.Count);
            Assignment chosen_assignment = distinct_assignments[choice - 1];
            return chosen_assignment;
        }
        public static List<Assignment> getAssignmentsOfStudent(List<Course> courses, Student student)
        {
            List<Course> student_courses = getCoursesOfIdentity(courses, student);

            List<Assignment> distinct_assignments = new List<Assignment>();
            foreach (Course courseIter in student_courses)
                foreach (Assignment assIter in courseIter.getAssignments())
                    if (!isDuplicate(distinct_assignments, assIter))
                        distinct_assignments.Add(assIter);
            return distinct_assignments;
        }

        
         
        internal static List<Student> getDistinctStudents(List<Course> courses)
        {
            List<Student> distinct = new List<Student>();


            foreach (Course courseIter in courses)
                foreach (Student stuIter in courseIter.getStudents())
                    if (!isDuplicate(distinct, stuIter))
                        distinct.Add(stuIter);
            return distinct;
        }

        public static List<Trainer> getDistinctTrainers(List<Course> courses)//UnitTest
        {
            List<Trainer> distinct = new List<Trainer>();


            foreach (Course courseIter in courses)
                foreach (Trainer trainerIter in courseIter.getTrainers())
                    if (!isDuplicate(distinct, trainerIter))
                        distinct.Add(trainerIter);
            return distinct;
        }

        public static List<Assignment> getDistinctAssignments(List<Course> courses)
        {
            List<Assignment> distinct = new List<Assignment>();

            foreach (Course courseIter in courses)
                foreach (Assignment assIter in courseIter.getAssignments())
                    if (!isDuplicate(distinct, assIter))
                        distinct.Add(assIter);
            return distinct;
        }

        public static List<Student> getIndistinctStudents(List<Course> courses)
        {
            List<Student> traversed_once = new List<Student>();
            List<Student> traversed_twice = new List<Student>();
            foreach (Course courseIter in courses)
                foreach (Student stuIter in courseIter.getStudents())
                {
                    if (!isDuplicate(traversed_once, stuIter))
                        traversed_once.Add(stuIter);
                    else
                    {
                        if (!isDuplicate(traversed_twice, stuIter))
                            traversed_twice.Add(stuIter);
                    }
                }
            return traversed_twice;
        }
        public static DateTime WeekDayDate(DateTime date_given, DayOfWeek weekday)
        {
            DayOfWeek day_given = date_given.DayOfWeek;
            int day_diff = weekday-day_given;
            DateTime mondayDate = date_given.AddDays(day_diff);
            return mondayDate;
        }

        public static List<Course> getCoursesOfIdentity(List<Course> courses, Identity iden)
        {
            if (typeof(Course).IsInstanceOfType(iden))
                throw new ArgumentException("Can't check if a course contains a course..!");
            List<Course> students_courses = new List<Course>();
            foreach (Course courseIter in courses)
                if (courseIter.containsElement(iden))
                    students_courses.Add(courseIter);
            return students_courses;
        }
        //public static List<Course> getCoursesOfStudent(List<Course> courses, Student student)
        //{
        //    List<Course> students_courses = new List<Course>();
        //    foreach (Course courseIter in courses)
        //            if(courseIter.hasStudent(student))
        //                students_courses.Add(courseIter);
        //    return students_courses;
        //}

        //public static List<Course> getCoursesOfTrainer(List<Course> courses, Trainer trainer)
        //{
        //    List<Course> trainers_courses = new List<Course>();
        //    foreach (Course courseIter in courses)
        //        if (courseIter.hasTrainer(trainer))  
        //            trainers_courses.Add(courseIter);
        //    return trainers_courses;
        //}

        //internal static List<Course> getCoursesOfAssignment(List<Course> courses, Assignment chosen_assignment)
        //{
        //    List<Course> ass_courses = new List<Course>();
        //    foreach (Course courIter in courses)
        //        if (courIter.hasAssignment(chosen_assignment))
        //            ass_courses.Add(courIter);
        //    return ass_courses;
        //}

        internal static List<Student> getWeekSubmissionStudents(List<Course> courses,DateTime monday,DateTime friday)
        {
            
            bool[] courseStudentsAdded = new bool[courses.Count];

            List<Student> distinct_student_list = new List<Student>();
            List<Assignment> traversed_assignments = new List<Assignment>();
            //List<Assignment> traversed_twice = new List<Assignment>();
            

            DateTime subTime =new DateTime();
            for(int i=0;i<courses.Count;i++)//foreach(Course courIter in courses)
                foreach(Assignment assIter in courses[i].getAssignments())
                {
                    subTime=assIter.getSubDateTime();
                    if (subTime >= monday && subTime <= friday)
                        if (!isDuplicate(traversed_assignments, assIter))
                        {
                            traversed_assignments.Add(assIter);
                            if (!courseStudentsAdded[i])
                            {
                                courseStudentsAdded[i] = true;
                                foreach (Student stuIter in courses[i].getStudents())
                                    if (!isDuplicate(distinct_student_list, stuIter))
                                        distinct_student_list.Add(stuIter);
                                //distinct_student_list.Concat(courses[i].getStudents());
                            }

                        }

                }
            return distinct_student_list;
        }

        public static void WriteLineRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteLineBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteLineYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
