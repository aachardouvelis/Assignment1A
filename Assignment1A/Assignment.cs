using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    

    public class Assignment:Identity
    {
        private static int ID_counter;
        public int ID {  get;private set; }
        private string title { get; set; }
        private string description { get; set; }
        private float oral_mark, total_mark;
        private DateTime subDateTime;

        public Assignment( string title, string description, float oral_mark, float total_mark,DateTime subDateTime)
        {
            if (subDateTime.DayOfWeek == DayOfWeek.Saturday || subDateTime.DayOfWeek == DayOfWeek.Sunday)
                throw new InvalidDataException(String.Format("attempted to submit submission date of assignment to Saturday or Sunday" +
                    "\nID:{0} weekday:{1}",ID_counter,subDateTime.DayOfWeek));
            this.ID = ID_counter++;
            this.title = title;
            this.description = description;
            this.oral_mark = oral_mark;
            this.total_mark = total_mark;
            this.subDateTime = subDateTime;
        }
        public int getID() { return ID; }
        public string getTitle() { return title; }
        public void setTitle(string title) { this.title = title; }
        public string getDescription() { return description; }
        public void setDescription(string description) { this.description = description; }
        public DateTime getSubDateTime() { return this.subDateTime; }
        public void setSubDateTime(DateTime subDateTime) {
            if (subDateTime.DayOfWeek == DayOfWeek.Saturday || subDateTime.DayOfWeek == DayOfWeek.Sunday)
                throw new InvalidDataException("attempted to submit submission date of assignment to Saturday or Sunday");
            this.subDateTime = subDateTime;  
        }
        public float getOralMark() { return oral_mark; }
        public void setOralMark(float oral_mark) { this.oral_mark = oral_mark; }
        public float getTotalMark() { return total_mark; }
        public void setTotalMark(float total_mark) { this.total_mark = total_mark; }
        public override string ToString()
        {
            return String.Format("ID:{0} Title:{1} Submission Date:{2} Description:{3}",ID,title,subDateTime.ToString("dd/MM/yyyy"),description);
        }
    }
}
