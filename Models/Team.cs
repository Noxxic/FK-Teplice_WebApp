using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FKTeplice.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<Match> Matches { get; set; } = new HashSet<Match>();
    }
}
