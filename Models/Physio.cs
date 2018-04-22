using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FKTeplice.Models
{
    public class Physio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Result { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        public int CompetitionId { get; set; }
        [ForeignKey("CompetitionId")]
        public virtual Competition Competition { get; set; }
    }
}
