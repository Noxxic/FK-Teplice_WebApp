using System;
using FKTeplice.Data.Seeders;

namespace FKTeplice.Data {
    public class ApplicationDbSeeder {
        public static void Seed(ApplicationDbContext _context) {
            new TeamSeeder(_context).Run();
            new PlayerSeeder(_context).Run();

            Console.WriteLine("Database has been seeded");
            Environment.Exit(1);
        }
    }
}