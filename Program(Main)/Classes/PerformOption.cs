using DB_Table;
using PerformOperation;
using Options_Choice;

namespace Program_Operation
{
    /// <summary>
    /// Represents a class for retrieving and performing operations with laser data.
    /// </summary>
    public class LaserDataRetriever
    {
        public string Display = "";
        public int Userchoice;
        private bool reset;

        /// <summary>
        /// Retrieves all laser data from the database and prints it to the console.
        /// </summary>
        public void RetrieveAndPrintLaserData()
        {
            Display = "";

            Start Back = new Start();
            using (var db_data = new DB_Lasers())
            {
                var lasers = db_data.Lasers.ToList();

                foreach (var laser in lasers)
                {
                    Display += "\n" + $"LaserID: {laser.LaserID}" + "\n" +
                        $" ,LaserName: {laser.LaserName}, " + "\n" +
                        $" ,MaximumPower: {laser.MaximumPower}" + "\n" +
                        $" ,MaximumWeldingDuration: {laser.MaximumWeldingDuration}" + "\n" +
                        $" ,NumberOfTriggeredWelds: {laser.NumberOfTriggeredWelds}" + "\n" +
                        $" ,ConsumedEnergy: {laser.ConsumedEnergy}";
                }
                Console.WriteLine(Display);
                if (!Program.UnitTest)
                {
                    Back.Options();
                }
            }
        }

        /// <summary>
        /// Performs laser operation based on user choice.
        /// </summary>
        public void PerformOperation()
        {
            /// Varaible only to be able do the loop till user input becomes a number between 1-3
            reset = true;

            Console.WriteLine("Choose a Laser for operation:");

            /// do {}(while) loop for case that user input is not a number
            do
            {
                /// the loop was stocking
                bool isInt;

                /// Just a loop to bypass isInt in case on unit test
                if (Program.UnitTest == false)
                {
                    string userInput = Console.ReadLine();
                    isInt = int.TryParse(userInput, out Userchoice);
                }
                else
                {
                    isInt = true;
                }


                /// A loop in case of number out of range or character and requesting for input
                if (isInt)
                {
                    reset = false;
                    /// A SwitchCase to choose the correct laser base on input of user
                    switch (Userchoice)
                    {
                        case 1:
                            Operation perform1 = new Operation(Userchoice, pw: 70, dur: 1);
                            Console.WriteLine($"Laser {Userchoice} Performing welding with power 70 and duration 1 seconds...");
                            perform1.PerformWelding();
                            break;
                        case 2:
                            Operation perform2 = new Operation(Userchoice, pw: 110, dur: 2);
                            Console.WriteLine($"Laser {Userchoice} Performing welding with power 110 and duration 2 seconds...");
                            perform2.PerformWelding();
                            break;
                        case 3:
                            Operation perform3 = new Operation(Userchoice, pw: 45, dur: 3);
                            Console.WriteLine($"Laser {Userchoice} Performing welding with power 45 and duration 3 seconds...");
                            perform3.PerformWelding();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            reset = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }
            } while (reset);
        }
    }
}
