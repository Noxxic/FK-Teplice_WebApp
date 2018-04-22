using System;
using System.Collections.Generic;
using System.Linq;

using FKTeplice.Models;

namespace FKTeplice.Data.Seeders
{
    public class TeamSeeder : ISeeder
    {
        Random rnd = new Random();

        int TeamCount { get; } = 10;

        string[] adjectives = new string[] {
            "První", "Druhý", "Třetí", "Super", "Fotbalový", "Velký", "Malý", "Mladý", "Starý", "Dobrý", "Špatný",
            "Úspěšný", "Neúspěšný",
        };
        string[] teamNames = new string[] {
            "Tým", "Spolek", "Skupina", "Třída", "Družstvo", "Mužstvo",
        };

        public void Run(ApplicationDbContext _context)
        {
            int count = _context.Teams.Count();

            _context.Teams.AddRange(
                Enumerable.Range(0, this.TeamCount).Select(x => new Team() {
                    Name = $"{adjectives[rnd.Next(adjectives.Length)]} {teamNames[rnd.Next(teamNames.Length)]}"
                })
            );

            _context.SaveChanges();
        }
    }
}