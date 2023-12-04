using Update_DB;

namespace PerformOperation
{
    /// <summary>
    /// Represents a class for performing welding operations with a laser.
    /// </summary>
    public class Operation
    {
        private int LaserId;
        public static decimal PW;
        public static int Dur;
        public static int NumberOfWelds;
        public decimal ConsumedEnergy;

        /// Initializes a new instance of the Operation class with the specified parameters.
        /// <param name="id">The ID of the laser.</param>
        /// <param name="pw">The power of the laser.</param>
        /// <param name="dur">The duration of the welding operation.</param>
        public Operation(int id, decimal pw, int dur)
        {
            LaserId = id;
            PW = pw;
            Dur = dur;
            NumberOfWelds = 0;
            ConsumedEnergy = 0;
        }

        /// Performs a welding operation with the laser.
        public void PerformWelding()
        {
            NumberOfWelds++;
            ConsumedEnergy = (PW * Dur) / 3600;
            Thread.Sleep(Dur * 1000);
            Console.WriteLine($"Performed welding with power {PW} and duration {Dur}.");
            UpdateDB();
        }
        /// Calling the updateDatabase class too perform updating for laser stat
        private void UpdateDB()
        {
            UpdateDatabase updateDatabase = new UpdateDatabase(ConsumedEnergy, LaserId, NumberOfWelds);
            updateDatabase.UpdateTable();
        }
    }
}
