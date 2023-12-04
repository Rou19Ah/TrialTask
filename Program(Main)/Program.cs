using Options_Choice;

/// <summary>
/// Represents the entry point for the application.
/// Inside optionsBuilder.UseSqlServer() must be filled with the Connection String of Connected Database before Running the App.
/// Please Replace it with your own Connection String.
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
        // Set UnitTest flag to false when running the main program.
        UnitTest = false;

        // Create an instance of the Start class to manage user choices.
        Start Choice = new Start();

        // Display options to the user and perform the selected action.
        Choice.Options();
    }
}
