using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YetAnotherDeveloper.YetAnotherCalendar.UnitTests
{
    /// <summary>
    /// Summary description for DateUnitTest
    /// </summary>
    [TestClass]
    public class DateUnitTest
    {
        public DateUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InitDateByMonthAndDay()
        {
            Date myDate = new Date(Month.May, 5);

            Assert.IsTrue(myDate.Day == 5);
            Assert.IsTrue(myDate.Month == Month.May);            
        }


        [TestMethod]
        public void InitDateByMonthAndDayAndName()
        {
            Date myDate = new Date(Month.May, 5, "May 5th");
            Assert.IsTrue(myDate.Name == "May 5th");
        }

        [TestMethod]
        public void InitDateTypeVariable()
        {
            Date myDate = new Date(Week.First, DayOfWeek.Sunday, Month.June);

            Assert.IsTrue(myDate.Week == Week.First);
            Assert.IsTrue(myDate.WeekDayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(myDate.Month == Month.June);

        }


        [TestMethod]
        public void InitDateTypeVariableAndName()
        {
            Date myDate = new Date(Week.First, DayOfWeek.Sunday, Month.June, "FirstSundayOfJune");

            Assert.IsTrue(myDate.Name == "FirstSundayOfJune");

        }

        [TestMethod]
        public void leaptest()
        {
            int result = DateTime.DaysInMonth(2008, (int)Month.February);
            Assert.IsTrue(result == 29);

            int result2 = DateTime.DaysInMonth(2009, (int)Month.February);
            Assert.IsTrue(result2 == 28);            
            
        }
    }
}
