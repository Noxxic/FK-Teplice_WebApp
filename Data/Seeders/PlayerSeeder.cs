using System;
using System.Collections.Generic;
using System.Linq;

using FKTeplice.Models;

namespace FKTeplice.Data.Seeders
{
    public class PlayerSeeder : ISeeder
    {
        ApplicationDbContext _context;

        Random rnd = new Random();

        int PlayerCount { get; } = 20;

        string[] firstNames = new string[] {
            "Jiří", "Jan", "Petr", "Josef", "Pavel", "Jaroslav", "Martin", "Miroslav", "Tomáš", "František",
            "Zdeněk", "Václav", "Karel", "Milan", "Michal", "Vladimír", "Lukáš", "David", "Ladislav", "Jakub"
        };

        string[] lastNames = new string[] {
            "Novák", "Svoboda", "Novotný", "Dvořák", "Černý", "Procházka", "Kučera", "Veselý", "Krejčí", "Horák",
            "Němec", "Marek"
        };

        DateTime MinBirthday { get; } = new DateTime(1990, 1, 1);    
        DateTime MaxBirthday { get; } = new DateTime(2010, 1, 1);

        public PlayerSeeder(ApplicationDbContext _context) {
            this._context = _context;
        }

        public void Run()
        {
            int count = _context.Teams.Count();

            _context.Players.AddRangeAsync(
                Enumerable.Range(0, this.PlayerCount).Select(x => new Player() {
                    FirstName = firstNames[rnd.Next(firstNames.Length)],
                    LastName = lastNames[rnd.Next(lastNames.Length)],
                    Birthday = MinBirthday.AddDays(rnd.Next((MaxBirthday - MinBirthday).Days)),
                    TeamId = _context.Teams.OrderBy(team => team.Id).Skip(rnd.Next(count)).Take(1).First().Id
                })
            );

            _context.SaveChangesAsync();
        }
    }
}