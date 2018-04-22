using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FKTeplice.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string LabelX { get; set; }

        [Required]
        public string LabelY { get; set; }

        public ICollection<Physio> Physios { get; set; } = new HashSet<Physio>();
    }
}
