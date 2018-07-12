using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YetAnotherDeveloper.YetAnotherCalendar.UnitTests
{
    /// <summary>
    /// Summary description for DateInfoTest
    /// </summary>
    [TestClass]
    public class DateInfoTest
    {
        public DateInfoTest()
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
        public void TestWeekOfMonth()
        {
            DateInfo mydate = new DateInfo(new DateTime(2009, 8, 11));
            Assert.IsTrue(mydate.WeekOfMonth == Week.Third);

            mydate = new DateInfo(new DateTime(2009, 8, 3));
            Assert.IsTrue(mydate.WeekOfMonth == Week.Second);

            mydate = new DateInfo(new DateTime(2009, 8, 18));
            Assert.IsTrue(mydate.WeekOfMonth == Week.Fourth);


            mydate = new DateInfo(new DateTime(2009, 8, 31));
            Assert.IsTrue(mydate.WeekOfMonth == Week.Sixth);

        }
    }
}
