using DB_Table;
using PerformOperation;
using Program_Operation;
using Update_DB;

/// <summary>
/// this part could have been done with Moq framework also but it would add complexity to project and unit test and make it harder to read
/// </summary>
namespace Unit.Tests
{
    /// <summary>
    /// Test class for updating the database. this part could have been done with Moq framework also but it would add complexity to project
    /// </summary>
    [TestClass]
    public class UpdateDatabaseTests
    {
        private List<Laser> testData;

        /// <summary>
        /// Test initialization method for copying data
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            using (var context = new DB_Lasers())
            {
                testData = context.Lasers.ToList();
            }
        }

        /// <summary>
        /// Test method for updating database values
        /// </summary>
        [TestMethod]
        public void UpdateTable_Value()
        {
            // Arrange
            int C = 20, I = 3, W = 2;
            var updateDatabase = new UpdateDatabase(C, I, W); 
            int expectedNumberOfWelds = testData.First(l => l.LaserID == I).NumberOfTriggeredWelds + W;
            decimal expectedConsumedEnergy = testData.First(l => l.LaserID == I).ConsumedEnergy + C;

            // Act
            updateDatabase.UpdateTable();

            // Assert
            using (var context = new DB_Lasers())
            {
                int actualNumberOfTriggeredWelds = UpdateDatabase.ActualNumberOfTriggeredWelds;
                decimal actualConsumedEnergy = UpdateDatabase.ActualConsumedEnergy;

                Assert.AreEqual(expectedNumberOfWelds, actualNumberOfTriggeredWelds);
                Assert.AreEqual(expectedConsumedEnergy, actualConsumedEnergy, 0.1m);
            }
        }
    }

    /// <summary>
    /// Test class for displaying lasers information
    /// </summary>
    [TestClass]
    public class DisplayDatabaseTests
    {
        private List<Laser> testData;

        /// <summary>
        /// Test initialization method for copying data
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            using (var context = new DB_Lasers())
            {
                testData = context.Lasers.ToList();
            }
        }

        /// <summary>
        /// Test method for displaying the list
        /// </summary>
        [TestMethod]
        public void DisplayList()
        {
            // Arrange
            var Display = new LaserDataRetriever();

            // Act
            Display.RetrieveAndPrintLaserData();

            // Assert
            string expectedString = "";
            foreach (var laser in testData)
            {
                expectedString += $"LaserID: {laser.LaserID}" + "\n" +
                                  $" ,LaserName: {laser.LaserName}, " + "\n" +
                                  $" ,MaximumPower: {laser.MaximumPower}" + "\n" +
                                  $" ,MaximumWeldingDuration: {laser.MaximumWeldingDuration}" + "\n" +
                                  $" ,NumberOfTriggeredWelds: {laser.NumberOfTriggeredWelds}" + "\n" +
                                  $" ,ConsumedEnergy: {laser.ConsumedEnergy}" + "\n";
            }

            String actualString = Display.Display;

            // Normalize String Value
            expectedString = expectedString.Trim();
            actualString = actualString.Trim();

            Assert.AreEqual(expectedString, actualString);
        }
    }

    /// <summary>
    /// Test class for choosing laser and the operation 
    /// </summary>
    [TestClass]
    public class OperationTests
    {
        private decimal expectedConsumedEnergy, actualConsumedEnergy;
        private int expectedNumberOfWelds, actualNumberOfWelds;
        private List<Laser> testData;

        /// <summary>
        /// Test initialization method for copying data
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            using (var context = new DB_Lasers())
            {
                testData = context.Lasers.ToList();
            }
        }

        /// <summary>
        /// Test method for the operation
        /// </summary>
        [TestMethod]
        public void OperationT()
        {
            // Arrange
            var Ope = new LaserDataRetriever();
            int li = 2;
            expectedNumberOfWelds = 1 + testData.First(l => l.LaserID == li).NumberOfTriggeredWelds;

            // Act
            Ope.Userchoice = li;
            Ope.PerformOperation();
            expectedConsumedEnergy = (Operation.PW * Operation.Dur / 3600) + testData.First(l => l.LaserID == li).ConsumedEnergy;

            // Assert
            actualConsumedEnergy = UpdateDatabase.ActualConsumedEnergy;
            actualNumberOfWelds = UpdateDatabase.ActualNumberOfTriggeredWelds;

            Assert.AreEqual(expectedConsumedEnergy, actualConsumedEnergy);
            Assert.AreEqual(expectedNumberOfWelds, actualNumberOfWelds);
        }
    }
}
