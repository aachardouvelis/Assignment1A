using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    public class Course:Identity
    {
        private static int _ID;
        public int ID { private set; get; }
        //since there is a get method for everything do I need to make the fields ->properties?
        private string title;
        private string type { get; set; }//not sure if its string or enum

        private string stream;// wtf is a stream?
        private DateTime start_date { get; set;}
        private DateTime end_date { get; set; }

        private List<Student> students;
        private List<Trainer> trainers;// is there only one trainer for each course?
        private List<Assignment> assignments;

        public Course(string title,string type,string stream,DateTime start_date,DateTime end_date)
        {
            this.ID = _ID++;
            students = new List<Student>();
            trainers = new List<Trainer>();
            assignments = new List<Assignment>();
            this.title = title;
            this.type = type;
            this.stream = stream;
            this.start_date = start_date;
            this.end_date = end_date;
        }

        public void addStudent(Student student)
        {
            
            students.Add(student);
        }
        public List<Student> getStudents()
        {
            return students;
        }

        public bool containsElement(Identity element)
        {
            IEnumerable<Identity> elements = new List<Identity>();
            if (typeof(Student).IsInstanceOfType(element))

                elements = getStudents();
            else if (typeof(Assignment).IsInstanceOfType(element))

                elements = getAssignments();
            else if (typeof(Course).IsInstanceOfType(element))

                elements = getTrainers();
            else if (typeof(Trainer).IsInstanceOfType(element))
                elements = getTrainers();
            else
            {
                throw new ArgumentException(String.Format("recieved something thats not a student/assignment/trainer\nelement:{0}", element));
                //elements = new List<Identity>();
            }
            foreach (Identity idenIter in elements)
                if (idenIter.ID == element.ID)
                    return true;
            return false;
        }

        public bool hasStudent(Student student)
        {
            foreach (Student studIter in students)
                if (studIter.ID == student.ID)
                    return true;
            return false;
        }

        public void addAssignment(Assignment ass)
        {
            assignments.Add(ass);
        }
        public List<Assignment> getAssignments()
        {
            return assignments;
        }

        //public bool isDuplicate(Student student)
        //{
        //    foreach (Student stu in students)
        //        if (stu.ID == student.ID)
        //            return true;
        //    return false;
        //}
        //public bool isDuplicate(Trainer trainer)
        //{
        //    foreach (Trainer trai in trainers)
        //        if (trai.ID == trainer.ID)
        //            return true;
        //    return false;
        //}
        //public bool isDuplicate(Assignment assignment)
        //{
        //    //Func<double, double, double> mult = (x, y) => (x * y);
        //    //delegate bool myCalc(assignment one, assignment two);
        //    //Func<Assignment, Assignment, bool> func1 = (ass1, ass2) => ass1.getTitle() == ass2.getTitle() && ass1.getDescription()==ass2.getDescription();
        //    foreach (Assignment assIter in assignments)
        //        if (assIter.getTitle() == assignment.getTitle() && assIter.getDescription() == assignment.getDescription())
        //            return true;
        //    return false;
        //}

        public void addTrainer(Trainer trainer)
        {
            trainers.Add(trainer);
        }

        public List<Trainer> getTrainers()
        {
            return trainers;    
        }
        //public override string toString() { 
        public override string ToString()
        {
            return String.Format("Title:{0}, Type:{1}, Stream{2}, Starts:{3}, Ends:{4}", title, type, stream, start_date.ToString("dd/MM/yyy"), end_date.ToString("dd/MM/yyy"));
        }
          

        
        //private static bool contains(List<Student> students, Student student)
        //{
        //    foreach (Student stuIter in students)
        //        if (stuIter.ID == student.ID)
        //            return true;
        //    return false;
        //}
        //private static bool contains(List<Trainer> trainers, Trainer trainer)
        //{
        //    foreach (Trainer trainIter in trainers)
        //        if (trainIter.ID == trainer.ID)
        //            return true;
        //    return false;
        //}
        //private static bool contains(List<Assignment> assignments,Assignment assignment)
        //{
        //    foreach (Assignment assIter in assignments)
        //        if (assIter.ID == assignment.ID)
        //            return true;
        //    return false;
        //}
        public string getTitle() { return title; }
        public void setTitle(string title) { this.title = title; }
        public string getStream() { return stream; }
        public void setStream(string stream) { this.stream=stream; }
        public string getType() { return type; }
        public void setType(string type) { this.type = type; }
        public DateTime getStartDate() { return start_date; }
        public void setStartDate(DateTime start_date){this.start_date=start_date;}
        public DateTime getEndDate() { return end_date; }
        public void setEndDate(DateTime end_date) { this.end_date = end_date; }// should I accept strings or DateTimes?

        internal bool hasTrainer(Trainer trainer)
        {
            foreach (Trainer trainIter in trainers)
                if (trainer.ID == trainIter.ID)
                    return true;
            return false;
        }
        public static List<Course> getCoursesOfTrainer(List<Course> courses, Trainer chosen_trainer)
        {
            List<Course> courses_owned = new List<Course>();
            foreach (Course courIter in courses)
                if (courIter.hasTrainer(chosen_trainer))
                    courses_owned.Add(courIter);

            return courses_owned;
        }
        public static List<Course>getCoursesOfAssignment(List<Course> courses, Assignment assignment)
        {
            List<Course> courses_owned = new List<Course>();
            foreach (Course courIter in courses)
                if (courIter.hasAssignment(assignment))
                    courses_owned.Add(courIter);

            return courses_owned;
        }
        internal bool hasAssignment(Assignment assignment)
        {
            foreach (Assignment assIter in assignments)
                if (assignment.ID == assIter.ID)
                    return true;
            return false;
        }

        //public void remove(Identity chosen_iden)
        //{
        //    IEnumerable<Identity> elements;
        //    if (typeof(Student).IsInstanceOfType(chosen_iden))
        //        elements = getStudents();
        //    else if (typeof(Assignment).IsInstanceOfType(chosen_iden))
        //        elements = getAssignments();
        //    else if (typeof(Trainer).IsInstanceOfType(chosen_iden))
        //        elements = getTrainers();
        //    else
        //        throw new ArgumentException("can only remove assignments/students/trainers from a course");
        //    //List < Identity > list_cast= (List<Identity>)elements;
        //    int i = 0;
        //    //foreach (Identity idenIter in elements) {

        //    //    if (idenIter.ID == chosen_iden.ID)
        //    //        elements.remove(i);
        //    //        }
        //    for(int i=0;i< elements.Count;i++)
        //        if(list_cast[i].ID== chosen_iden.ID)
        //        {
        //            list_cast.RemoveAt(i);
        //            break;
        //        }
        //}

        internal void remove(Assignment chosen_assignment)
        {
            for (int i = 0; i < assignments.Count; i++)
                if (assignments[i].ID == chosen_assignment.ID)
                {
                    assignments.RemoveAt(i);
                    break;
                }
        }

        internal void remove(Trainer chosen_trainer)
        {
            for (int i = 0; i < trainers.Count; i++)
                if (trainers[i].ID == chosen_trainer.ID)
                {
                    trainers.RemoveAt(i);
                    break;
                }
        }

        internal void remove(Student chosen_student)
        {
            for (int i = 0; i < trainers.Count; i++)
                if (students[i].ID == chosen_student.ID)
                {
                    students.RemoveAt(i);
                    break;
                }
        }
    }
}
