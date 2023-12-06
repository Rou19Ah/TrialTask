using Microsoft.EntityFrameworkCore;

namespace DB_Table
{
    /// <summary>
    /// Represents the database context for managing laser-related data.
    /// </summary>
    public class DB_Lasers : DbContext
    {
        /// <summary>
        /// Represents the DbSet for the Laser entity in the database.
        /// </summary>
        public DbSet<Laser> Lasers { get; set; }
        /// <summary>
        /// Configures the database context options, specifying the connection string.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Checks and see if the table exist on the directory or not if not it makes one with same name also migration file added too
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"Database exist in Base Directory: {directory}");
            optionsBuilder.UseSqlite($"Data Source={directory}LaserList.db");
        }
        /// <summary>
        /// Seed initial data.
        /// </summary>
        public void InsertInitialData()
        {
            // Assuming table is just made and its empty
            Database.ExecuteSqlRaw("INSERT INTO Lasers (LaserID, LaserName, MaximumPower, MaximumWeldingDuration, NumberOfTriggeredWelds, ConsumedEnergy) VALUES (1, 'Laser 1', 120.0, 25, 0, 0)");
            Database.ExecuteSqlRaw("INSERT INTO Lasers (LaserID, LaserName, MaximumPower, MaximumWeldingDuration, NumberOfTriggeredWelds, ConsumedEnergy) VALUES (2, 'Laser 2', 100.0, 40, 0, 0)");
            Database.ExecuteSqlRaw("INSERT INTO Lasers (LaserID, LaserName, MaximumPower, MaximumWeldingDuration, NumberOfTriggeredWelds, ConsumedEnergy) VALUES (3, 'Laser 3', 150.0, 50, 0, 0)");
        }

        /// <summary>
        /// Represents the Laser entity in the database.
        /// </summary>
        public class Laser
        {
            /// Gets or sets method for data entity.
            public int LaserID { get; set; }
            public string LaserName { get; set; } = default!;
            public decimal MaximumPower { get; set; }
            public int MaximumWeldingDuration { get; set; }
            public int NumberOfTriggeredWelds { get; set; }
            public decimal ConsumedEnergy { get; set; }
        }
    }
}
