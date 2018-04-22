using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FKTeplice.Models
{
    public class PlayerMatch
    {
        [Key]
        public int Id { get; set; }

        public byte Cards { get; set; }

        public int MatchId { get; set; }

        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        [NotMapped]
        public bool YellowCard  { 
            get {
                return (this.Cards & 1) != 0;
            } 
        }

        [NotMapped]
        public bool RedCard  { 
            get {
                return (this.Cards & 2) != 0;
            } 
        }
    }
}
