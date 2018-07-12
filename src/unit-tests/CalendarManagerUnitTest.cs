using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YetAnotherDeveloper.YetAnotherCalendar.UnitTests
{
    /// <summary>
    /// Summary description for CalendarManagerUnitTest
    /// </summary>
    [TestClass]
    public class CalendarManagerUnitTest
    {
        public CalendarManagerUnitTest()
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
        public void InitilizeByDocument()
        {
            DateInfoManager.Initilize($@"{Environment.CurrentDirectory}\DateDef.xml");
        }

        [TestMethod]
        public void Is4thOfJuly()
        {
            List<Date> myDatea = new List<Date>();
            Date myDate = new Date(Month.July,4);
            myDatea.Add(myDate);
            DateInfoManager.Initilize(myDatea);


            // Test a range of years that include a leap year.
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2007, 7, 4)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2007, 7, 4)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2008, 7, 4)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2009, 7, 4)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2010, 7, 4)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2011, 7, 4)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2012, 7, 4)).IsMatchingDate());
        }


        [TestMethod]
        public void FirstMondayInDecember()
        {
            List<Date> myDatea = new List<Date>();
            Date myDate = new Date(Week.First, DayOfWeek.Monday, Month.December);
            myDatea.Add(myDate);
            DateInfoManager.Initilize(myDatea);

            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2007, 12, 3)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2008, 12, 8)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2009, 12, 7)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2010, 12, 6)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2011, 12, 5)).IsMatchingDate());
            Assert.IsTrue(DateInfoManager.GetDateInfo(new DateTime(2012, 12, 3)).IsMatchingDate());
        }

    }
}
