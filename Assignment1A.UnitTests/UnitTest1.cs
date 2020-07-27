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
        [DataTestMethod]
        [DataRow(2020, 7, 27, DayOfWeek.Monday,DayOfWeek.Monday)]
        [DataRow(2020, 7,28 , DayOfWeek.Monday, DayOfWeek.Monday)]
        [DataRow(2020, 7,29, DayOfWeek.Monday, DayOfWeek.Monday)]
        [DataRow(2020, 7,30, DayOfWeek.Monday, DayOfWeek.Monday)]
        [DataRow(2020, 7,31, DayOfWeek.Monday, DayOfWeek.Monday)]
        [DataRow(2020, 8,1, DayOfWeek.Monday, DayOfWeek.Monday)]
        [DataRow(2020, 8, 2, DayOfWeek.Monday, DayOfWeek.Monday)]
        [DataRow(2020, 7, 27, DayOfWeek.Friday, DayOfWeek.Friday)]
        [DataRow(2020, 7, 28 , DayOfWeek.Friday, DayOfWeek.Friday)]
        [DataRow(2020, 7, 29, DayOfWeek.Friday, DayOfWeek.Friday)]
        [DataRow(2020, 7, 30, DayOfWeek.Friday, DayOfWeek.Friday)]
        [DataRow(2020, 7, 31, DayOfWeek.Friday, DayOfWeek.Friday)]
        [DataRow(2020, 8, 1, DayOfWeek.Friday, DayOfWeek.Friday)]
        [DataRow(2020, 8, 2, DayOfWeek.Friday, DayOfWeek.Friday)]
        public void WeekDateTime_sendDates_returnMonday(int year, int month, int day, DayOfWeek dayofweek,DayOfWeek result)
        {
            DateTime dt = new DateTime(year, month, day);
            DateTime ret = Menu.WeekDayDate(dt, dayofweek);

            Assert.AreEqual(ret.DayOfWeek, result);
        }
        [DataTestMethod]
        [DataRow(2020, 7, 26, -1)]
        [DataRow(2020, 7, 27, 0)]
        [DataRow(2020, 7, 28, 1)]
        [DataRow(2020, 7, 29, 2)]
        [DataRow(2020, 7, 30, 3)]
        [DataRow(2020, 7, 31, 4)]
        [DataRow(2020, 8, 1, 5)]
        
        public void WeekDateTime_sendDates_returnCorrectDayDiffFromMonday(int year,int month, int day, int diff)
        {
            DateTime dt = new DateTime(year, month, day);
            DateTime ret = Menu.WeekDayDate(dt, DayOfWeek.Monday);
            int result = dt.DayOfWeek - ret.DayOfWeek;
            Assert.AreEqual(result, diff);
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
        

        
    }
}
