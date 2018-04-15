using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FKTeplice.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Opponent { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string Result { get; set; }

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}
