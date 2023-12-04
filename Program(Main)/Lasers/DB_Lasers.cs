using Microsoft.EntityFrameworkCore;

namespace DB_Table
{
    /// <summary>
    /// Represents the database context for managing laser-related data.
    /// </summary>
    public class DB_Lasers : DbContext
    {
        /// <summary>
        /// Configures the database context options, specifying the connection string.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /// **** Inside UseSqlServer() must be filled with the Connection String of Connected Database.
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Erwin\\Documents\\MSSQLLocalDB.mdf;Integrated Security=True;Connect Timeout=30");
        }

        /// Represents the DbSet for the Laser entity in the database.
        public DbSet<Laser> Lasers { get; set; }
    }

    /// <summary>
    /// Represents the Laser entity in the database.
    /// </summary>
    public class Laser
    {
        /// Gets or sets method for data entity.
        public int LaserID { get; set; }
        public string LaserName { get; set; }
        public decimal MaximumPower { get; set; }
        public int MaximumWeldingDuration { get; set; }
        public int NumberOfTriggeredWelds { get; set; }
        public decimal ConsumedEnergy { get; set; }
    }
}
