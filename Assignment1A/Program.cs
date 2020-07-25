using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Assignment1A
{
    // SATURDAY SUNDAY NOT ALOUD IN DATETIME
    // To view Students posa properties prepei na kanei display? 
    //To edit pos akribos prepei nane?
    // h main mou exei arketo kodika se kathe if statement - den einai if branches me 1 method sto kathe branch
    //get set for every attribute.
    // To explicit casting pernei xrono? an kanw ena ienumerical->list pernei xrono analoga me to megethos tis listas?
    class Program
    {
        
        static void Main(string[] args)
        {
            
            bool exit = false;
            bool syntheticUsed = false; // implement
            const string default_menu_title = "Please type in a number corresponding to the option you want to be executed:";
            List<Course> courses = new List<Course>();
            while (!exit)
            {
                //Menu.outputMainMenu();
                int choice = Menu.insistForCorrectInput(Menu.getMainMenuStr(),1,4, default_menu_title);
                if (choice == 1)//enter entities
                {
                    bool continue_adding_entities = true;
                    while (continue_adding_entities)
                    {
                        choice = Menu.insistForCorrectInput(Menu.getEnterEntityMenuStr(), 1, 5, default_menu_title);
                        if (choice == 1)// enter students mode
                        {
                            bool continue_adding = true;
                            while (continue_adding)
                            {
                                //check if courses exist
                                //check if student exists in the same course
                                if (courses.Count == 0)
                                    Menu.WriteLineRed("You don't have any courses to add students to");
                                else
                                {
                                    choice = Menu.selectFromList("Select a course to add the student to:", courses); 
                                    Course courseChosen = courses[choice - 1];//'-1' need to scale down the menu choice (1-max)->)(0-max)
                                    Student s = Menu.constructStudent();
                                    courseChosen.addStudent(s);
                                    //if (Menu.isDuplicate(course, s))
                                    //    Console.WriteLine("ERROR: STUDENT {0} {1} ALREADY EXISTS IN COURSE {2}", s.getFirstName(), s.getLastName(), course.getTitle());
                                    //else
                                    //{
                                    //    course.addStudent(s);
                                    //}
                                }

                                continue_adding = Menu.insistForCorrectInput("Continue Adding Trainers?", (short)1, (short)2, "Yes\n2.No") == 1 ? true : false;
                            }
                        }
                        else if (choice == 2)//Enter trainers mode
                        {
                            bool continue_adding = true;
                            while (continue_adding)
                            {
                                if (courses.Count == 0)
                                    Menu.WriteLineRed("You don't have any courses to add trainers to");
                                else
                                {
                                    choice = Menu.selectFromList("Please select a course:", courses);
                                    //String courses_menu = Menu.listToMenuStr(courses);// Menu.getCourseMenuStr(courses);
                                    //choice = Menu.insistForCorrectInput(courses_menu, 1, (short)courses.Count);

                                    Course courseChosen = courses[choice - 1];//'-1' need to scale down the menu choice (1-max)->)(0-max)
                                    Trainer trainer = Menu.constructTrainer();

                                    courseChosen.addTrainer(trainer);
                                }
                                continue_adding = Menu.insistForCorrectInput("1.Yes\n2.No", (short)1, (short)2, "Continue Adding Trainers?") == 1 ? true : false;
                            }
                        }
                        else if (choice == 3)//Enter Assignment mode
                        {
                            bool continue_adding = true;
                            while (continue_adding)
                            {
                                if (courses.Count == 0)
                                    Menu.WriteLineRed("You don't have any courses to add assignments to");
                                else
                                {
                                    choice = Menu.selectFromList("Please select a course:", courses);

                                    Course courseChosen = courses[choice - 1];//'-1' need to scale down the menu choice (1-max)->)(0-max
                                    Assignment assignment = Menu.ConstructAssignment();
                                    courseChosen.addAssignment(assignment);
                                }
                                continue_adding = Menu.insistForCorrectInput("1.Yes\n2.No", (short)1, (short)2, "Continue Adding assignments?") == 1 ? true : false;
                            }
                        }
                        else if (choice == 4)// enter course
                        {
                            bool continue_adding = true;
                            while (continue_adding)
                            {
                                Course course = Menu.ConstructCourse();
                                if (!Menu.isDuplicate(courses, course))
                                    courses.Add(course);
                                else
                                    Menu.WriteLineRed("That course already exists.");
                                continue_adding = Menu.insistForCorrectInput("1.Yes\n2.No", (short)1, (short)2, "Continue Adding Courses?") == 1 ? true : false;
                            }
                        }
                        else if (choice == 5)// enter Synthetic Data
                        {
                            if (!syntheticUsed)
                            {
                                syntheticUsed = true;
                                List<Course> synthetic_data = Menu.GetSyntheticData1();
                                foreach (Course courIter in synthetic_data)
                                    courses.Add(courIter);
                            }
                            else
                                Menu.WriteLineRed("Can't add synthetic data twice!");
                        }
                        continue_adding_entities = Menu.insistForCorrectInput("1.Yes\n2.No", (short)1, (short)2, "Continue Adding Entities?") == 1 ? true : false;
                    }
                }
                else if (choice == 2)// EDIT MODE
                {
                    bool continue_editting = true;
                    while (continue_editting)
                    {
                        string outp = Menu.getEditEntityStr();
                        choice = Menu.insistForCorrectInput(outp, 1, 7,default_menu_title);
                        if (choice == 1)//Edit: +students ->courses
                        {
                            List<Student> students = Menu.getDistinctStudents(courses);
                            if (students.Count > 0)
                            {
                                choice = Menu.selectFromList("Please select a student:", students);
                                Student chosen_student = students[choice - 1];
                                //Menu.WriteLineBlue("Chosen students:" + chosen_student);
                                List<Course> available_courses = Menu.getCoursesNotOfElement(courses, chosen_student);
                                if (available_courses.Count > 0)
                                {
                                    //Menu.WriteLineBlue("student's available courses > 0");
                                    string menu_title = String.Format("Student {0} {1} can be additionally added to the following courses. Pick one:", chosen_student.getFirstName(), chosen_student.getLastName());
                                    choice = Menu.selectFromList(menu_title, available_courses);
                                    Course chosen_course = available_courses[choice - 1];
                                    chosen_course.addStudent(chosen_student);// 1.CHECK FOR POTENTIAL BUGS 2.IMPLEMENT GENERICS

                                }
                                else
                                    Menu.WriteLineRed("Student {0} is already added in every existing course");
                            }
                            else
                                Menu.WriteLineRed("No students have been added yet.");

                        }
                        else if (choice == 2)//Edit: +trainers ->courses
                        {

                            List<Trainer> trainers_list = Menu.getDistinctTrainers(courses);
                            if (trainers_list.Count > 0)
                            {
                                choice = Menu.selectFromList("Please select a trainer:", trainers_list);
                                Trainer chosen_trainer = trainers_list[choice - 1];
                                List<Course> available_courses = Menu.getCoursesNotOfElement(courses, chosen_trainer);
                                if (available_courses.Count > 0)
                                {
                                    string menu_title = String.Format("Trainer {0} {1} can be additionally added to the following courses. Pick one:", chosen_trainer.getFirstName(), chosen_trainer.getLastName());
                                    choice = Menu.selectFromList(menu_title, available_courses);
                                    Course chosen_course = available_courses[choice - 1];
                                    chosen_course.addTrainer(chosen_trainer);
                                }
                                else
                                    Menu.WriteLineRed(string.Format("Trainer {0} {1} is already added in every existing course", chosen_trainer.getFirstName(), chosen_trainer.getLastName()));

                            }
                            else
                                Menu.WriteLineRed("No Trainers have been added yet");


                        }
                        else if (choice == 3)//Edit: +assignments ->courses
                        {

                            //Assignment chosen_assignment = Menu.selectAssignment(courses);
                            List<Assignment> assignments = Menu.getDistinctAssignments(courses);
                            //Menu.removeElementFromCourses(courses, assignments);
                            if (assignments.Count > 0)
                            {
                                choice = Menu.selectFromList("Please select an assignment:", assignments);
                                Assignment chosen_assignment = assignments[choice - 1];
                                List<Course> available_courses = Menu.getCoursesNotOfElement(courses, chosen_assignment);
                                if (available_courses.Count > 0)
                                {
                                    string menu_title = String.Format("Assignment {0} can be additionally added to the following courses. Pick one:", chosen_assignment.getTitle());
                                    choice = Menu.selectFromList(menu_title, available_courses);
                                    Course chosen_course = available_courses[choice - 1];
                                    chosen_course.addAssignment(chosen_assignment);
                                }
                                else
                                    Menu.WriteLineRed(string.Format("Assignment {0} is already added in every existing course", chosen_assignment.getTitle()));

                            }
                            else
                                Menu.WriteLineRed("No assignments have been created yet");
                        }
                        else if (choice == 4)//Edit: -students ->courses
                        {
                            List<Student> distinct_students = Menu.getDistinctStudents(courses);
                            if (distinct_students.Count > 0)
                            {
                                choice = (short)Menu.selectFromList("Select a student to edit:", distinct_students);
                                Student chosen_student = distinct_students[choice - 1];

                                List<Course> owned_courses = Menu.getCoursesOfIdentity(courses, chosen_student);
                                if (owned_courses.Count > 0)
                                {
                                    string menu_title = String.Format("Student {0} {1} can be removed from the following courses. Pick one:", chosen_student.getFirstName(), chosen_student.getLastName());
                                    choice = Menu.selectFromList(menu_title, owned_courses);
                                    Course chosen_course = owned_courses[choice - 1];
                                    chosen_course.remove(chosen_student);
                                }
                                else
                                    Menu.WriteLineRed(String.Format("Student {0} isn't added in any courses yet", chosen_student.getFirstName() + " " + chosen_student.getLastName()));
                            }
                            else
                                Menu.WriteLineRed("No students have been added yet");

                        }
                        else if (choice == 5)//Edit: -trainers ->courses
                        {
                            List<Trainer> trainers = Menu.getDistinctTrainers(courses);
                            if (trainers.Count > 0)
                            {
                                choice = Menu.selectFromList("Select a trainer to edit:", trainers);
                                Trainer chosen_trainer = trainers[choice - 1];
                                List<Course> owned_courses = Menu.getCoursesOfIdentity(courses, chosen_trainer);
                                string menu_title = String.Format("Trainer {0} {1} can be removed from the following courses. Pick one:", chosen_trainer.getFirstName(), chosen_trainer.getLastName());
                                if (owned_courses.Count > 0)
                                {
                                    choice = Menu.selectFromList(menu_title, owned_courses);
                                    Course chosen_course = owned_courses[choice - 1];
                                    Menu.WriteLineBlue(String.Format("In edit -trainers main.\nChosen Course:{0}\nChosen Trainer:{1}", chosen_course, chosen_trainer));
                                    chosen_course.remove(chosen_trainer);
                                }

                                else
                                    Menu.WriteLineRed(String.Format("Trainer {0} isn't added in any courses yet", chosen_trainer.getFirstName() + " " + chosen_trainer.getLastName()));
                            }
                        }
                        else if (choice == 6)//Edit: -assignments ->courses
                        {
                            List<Assignment> assignments = Menu.getDistinctAssignments(courses);
                            //Menu.removeElementFromCourses(courses, assignments);
                            if (assignments.Count > 0)
                            {
                                choice = Menu.selectFromList("Select an assignment:", assignments);
                                Assignment chosen_assignment = assignments[choice - 1];
                                List<Course> owned_courses = Menu.getCoursesOfIdentity(courses, chosen_assignment);
                                string menu_str = Menu.listToMenuStr(owned_courses);
                                if (owned_courses.Count > 0)
                                {
                                    string menu_title = String.Format("Assignment {0} can be removed from the following courses. Pick one:", chosen_assignment.getTitle());
                                    choice = Menu.selectFromList(menu_title, owned_courses);
                                    Course chosen_course = owned_courses[choice - 1];
                                    chosen_course.remove(chosen_assignment);
                                }
                                else
                                    Menu.WriteLineRed(String.Format("Assignment {0} isn't added in any courses yet", chosen_assignment.getTitle()));
                            }
                            else
                                Menu.WriteLineRed("No assignments have been added yet");


                        }
                        else if (choice == 7)
                        {
                            choice = Menu.selectFromList("Pick a course to delete:", courses);
                            courses.RemoveAt(choice - 1);

                        }
                        continue_editting = Menu.insistForCorrectInput("1.Yes\n2.No", (short)1, (short)2, "Continue Editting Entities?") == 1 ? true : false;

                    }
                }
                else if (choice == 3) // VIEW MODE
                {
                    bool continue_viewing_entities = true;
                    while (continue_viewing_entities)
                    {
                        choice = Menu.insistForCorrectInput(Menu.getViewEntityMenuStr(), 1, 10,default_menu_title);
                        if (choice == 1)//students
                        {
                            List<Student> distinctStudents = Menu.getDistinctStudents(courses);
                            if (distinctStudents.Count > 0)
                            {
                                Menu.WriteLineYellow("Students:");
                                Console.WriteLine(Menu.listToMenuStr(distinctStudents));
                            }

                            else
                                Menu.WriteLineRed("No students have been added yet.");
                        }
                        else if (choice == 2)//trainers
                        {
                            List<Trainer> distinctTrainers = Menu.getDistinctTrainers(courses);
                            if (distinctTrainers.Count > 0)
                            {
                                Menu.WriteLineYellow("Trainers:");
                                Console.WriteLine(Menu.listToMenuStr(distinctTrainers));
                            }
                            else
                                Menu.WriteLineRed("No trainers have been added yet.");
                        }
                        else if (choice == 3)//assignments
                        {
                            List<Assignment> distinctAssignments = Menu.getDistinctAssignments(courses);
                            if (distinctAssignments.Count > 0)
                            {
                                Menu.WriteLineYellow("Assignments:");
                                Console.WriteLine(Menu.listToMenuStr(distinctAssignments));
                            }
                            else
                                Menu.WriteLineRed("No assignments have been added yet.");
                        }
                        else if (choice == 4)//courses
                        {
                            if (courses.Count > 0)
                            {
                                Menu.WriteLineYellow("Courses:");
                                Console.WriteLine(Menu.listToMenuStr(courses));

                            }
                            else
                                Menu.WriteLineRed("No courses have been added yet");

                        }
                        else if (choice == 5)//All the students per course 
                        {
                            if (courses.Count > 0)
                            {
                                choice = Menu.selectFromList("Please select a course to show its students:",courses);
                                Course courseChosen = courses[choice - 1];//'-1' need to scale down the menu choice (1-max)->)(0-max
                                if (courseChosen.getStudents().Count > 0)
                                    Console.WriteLine(Menu.listToMenuStr(courseChosen.getStudents()));
                                else
                                    Menu.WriteLineRed(String.Format("You haven't entered any students yet for course {0}", choice));
                            }
                            else
                            {
                                Menu.WriteLineRed("No students nor courses have been added yet");
                            }
                        }
                        else if (choice == 6) //All the trainers per course 
                        {
                            if (courses.Count > 0)
                            {
                                choice = Menu.selectFromList("Please select a course to show its trainers:", courses);
                                Course courseChosen = courses[choice - 1];//'-1' need to scale down the menu choice (1-max)->)(0-max
                                if (courseChosen.getTrainers().Count > 0)
                                    Console.WriteLine(Menu.listToMenuStr(courseChosen.getTrainers()));
                                else
                                    Menu.WriteLineRed(String.Format("You haven't entered any trainers yet for course {0}", choice));
                            }
                            else
                            {
                                Menu.WriteLineRed("No trainers nor courses have been added yet");
                            }
                        }
                        else if (choice == 7)//All the assignments per course 
                        {
                            if (courses.Count > 0)
                            {
                                choice = Menu.selectFromList("Please select a course to show its assignments:", courses);
                                Course courseChosen = courses[choice - 1];//'-1' need to scale down the menu choice (1-max)->)(0-max
                                if (courseChosen.getAssignments().Count > 0)
                                    Console.WriteLine(Menu.listToMenuStr(courseChosen.getAssignments()));
                                else
                                    Menu.WriteLineRed(String.Format("You haven't entered any assignments yet for course {0}", choice));


                            }
                            else
                            {
                                Menu.WriteLineRed("No assignments nor courses have been created.");
                            }
                        }
                        else if (choice == 8)//All the assignments per student 
                        {
                            if (courses.Count > 0)
                            {
                                List<Student> distinct_students = Menu.getDistinctStudents(courses);
                                if (distinct_students.Count > 0)
                                {
                                    //first output distinct students and make user select one
                                    choice = Menu.selectFromList("Please select a student from the list:", distinct_students);
                                    Student chosen_student = distinct_students[choice - 1];

                                    //now find all distinct assignments for the chosen student and print them;
                                    List<Assignment> distinct_assignments = Menu.getAssignmentsOfStudent(courses, chosen_student);
                                    if (distinct_assignments.Count > 0) {
                                        Menu.WriteLineYellow(String.Format("{0} {1}'s assignments:\n{2}", chosen_student.getFirstName(), chosen_student.getLastName()));
                                        Console.WriteLine(Menu.listToMenuStr(distinct_assignments));
                                    }
                                    else
                                        Menu.WriteLineRed(String.Format("Student {0} doesn't have any assignments due", chosen_student));
                                }
                                else
                                    Menu.WriteLineRed("You haven't entered students yet");
                            }
                            else
                                Menu.WriteLineRed("You can't have any assignments or students without adding courses first");


                        }
                        else if (choice == 9)//A list of students that belong to more than one courses 
                        {
                            if (courses.Count > 0)
                            {
                                List<Student> studentDuplicates = Menu.getIndistinctStudents(courses);
                                if (studentDuplicates.Count > 0)
                                {
                                    Menu.WriteLineYellow("The following students belong to more than one courses:");
                                    Console.WriteLine(Menu.listToMenuStr(studentDuplicates));
                                }
                                else
                                    Menu.WriteLineRed("Curently 0 students are in more than one courses");
                            }
                            else
                                Menu.WriteLineRed("You haven't added any courses yet.");
                        }
                        else if (choice == 10)// ask from the user a date and it should output a 
                                              //list of students who need to submit one or more assignments 
                                              //on the same calendar week as the given date 
                        {
                            if (courses.Count > 0)
                            {
                                

                                DateTime givenDay = Menu.insistForCorrectDateInput();
                                DateTime monday = Menu.WeekDayDate(givenDay, DayOfWeek.Monday);
                                
                                DateTime friday = Menu.WeekDayDate(givenDay, DayOfWeek.Friday);
                                if (monday.DayOfWeek != DayOfWeek.Monday)
                                    throw new InvalidDataException("NOT MONDAY BRO");
                                else if (friday.DayOfWeek != DayOfWeek.Friday)
                                    throw new InvalidDataException("NOT FRIDAY BRO");
                                List<Student> subm_students = Menu.getWeekSubmissionStudents(courses, monday, friday);
                                if (subm_students.Count > 0)
                                    Console.WriteLine("Students that need to submit assignments from {0} to {1}\n{3}", monday, friday, Menu.listToMenuStr(subm_students));
                                else
                                    Menu.WriteLineRed("No students have assignments to submit during those days");
                            }
                            else
                                Menu.WriteLineRed("No courses have been added yet");
                        }

                        continue_viewing_entities = Menu.insistForCorrectInput("1.Yes\n2.No", (short)1, (short)2,"Continue Viewing stuff?") == 1 ? true : false;
                    }
                }
                else if (choice == 4)
                {
                    exit = true;
                }
            }
        }

        
        
    }
}
