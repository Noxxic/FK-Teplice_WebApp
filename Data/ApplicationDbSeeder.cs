using System;
using FKTeplice.Data.Seeders;

namespace FKTeplice.Data {
    public class ApplicationDbSeeder {
        public static void Seed(ApplicationDbContext _context) {
            Console.WriteLine("Database has been seeded");
            Environment.Exit(1);
        }
    }
}