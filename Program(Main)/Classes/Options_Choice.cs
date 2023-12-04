using Program_Operation;

namespace Options_Choice
{
    /// <summary>
    /// Represents a class for managing user options.
    /// </summary>
    public class Start
    {
        private bool reset;

        /// <summary>
        /// Displays options to the user and performs the selected action.
        /// </summary>
        public void Options()
        {
            LaserDataRetriever Lasers_list = new LaserDataRetriever();
            Console.WriteLine("\n1. Displaying the available lasers \n2. Perform a welding \n Choose the desired command by number:");

            /// Varaible only to be able do the loop till user input becomes a number between 1-3
            reset = true;

            /// do {}(while) loop for case that user input is not a number
            do
            {
                /// try() catch for case that user input is out of range
                try
                {
                    int result = int.Parse(Console.ReadLine());
                    reset = false;
                    if (result == 1)
                    {
                        Lasers_list.RetrieveAndPrintLaserData();
                    }
                    else if (result == 2)
                    {
                        Lasers_list.PerformOperation();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        reset = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    reset = true;
                }
            } while (reset);
        }
    }
}
