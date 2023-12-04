using DB_Table;

namespace Update_DB
{
    /// <summary>
    /// Represents a class for updating database records related to lasers.
    /// </summary>
    public class UpdateDatabase
    {
        private decimal consumedEnergy;
        private int laserId;
        private int numberOfWelds;

        /// Gets the actual consumed energy after the operation.
        public static decimal ActualConsumedEnergy;

        /// Gets the actual number of triggered welds after the operation.
        public static int ActualNumberOfTriggeredWelds;

        /// Initializes a new instance of the <see cref="UpdateDatabase"/> class with the specified values.
        /// <param name="consumedEnergy">The amount of consumed energy to update.</param>
        /// <param name="laserId">The ID of the laser to update.</param>
        /// <param name="numberOfWelds">The number of welds to add.</param>
        public UpdateDatabase(decimal consumedEnergy, int laserId, int numberOfWelds)
        {
            this.consumedEnergy = consumedEnergy;
            this.laserId = laserId;
            this.numberOfWelds = numberOfWelds;
        }

        /// Updates the database table with the specified values.
        public void UpdateTable()
        {
            using (var table = new DB_Lasers())
            {
                var laserEntity = table.Lasers.SingleOrDefault(l => l.LaserID == laserId);

                if (laserEntity != null)
                {
                    // Update the laser entity
                    laserEntity.ConsumedEnergy += consumedEnergy;
                    laserEntity.NumberOfTriggeredWelds += numberOfWelds;

                    // Set actual values for verification in unit tests
                    ActualConsumedEnergy = laserEntity.ConsumedEnergy;
                    ActualNumberOfTriggeredWelds = laserEntity.NumberOfTriggeredWelds;

                    // Save changes to the database if not in unit test mode
                    if (Program.UnitTest == false)
                    {
                        table.SaveChanges();
                    }
                }
            }
        }
    }
}
