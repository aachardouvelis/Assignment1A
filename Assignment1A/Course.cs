using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    class Course
    {
        //since there is a get method for everything do I need to make the fields ->properties?
        private string title;   
        private string type { get; set; }//not sure if its string or enum

        private string stream;// wtf is a stream?
        private DateTime start_date { get; set;}
        private DateTime end_date { get; set; }

        private List<Student> students;
        private List<Trainer> trainers;// is there only one trainer for each course?
        private List<Assignment> assignments;

        public void addStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> getStudents()
        {
            return students;
        }

        public void addTrainer(Trainer trainer)
        {
            trainers.Add(trainer);
        }

        public List<Trainer> getTrainers()
        {
            return trainers;
        }
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

    }
}
