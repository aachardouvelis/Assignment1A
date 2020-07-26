using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1A.UnitTests
{
    [TestClass]
    public class MenuTests
    {
        List<Course> courses;
        public List<Student> dummy_students;
        public MenuTests()
        {
            courses = Menu.GetSyntheticData1();
            dummy_students = new List<Student> { new Student("A", "A", new DateTime(), 100), new Student("B", "B", new DateTime(), 150) };
        }
        [TestMethod]
        public void isDuplicate_ListIsEmpty_ReturnsFalse()
        {
            //Arrange
            List<Assignment> alist = new List<Assignment>();
            Assignment ass = new Assignment("A", "description_data", 50, 50, new DateTime());

            //Act
            bool ret = Menu.isDuplicate(alist, ass);

            //Assert
            Assert.IsFalse(ret);
        }
         
        [TestMethod]
        public void isDuplicate_SendStudentObj_ReturnsTrue()
        {
            //Arrange
            List<Student> students = courses[0].getStudents();
            Student stu1 = students[1];

            //Act
            bool ret = Menu.isDuplicate(students, stu1);

            //Assert
            Assert.IsTrue(ret);
            //DateTime bdate;
            //DateTime.TryParse("10/03/1993", out bdate);
            //Student stu1 = new Student("name", "lastn", bdate, 100);

        }
        [TestMethod]
        public void WeekDateTime_sendMonday_returnMonday()
        {
            DateTime date_given;
            DateTime.TryParse(("20/07/2020"), out date_given);//MONDAY
            DateTime ret=Menu.WeekDayDate(date_given, DayOfWeek.Monday);
            Assert.IsTrue(ret.DayOfWeek == DayOfWeek.Monday);
        }
        [TestMethod]
        public void WeekDateTime_sendTuesday_returnMonday()
        {
            DateTime date_given;
            DateTime.TryParse(("21/07/2020"), out date_given);//Tuesday
            DateTime ret = Menu.WeekDayDate(date_given, DayOfWeek.Monday);
            Assert.IsTrue(ret.DayOfWeek == DayOfWeek.Monday);
        }
        [TestMethod]
        public void WeekDateTime_sendFriday_returnMonday()
        {
            DateTime date_given;
            DateTime.TryParse(("24/07/2020"), out date_given);//Friday
            DateTime ret = Menu.WeekDayDate(date_given, DayOfWeek.Monday);
            Assert.IsTrue(ret.DayOfWeek == DayOfWeek.Monday);
        }
        [TestMethod]
        public void WeekDateTime_sendThursday_returnFriday()
        {
            DateTime date_given;
            DateTime.TryParse(("23/07/2020"), out date_given);//Thursday
            DateTime ret = Menu.WeekDayDate(date_given, DayOfWeek.Friday);
            Assert.IsTrue(ret.DayOfWeek == DayOfWeek.Friday);
        }
    }
}
