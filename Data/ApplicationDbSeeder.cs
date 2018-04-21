using System;
using FKTeplice.Data.Seeders;

namespace FKTeplice.Data {
    public class ApplicationDbSeeder {
        public static void Seed(ApplicationDbContext _context, string seeder) {
            if(String.IsNullOrWhiteSpace(seeder)) {
                new TeamSeeder().Run(_context);
                new PlayerSeeder().Run(_context);
            } else {
                ISeeder seederInstance = (ISeeder) Activator.CreateInstance(Type.GetType(seeder));
                seederInstance.Run(_context);
            }

            Console.WriteLine("Database has been seeded");
            Environment.Exit(1);
        }
    }
}