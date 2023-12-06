using DB_Table;
using Options_Choice;

/// <summary>
/// Represents the entry point for the application.
/// Sqlite added so no more DB problem although unit test actually acted weird and still acting a little bit weird
/// </summary>
class Program
{
    /// <summary>
    /// A flag indicating whether the program is in unit test mode.
    /// </summary>
    public static bool UnitTest = true;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public static void Main()
    {

        using (var context = new DB_Lasers())
        {
            context.Database.EnsureCreated();
            // Check if the table is empty
            if (!context.Lasers.Any())
            {
                // if empty calling the method initial data
                context.InsertInitialData();
                Console.WriteLine("Data inserted successfully.");
            }
        }
        // Set UnitTest flag to false when running the main program.
        UnitTest = false;

        // Create an instance of the Start class to manage user choices.
        Start Choice = new Start();

        // Display options to the user and perform the selected action.
        Choice.Options();
    }
}
