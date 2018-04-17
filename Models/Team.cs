using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FKTeplice.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }
    }
}
