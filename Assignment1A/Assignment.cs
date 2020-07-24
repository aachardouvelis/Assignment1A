using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    class Assignment
    {
        private string title { get; set; }
        private string description { get; set; }
        private float oral_mark, total_mark;
        private DateTime subDateTime;

        public string getTitle() { return title; }
        public void setTitle(string title) { this.title = title; }
        public string getDescription() { return description; }
        public void setDescription(string description) { this.description = description; }
        public DateTime getSubDateTime() { return this.subDateTime; }
        public void setSubDateTime(DateTime subDateTime) { this.subDateTime = subDateTime;  }
        public float getOralMark() { return oral_mark; }
        public void setOralMark(float oral_mark) { this.oral_mark = oral_mark; }
        public float getTotalMark() { return total_mark; }
        public void setTotalMark(float total_mark) { this.total_mark = total_mark; }
    
    }
}
