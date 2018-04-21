using System;
using FKTeplice.Models;

namespace FKTeplice.Data.Seeders
{
    public class PositionSeeder : ISeeder
    {

        public void Run(ApplicationDbContext _context)
        {
            _context.Positions.AddRange(new Position[] {
                new Position { Name = "Brankář" },
                new Position { Name = "Obránce" },
                new Position { Name = "Záložník" },
                new Position { Name = "Útočník" }
            });

            _context.SaveChanges();
        }
    }

}